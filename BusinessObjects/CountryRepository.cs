using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessObjects.BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public void AddCountry(Country country) => CountryDAO.AddCountry(country);

        public void DeleteCountry(Country country) => CountryDAO.DeleteCountry(country);

        public List<Country> GetCountries() => CountryDAO.GetCountries();

        public List<Country> GetCountriesByCountryId(string countryId) => CountryDAO.GetCountriesByCountryId(countryId); 

        public List<Country> GetCountriesByCountryName(string countryName) => CountryDAO.GetCountriesByCountryName(countryName);

        public List<Country> GetCountriesByRegionId(int regionId) => CountryDAO.GetCountriesByRegionId(regionId);

        public List<Country> GetCountriesByRegionName(string regionName) => CountryDAO.GetCountriesByRegionName(regionName);

        public void UpdateCountry(Country country) => CountryDAO.UpdateCountry(country);
    }
}
