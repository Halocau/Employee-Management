using BusinessObjects.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WPF_EmployeeManagement
{
    /// <summary>
    /// Interaction logic for EmployeeUser.xaml
    /// </summary>
    public partial class EmployeeUser : Window
    {
        private readonly EmployeeManagementContext context;
        private AccountMember accountMember;
        public EmployeeUser(AccountMember accountMember)
        {
            context = new EmployeeManagementContext();
            InitializeComponent();
            this.accountMember = accountMember;
            
        }

        private void DisplayUserInfo()
        {
            var employee = accountMember.Employee;
            if (employee != null)
            {
                tbEmployeeId.Text = employee.EmployeeId.ToString();
                tbFullName.Text = $"{employee.FirstName} {employee.LastName}";
                tbEmail.Text = employee.Email;
                tbPhone.Text = employee.Phone;
                tbHireDate.Text = employee.HireDate.ToString();
                tbJobName.Text = employee.JobId.ToString(); // Thay đổi theo tên công việc thực tế nếu có
                tbSalary.Text = employee.Salary.ToString();
                tbCommission_pct.Text = employee.CommissionPct.ToString();
                //tbManager.Text = employee.ManagerId.ToString(); // Hiển thị FullName của Manager thay vì ManagerId
                //tbDepartment.Text = employee.DepartmentId.ToString(); // Hiển thị DepartmentName thay vì DepartmentId
                var manager = context.Employees.FirstOrDefault(e => e.EmployeeId == employee.ManagerId);
                tbManager.Text = manager != null ? $"{manager.FirstName} {manager.LastName}" : "No Manager";
                var department = context.Departments.FirstOrDefault(d => d.DepartmentId == employee.DepartmentId);
                tbDepartment.Text = department != null ? department.DepartmentName : "No Department";
            }
        }

        public Employee GetEmployee()
        {
            var emp = new Employee
            {
                FirstName = tbFullName.Text.Split(' ')[0], // Giả sử FullName được tách thành FirstName và LastName
                LastName = tbFullName.Text.Split(' ').Last(),
                Email = tbEmail.Text,
                Phone = tbPhone.Text,
            };
            return emp;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            tbFullName.IsReadOnly = false;
            tbEmail.IsReadOnly = false;
            tbPhone.IsReadOnly = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee newEmp = GetEmployee();
                newEmp.EmployeeId = int.Parse(tbEmployeeId.Text);
                var oldID = context.Employees.FirstOrDefault(x => x.EmployeeId == newEmp.EmployeeId);
                if (oldID != null)
                {
                    oldID.FirstName = newEmp.FirstName;
                    oldID.LastName = newEmp.LastName;
                    oldID.Email = newEmp.Email;
                    oldID.Phone = newEmp.Phone;
                    context.SaveChanges();
                    MessageBox.Show("Employee save successfully", "Notification");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayUserInfo();
        }
    }
}
