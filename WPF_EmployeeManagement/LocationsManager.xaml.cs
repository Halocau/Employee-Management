using BusinessObjects.BusinessObjects;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for LocationsManager.xaml
    /// </summary>
    public partial class LocationsManager : Window
    {
        private readonly EmployeeManagementContext context;
        public LocationsManager()
        {
            context = new EmployeeManagementContext();
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public Location GetLocation()
        {
            Location location = new Location();
            location.LocationId = tbLocationID.Text;
            location.StreetAddress = tbStreetAddress.Text;
            location.PostalCode = tbPostalCode.Text;
            location.City = tbCity.Text;
            location.StateProvince = tbStateProvince.Text;
            location.CountryId = cbCountryName.SelectedValue.ToString();
            return location;
        }
        public void LoadData()
        {
            lvLocation.ItemsSource = context.Locations.Include(x=> x.Country).ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbCity.ItemsSource = context.Locations.ToList();
            cbCity.DisplayMemberPath = "City";

            cbName.ItemsSource = context.Countries.ToList();
            cbName.DisplayMemberPath = "CountryName";
            cbName.SelectedValuePath = "CountryId";

            cbCountryName.ItemsSource = context.Countries.ToList();
            cbCountryName.DisplayMemberPath = "CountryName";
            cbCountryName.SelectedValuePath = "CountryId";
            LoadData();
        }

        private void lvLocation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvLocation.SelectedItem is Location selectedLocation)
            {
                tbLocationID.Text = selectedLocation.LocationId;
                tbStreetAddress.Text = selectedLocation.StreetAddress;
                tbPostalCode.Text = selectedLocation.PostalCode;
                tbCity.Text = selectedLocation.City;    
                tbStateProvince.Text = selectedLocation.StateProvince;
                cbCountryName.SelectedValue = selectedLocation.Country.CountryId;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            tbLocationID.Clear();
            tbStreetAddress.Clear();
            tbPostalCode.Clear();
            tbCity.Clear();
            tbStateProvince.Clear();
            cbCountryName.SelectedValue = null;
            cbCountryName.SelectedIndex = -1;
            cbName.SelectedValue = null;
            cbName.SelectedIndex = -1;
            cbCity.SelectedValue = null;
            cbCity.SelectedIndex = -1;

            lblCountCountryName.Visibility = Visibility.Collapsed;
            lblCountCountryName.Content = "Count: 0";
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Location location = GetLocation();
                context.Locations.Add(location);
                context.SaveChanges();
                LoadData();
                MessageBox.Show("Location added successfully", "Notification");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Location location = GetLocation();
                var oldId = context.Locations.FirstOrDefault(x => x.LocationId.Equals(location.LocationId));
                if(oldId != null)
                {
                    oldId.StreetAddress = location.StreetAddress;
                    oldId.PostalCode = location.PostalCode;
                    oldId.City = location.City;
                    oldId.StateProvince = location.StateProvince;
                    oldId.CountryId = location.CountryId;
                    context.SaveChanges();
                    LoadData();
                    MessageBox.Show("Location edit successfully", "Notification");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String id = tbLocationID.Text;
                var oldID = context.Locations.FirstOrDefault(x=> x.LocationId.Equals(id));
                context.Database.ExecuteSqlRaw($"UPDATE [dbo].[Departments] SET [LocationID] = NULL WHERE LocationID = '{id}'" +
                    $"\r\nDELETE FROM [dbo].[Locations] WHERE  LocationID = '{id}'");
                context.SaveChanges();
                LoadData() ;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void cbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCity.SelectedItem is Location selectedCity)
            {
                lvLocation.ItemsSource = context.Locations
                    .Include(x => x.Country)
                    .Where(x => x.City == selectedCity.City)
                    .ToList();
            }
            else
            {
                LoadData(); // Reload all data if no city is selected
            }
        }

        private void cbName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbName.SelectedValue != null)
            {
                string selectedCountryName = cbName.SelectedValue.ToString();
                var displayCbName =  context.Locations
                    .Include(x => x.Country)
                    .Where(x => x.Country.CountryId == selectedCountryName)
                    .ToList();
                lvLocation.ItemsSource = displayCbName;
                lblCountCountryName.Content = $"Count: {displayCbName.Count}";
                lblCountCountryName.Visibility = Visibility.Visible;
            }
            else
            {
                LoadData();
                lblCountCountryName.Visibility = Visibility.Collapsed;
            }
        }
    }
}
