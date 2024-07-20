using BusinessObjects.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Repositories;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Security.Cryptography;

namespace WPF_EmployeeManagement
{
    /// <summary>
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class DepartmentManager : Window
    {
        private readonly EmployeeManagementContext context;
        private readonly IDepartmentRepository iDepartmentRepository;
        public DepartmentManager()
        {
            context = new EmployeeManagementContext();
            iDepartmentRepository = new DepartmentRepository();
            InitializeComponent();
        }
        public void LoadData()
        {
            lvDeparment.ItemsSource = context.Departments.Include(x => x.Manager).Include(x => x.Location).Include(x => x.Employees).ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
 
            cbManager.ItemsSource = context.Employees.ToList();
            cbManager.DisplayMemberPath = "FullName";
            cbManager.SelectedValuePath = "EmployeeId";
            LoadData();
        }
        public BusinessObjects.BusinessObjects.Department GetDepartment()
        {
            var department = new BusinessObjects.BusinessObjects.Department();
            department.DepartmentName = tbDepartmentName.Text;
            // Kiểm tra xem có giá trị SelectedValue không
            if (cbManager.SelectedValue != null)
            {
                department.ManagerId = int.Parse(cbManager.SelectedValue.ToString());
            }
            else
            {
                department.ManagerId = null; // Không có quản lý
            }

            //department.LocationId = tbStreetAddress.Text.ToString();

           
            return department;
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            tbDepartmentID.Clear();
           tbDepartmentName.Clear();
            tbStreetAddress.Clear();
            cbManager.SelectedValue = null;
           cbManager.SelectedIndex = -1;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var department = GetDepartment();
                context.Departments.Add(department);
                context.SaveChanges();
                LoadData();
                MessageBox.Show("Department added successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void lvDeparment_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // Lấy item đã chọn từ ListView
                var item = (sender as ListView).SelectedItem as BusinessObjects.BusinessObjects.Department;

                // Kiểm tra xem item có phải là null không
                if (item != null)
                {
                    // Kiểm tra xem ManagerId và Manager có phải là null không
                    if (item.ManagerId.HasValue)
                    {
                        var manager = context.Employees.FirstOrDefault(x => x.EmployeeId == item.ManagerId.Value);

                        // Nếu manager không phải là null, cập nhật ComboBox
                        if (manager != null)
                        {
                            cbManager.Text = $"{manager.FirstName} {manager.LastName}";
                        }
                        else
                        {
                            cbManager.Text = "No Manager";
                        }
                    }
                    else
                    {
                        cbManager.Text = "No Manager";
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var department = GetDepartment();
                department.DepartmentId = int.Parse(tbDepartmentID.Text);
                var OldDepartment = context.Departments.FirstOrDefault(x => x.DepartmentId == department.DepartmentId);
                if(OldDepartment != null)
                {
                    OldDepartment.DepartmentName = department.DepartmentName;
                    OldDepartment.ManagerId = department.ManagerId;
                  
                    context.SaveChanges();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Are you sure you want to delete this department?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if(result == MessageBoxResult.Yes)
                {
                    int deparID = int.Parse(tbDepartmentID.Text);
                    var oldID = context.Departments.FirstOrDefault(x => x.DepartmentId == deparID);
                    context.Database.ExecuteSqlRaw($"UPDATE [dbo].[Employees] SET DepartmentID = NULL WHERE DepartmentID = {deparID}" +
                        $"DELETE FROM dbo.Departments WHERE DepartmentID = {deparID}");
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show("Department deleted successfully");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
