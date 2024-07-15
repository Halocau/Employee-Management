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
using BusinessObjects.BusinessObjects;
using Repositories;
namespace WPF_EmployeeManagement
{
    /// <summary>
    /// Interaction logic for RegionandCountry.xaml
    /// </summary>
    public partial class RegionandCountry : Window
    {
        private readonly ICountryRepository iCountryService;
        private readonly IRegionRepository iRegionService;
        public RegionandCountry()
        {
            iCountryService = new CountryRepository();
            iRegionService = new RegionRepository();
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            CountryDataGrid.ItemsSource = iCountryService.GetCountries();
            RegionDataGrid.ItemsSource = iRegionService.GetRegions();
            Tables.ItemsSource = new string[] { "Country", "Region" };
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Tables.SelectedItem)
            {
                case "Country":
                    if (CountryDataGrid.SelectedItem is Country country)
                    {
                        CountryDataGrid.Visibility = Visibility.Visible;
                        RegionDataGrid.Visibility = Visibility.Collapsed;
                        ID_TextBox.Text = country.CountryId.ToString();
                        Name_TextBox.Text = country.CountryName;
                        TextBox_3.Text = country.RegionId.ToString();
                        TextBox_3.Visibility = Visibility.Visible;
                    }
                    break;

                case "Region":
                    if (RegionDataGrid.SelectedItem is Region region)
                    {
                        CountryDataGrid.Visibility = Visibility.Collapsed;
                        RegionDataGrid.Visibility = Visibility.Visible;
                        ID_TextBox.Text = region.RegionId.ToString();
                        Name_TextBox.Text = region.RegionName;
                        TextBox_3.Visibility = Visibility.Collapsed;
                    }
                    break;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Tables.SelectedItem)
            {
                case "Country":
                    CountryDataGrid.Visibility = Visibility.Visible;

                    RegionDataGrid.Visibility = Visibility.Collapsed;
                    ID_Label.Content = "Country ID";
                    ID_TextBox.IsReadOnly = false;
                    Name_Label.Content = "Country Name";
                    Label_3.Content = "Region ID";
                    Label_3.Visibility = Visibility.Visible;
                    TextBox_3.Visibility = Visibility.Visible;
                    break;
                case "Region":
                    CountryDataGrid.Visibility = Visibility.Collapsed;

                    RegionDataGrid.Visibility = Visibility.Visible;
                    ID_Label.Content = "Region ID";
                    ID_TextBox.IsReadOnly = true;
                    Name_Label.Content = "Region Name";
                    Label_3.Visibility = Visibility.Collapsed;
                    TextBox_3.Visibility = Visibility.Collapsed;
                    break;
            }
            Refresh();
        }

        private void Create_Button_Click(object sender, RoutedEventArgs e)
        {
            switch (Tables.SelectedItem)
            {
                case "Country":
                    iCountryService.AddCountry(new Country
                    {
                        CountryId = ID_TextBox.Text,
                        CountryName = Name_TextBox.Text,
                        RegionId = int.Parse(TextBox_3.Text)
                    });
                    break;
                case "Region":
                    iRegionService.AddRegion(new Region
                    {
                        RegionId = iRegionService.GetRegions().Count + 1,
                        RegionName = Name_TextBox.Text
                    });
                    break;
            }
            Refresh();
        }
        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            switch (Tables.SelectedItem)
            {
                case "Country":
                    iCountryService.UpdateCountry(new Country
                    {
                        CountryId = ID_TextBox.Text,
                        CountryName = Name_TextBox.Text,
                        RegionId = int.Parse(TextBox_3.Text)
                    });
                    break;
                case "Region":
                    iRegionService.UpdateRegion(new Region
                    {
                        RegionId = int.Parse(ID_TextBox.Text),
                        RegionName = Name_TextBox.Text
                    });
                    break;
            }
            Refresh();
        }
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            switch (Tables.SelectedItem)
            {
                case "Country":
                    iCountryService.DeleteCountry(new Country
                    {
                        CountryId = ID_TextBox.Text,
                        CountryName = Name_TextBox.Text,
                        RegionId = int.Parse(TextBox_3.Text)
                    });
                    break;
                case "Region":
                    iRegionService.DeleteRegion(new Region
                    {
                        RegionId = int.Parse(ID_TextBox.Text),
                        RegionName = Name_TextBox.Text
                    });

                    break;
            }
            Refresh();
        }
        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            ID_TextBox.Text = "";
            Name_TextBox.Text = "";
            TextBox_3.Text = "";
            CountryDataGrid.ItemsSource = iCountryService.GetCountries();
            RegionDataGrid.ItemsSource = iRegionService.GetRegions();
        }
    }

}
