using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessObjects.BusinessObjects;

namespace DataAccessLayer
{
    public class CountryDAO
    {
        public static List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>();
            EmployeeManagementContext employeeManagementContext = new EmployeeManagementContext();
            countries = employeeManagementContext.Countries.ToList();
            return countries;
        }
        public static void UpdateCountry(Country country)
        {
            EmployeeManagementContext employeeManagementContext = new EmployeeManagementContext();
            Country countryToUpdate = employeeManagementContext.Countries.Find(country.CountryId);
            countryToUpdate.CountryName = country.CountryName;
            countryToUpdate.RegionId = country.RegionId;
            employeeManagementContext.SaveChanges();
        }
        public static void DeleteCountry(Country country)
        {
            EmployeeManagementContext employeeManagementContext = new EmployeeManagementContext();
            employeeManagementContext.Countries.Remove(country);
            employeeManagementContext.SaveChanges();
        }
        public static void AddCountry(Country country)
        {
            EmployeeManagementContext employeeManagementContext = new EmployeeManagementContext();
            employeeManagementContext.Countries.Add(country);
            employeeManagementContext.SaveChanges();
        }
        public static List<Country> GetCountriesByCountryId(string countryId)
        {
            List<Country> countries = GetCountries();
            List<Country> countriesByCountryId = countries.FindAll(c => c.CountryId == countryId);
            return countriesByCountryId;
        }
        public static List<Country> GetCountriesByCountryName(string countryName)
        {
            List<Country> countries = GetCountries();
            List<Country> countriesByCountryName = countries.FindAll(c => c.CountryName == countryName);
            return countriesByCountryName;
        }
        public static List<Country> GetCountriesByRegionName(string regionName)
        {
            List<Country> countries = GetCountries();
            List<Country> countriesByRegionName = countries.FindAll(c => c.Region?.RegionName == regionName);
            return countriesByRegionName;
        }
        public static List<Country> GetCountriesByRegionId(int regionId)
        {
            List<Country> countries = GetCountries();
            List<Country> countriesByRegionId = countries.FindAll(c => c.RegionId == regionId);
            return countriesByRegionId;
        }
    }
}
