using BusinessObjects.BusinessObjects;
using Repositories;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IAccountMemberRepository iAccountMemberRepository;

        public Login()
        {
            InitializeComponent();
            iAccountMemberRepository = new AccountMemberRepository();
        }

        private void SignUpTextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Register registerWindow = new Register();
            registerWindow.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbUserName.Text) || string.IsNullOrEmpty(tbPassword.Password))
                {
                    MessageBox.Show("Username or password cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var accountRepository = new AccountMemberRepository();
                AccountMember account = accountRepository.CheckAccount(tbUserName.Text, tbPassword.Password);

                if (account != null)
                {
                    // Kiểm tra vai trò của tài khoản
                    if (account.MemberRole == 1)
                    {
                        // Nếu MemberRole là 1, chỉ cần kiểm tra tài khoản
                        MessageBoxResult result = MessageBox.Show("Login successful!", "Success", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                        if (result == MessageBoxResult.OK)
                        {
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                        }
                        else if (result == MessageBoxResult.Cancel)
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        // Nếu MemberRole không phải 1, lấy chi tiết tài khoản và kiểm tra
                        AccountMember accountMember = accountRepository.GetAccountWithDetails(account.FullName, tbPassword.Password);
                        if (accountMember != null)
                        {
                            ProfileUser profileUser = new ProfileUser(accountMember);
                            profileUser.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to retrieve account details.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Your account and password are not correct!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
