using BusinessObjects.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class DepartmentUser : Window
    {
        private readonly EmployeeManagementContext context;
        private readonly AccountMember accountMember;

        public DepartmentUser(AccountMember accountMember)
        {
            InitializeComponent();
            this.context = new EmployeeManagementContext(); // Khởi tạo context
            this.accountMember = accountMember;
        }

        private void DisplayUserInfo()
        {
            if (accountMember?.Employee == null) return;

            var employee = accountMember.Employee;

            // Truy xuất thông tin phòng ban từ context
            var department = context.Departments
                .Where(d => d.DepartmentId == employee.DepartmentId)
                .Select(d => new
                {
                    d.DepartmentName,
                    Manager = context.Employees
                        .Where(e => e.EmployeeId == d.ManagerId)
                        .Select(e => $"{e.FirstName} {e.LastName}")
                        .FirstOrDefault() ?? "No Manager",
                    Location = context.Locations
                        .Where(l => l.LocationId == d.LocationId)
                        .Select(l => $"{l.City}, {l.StateProvince}")
                        .FirstOrDefault() ?? "No Location"
                }).FirstOrDefault();

            // Hiển thị thông tin trên giao diện người dùng
            if (department != null)
            {
                tbDepartmentName1.Text = department.DepartmentName ?? "No Department Name";
                tbManagerName.Text = department.Manager;
                tbLocationName.Text = department.Location;
            }
            else
            {
                tbDepartmentName1.Text = "No Department Data";
                tbManagerName.Text = "No Manager Data";
                tbLocationName.Text = "No Location Data";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayUserInfo();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
