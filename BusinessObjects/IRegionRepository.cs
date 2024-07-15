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
    public interface IRegionRepository
    {
        public List<Region> GetRegions();
        public void UpdateRegion(Region region);
        public void DeleteRegion(Region region);
        public void AddRegion(Region region);
        public List<Region> GetRegionsByRegionId(int regionId);
        public List<Region> GetRegionsByRegionName(string regionName);
    }
}
