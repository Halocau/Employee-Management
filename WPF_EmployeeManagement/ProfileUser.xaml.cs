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
    /// <summary>
    /// Interaction logic for ProfileUser.xaml
    /// </summary>
    public partial class ProfileUser : Window
    {
        private AccountMember accountMember;
        public ProfileUser(BusinessObjects.BusinessObjects.AccountMember accountMember)
        {
            InitializeComponent();
            this.accountMember = accountMember;
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeUser employeeUser = new EmployeeUser(accountMember);
            employeeUser.Show();
         
        }

        private void btnDepartments_Click(object sender, RoutedEventArgs e)
        {
            DepartmentUser departmentUser = new DepartmentUser(accountMember);
            departmentUser.Show();  


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();  
            login.Show();
            this.Close();
        }
    }
}
