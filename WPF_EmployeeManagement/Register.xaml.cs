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
using System.Text.RegularExpressions; // Thêm namespace này để sử dụng Regex
namespace WPF_EmployeeManagement
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private readonly IAccountMemberRepository iAccountMemberRepository;
        public Register()
        {
            InitializeComponent();
            iAccountMemberRepository = new AccountMemberRepository();
        }
        private void LoginTextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // Lấy thông tin từ các trường nhập liệu
                string email = tbEmail.Text.Trim();
                string password = tbPassword.Password.Trim();
                string fullname = tbName.Text.Trim();
                // Kiểm tra email có chứa '@'
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Please enter a valid email address.", "Error");
                    return;
                }
                // Kiểm tra độ dài và độ phức tạp của mật khẩu
                if (password.Length < 8 ||
                    !password.Any(char.IsUpper) ||
                    !password.Any(char.IsSymbol) && !password.Any(char.IsPunctuation))
                {
                    MessageBox.Show("Password must be at least 8 characters long, contain at least one uppercase letter, and one special character.");
                    return;
                }


                // Kiểm tra xem mật khẩu và xác nhận mật khẩu có khớp nhau không
                string confirmPassword = tbconfirm.Password.Trim();
                if (password != confirmPassword)
                {
                    MessageBox.Show("Password and Confirm Password do not match.");
                    return;
                }
                AccountMember checkEmailExits = iAccountMemberRepository.GetAccountMemberByEmail(email);
                if (checkEmailExits != null)
                {
                    MessageBox.Show("Email already exists. Please choose a different email.");
                    return;
                }
                AccountMember newAcc = new AccountMember()
                {
                    EmailAddress = email,
                    FullName = fullname,
                    MemberPassword = password,
                    MemberRole = 2,
                };
                //add database
                iAccountMemberRepository.InsertAccountMember(newAcc);
                // Thông báo đăng ký thành công
                MessageBox.Show("Registration successful!");

                // Đóng cửa sổ đăng ký và chuyển sang cửa sổ đăng nhập
                Login login = new Login();
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed: {ex.Message}");

            }
        }

        // Hàm kiểm tra email hợp lệ
        private bool IsValidEmail(string email)
        {
            try
            {
                // Sử dụng biểu thức chính quy để kiểm tra email
                var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
                return emailRegex.IsMatch(email);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}