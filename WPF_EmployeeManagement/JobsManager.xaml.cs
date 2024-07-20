using BusinessObjects.BusinessObjects;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for JobsManager.xaml
    /// </summary>
    public partial class JobsManager : Window
    {
        private readonly EmployeeManagementContext context;
        public JobsManager()
        {
            context = new EmployeeManagementContext();
            InitializeComponent();
        }
        public void LoadData()
        {
            lvJob.ItemsSource = context.Jobs.ToList();
        }
      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        public Job GetJob()
        {
            Job job = new Job();
            job.JobId = tbJobID.Text;
            job.JobTitle = tbJobTitle.Text;
            job.MinSalary = int.Parse(tbMinSalary.Text);
            job.MaxSalary = int.Parse(tbMaxSalary.Text);
            return job;
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            tbJobID.Clear();
            tbJobTitle.Clear();
            tbMaxSalary.Clear();
            tbMinSalary.Clear();
            LoadData();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var job = GetJob();
             
                context.Jobs.Add(job);
                context.SaveChanges();
                LoadData();
                MessageBox.Show("Job added successfully", "Notification");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Job job = GetJob();
                var oldId =  context.Jobs.FirstOrDefault(x => x.JobId.Equals(job.JobId));
                if (oldId != null)
                {
                    
                    oldId.JobTitle = job.JobTitle;
                    oldId.MinSalary = job.MinSalary;
                    oldId.MaxSalary = job.MaxSalary;
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show("Job edit successfully", "Notification");
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string jobId = tbJobID.Text;
                var oldID = context.Jobs.FirstOrDefault(x => x.JobId.Equals(jobId));
                context.Database.ExecuteSqlRaw($"UPDATE [dbo].[Employees] SET JobID = NULL WHERE JobID = '{jobId}'" +
                    $"\r\nDELETE FROM dbo.Jobs WHERE JobID = '{jobId}'");
                context.SaveChanges();
                LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void lvJob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvJob.SelectedItem is Job selectedJob)
            {
                tbJobID.Text = selectedJob.JobId;
                tbJobTitle.Text = selectedJob.JobTitle;
                tbMinSalary.Text = selectedJob.MinSalary.ToString();
                tbMaxSalary.Text = selectedJob.MaxSalary.ToString();
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Lấy giá trị từ các TextBox
                if (int.TryParse(tbMin.Text, out int minSalary) && int.TryParse(tbMax.Text, out int maxSalary))
                {
                    var filteredJobs = context.Jobs
                        .Where(job => job.MinSalary >= minSalary && job.MaxSalary <= maxSalary)
                        .ToList();

                    lvJob.ItemsSource = filteredJobs;
                }
                else
                {
                    MessageBox.Show("Please enter valid salary values.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

    }
}
