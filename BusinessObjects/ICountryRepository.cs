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
    public interface ICountryRepository
    {
        public List<Country> GetCountries();
        public void UpdateCountry(Country country);
        public void DeleteCountry(Country country);
        public void AddCountry(Country country);
        public List<Country> GetCountriesByCountryId(string countryId);
        public List<Country> GetCountriesByCountryName(string countryName);
        public List<Country> GetCountriesByRegionName(string regionName);
        public List<Country> GetCountriesByRegionId(int regionId);
    }
}
