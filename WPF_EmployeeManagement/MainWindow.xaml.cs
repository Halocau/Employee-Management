using BusinessObjects.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_EmployeeManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EmployeeManagementContext context;
        private readonly IEmployeeRepository iEmployeeRepository;
        private readonly IDepartmentRepository iDepartmentRepository;
        public MainWindow()
        {
            context = new EmployeeManagementContext();
            iEmployeeRepository = new EmployeeRepository();
            iDepartmentRepository = new DepartmentRepository();
            InitializeComponent();
        }
        public void LoadData()
        {

            lvEmployeeManagement.ItemsSource = context.Employees
                .AsNoTracking() // Add AsNoTracking
                .Include(x => x.Department)
                .Include(x => x.Job)
                .Include(x => x.Manager) // Include Manager
                .ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            cbJobName.ItemsSource = context.Jobs.ToList();
            cbJobName.DisplayMemberPath = "JobTitle";
            cbJobName.SelectedValuePath = "JobId";

            cbDepartment.ItemsSource = context.Departments.ToList();
            cbDepartment.DisplayMemberPath = "DepartmentName";
            cbDepartment.SelectedValuePath = "DepartmentId";

            cbDepartmentSearch.ItemsSource = context.Departments.ToList();
            cbDepartmentSearch.DisplayMemberPath = "DepartmentName";
            cbDepartmentSearch.SelectedValuePath = "DepartmentId";

            //cbManager.ItemsSource = context.Employees.ToList();
            //cbManager.DisplayMemberPath = "FullName";
            //cbManager.SelectedValuePath = "ManagerId";
            LoadData();
        }
        public Employee GetEmploye()
        {
            Employee employee = new Employee();
            employee.FirstName = tbsFirstName.Text;
            employee.LastName = tbLastName.Text;
            employee.Email = tbEmail.Text;
            employee.Phone = tbPhone.Text;
            employee.HireDate = DateOnly.FromDateTime(dpHireDate.SelectedDate.Value);
            employee.JobId = cbJobName.SelectedValue.ToString();
            //employee.ManagerId = (int?)cbManager.SelectedValue;
            employee.DepartmentId = int.Parse(cbDepartment.SelectedValue.ToString());
            return employee;
        }
        private void lvEmployeeManagement_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            try
            {
                // khi click vào 1 dòng thì nó sẽ trả về dữ liệu của dòng đấy
                var item = (sender as ListView).SelectedItem;//click vào Listview. Lấy ra giá trị vừa click
                if (item != null)
                {
                    var managerID = ((Employee)item).ManagerId;
                    Employee emp = context.Employees.FirstOrDefault(x => x.ManagerId == managerID);
                    if (emp != null)
                    {
                        //cbManager.Text = $"{emp.Manager.FirstName} {emp.Manager.LastName}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string SearchEmpName = tbSearchEmpID.Text.Trim();
                if (!string.IsNullOrEmpty(SearchEmpName))
                {
                    var foundEmpID = iEmployeeRepository.GetEmployeeByName(SearchEmpName);
                    lvEmployeeManagement.ItemsSource = foundEmpID;
                }
                else
                {
                    LoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbDepartmentSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbDepartmentSearch.SelectedValue != null)
                {
                    int departmentID = (int)cbDepartmentSearch.SelectedValue;
                    var foundDepartment = iDepartmentRepository.GetEmployeesByDepartmentId(departmentID);
                    lvEmployeeManagement.ItemsSource = foundDepartment;



                    // Update the label with the count of items
                    lblItemCount.Content = $"Count: {foundDepartment.Count()}";
                    lblItemCount.Visibility = Visibility.Visible;
                }
                else
                {
                    cbDepartmentSearch.SelectedValue = null;
                    LoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
           
            tbEmployeeID.Clear();
            tbsFirstName.Clear();
            tbLastName.Clear();
            tbEmail.Clear();
            tbPhone.Clear();
            dpHireDate.SelectedDate = null;
            //cbManager.SelectedValue = null;
            //cbManager.SelectedIndex = -1;
            //cbManager.Text = string.Empty;
            cbJobName.SelectedValue = null;
            cbDepartment.SelectedValue = null;
            cbDepartmentSearch.SelectedValue = null;
            // Hide the item count label
            lblItemCount.Visibility = Visibility.Collapsed;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = GetEmploye();
                context.Employees.Add(employee);
                context.SaveChanges();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            private void btnDelete_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    int empID = int.Parse(tbEmployeeID.Text);
                    var oldID = context.Employees.FirstOrDefault(x => x.EmployeeId == empID);
                    context.Database.ExecuteSqlRaw($"UPDATE [dbo].[Departments] SET ManagerID = NULL WHERE ManagerID = {empID}" +
                        $"\r\nUPDATE [dbo].[Employees] SET ManagerID = NULL WHERE ManagerID = {empID}" +
                        $"\r\nDELETE FROM [dbo].[Employees] WHERE EmployeeID = {empID}");
                    context.SaveChanges();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee newEmpID = GetEmploye();
                newEmpID.EmployeeId = int.Parse(tbEmployeeID.Text);

                var oldID = context.Employees.FirstOrDefault(x => x.EmployeeId == newEmpID.EmployeeId);

                if (oldID != null)
                {
                    oldID.FirstName = newEmpID.FirstName;
                    oldID.LastName = newEmpID.LastName;
                    oldID.Email = newEmpID.Email;
                    oldID.Phone = newEmpID.Phone;
                    oldID.HireDate = newEmpID.HireDate;
                    oldID.JobId = newEmpID.JobId;
                    oldID.DepartmentId = newEmpID.DepartmentId;
                    context.SaveChanges();
                    LoadData();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportJSON_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Employee> employees = context.Employees.AsNoTracking().ToList();
                if (employees.Count == 0)
                {
                    MessageBox.Show("List employee empty!", "Error");
                    return;
                }

                // JSON Export
                string jsonFilename = "JSON_EmployeeManagement.json";
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string jsonData = JsonSerializer.Serialize(employees, jsonSerializerOptions);
                File.WriteAllText(jsonFilename, jsonData);

                // TXT Export
                string txtFilename = "EmployeeManagementTEXT.txt";
                using (StreamWriter streamWriter = new StreamWriter(txtFilename))
                {
                    foreach (Employee emp in employees)
                    {
                        streamWriter.WriteLine($"{emp.FirstName} | {emp.LastName} | {emp.Email} | {emp.Phone} | {emp.HireDate} | {emp.JobId} | {emp.ManagerId} | {emp.DepartmentId}");
                    }
                }

                MessageBox.Show($"Exported successfully {employees.Count} employees to JSON and TXT.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegionandCountry_Click(object sender, RoutedEventArgs e)
        {
            RegionandCountry regionandCountry = new RegionandCountry();
            regionandCountry.Show();
         
        }
    }
}