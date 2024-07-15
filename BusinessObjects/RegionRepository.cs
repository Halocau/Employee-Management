using BusinessObjects;
using BusinessObjects.BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RegionRepository : IRegionRepository
    {
        public void AddRegion(Region region) => RegionDAO.AddRegion(region);

        public void DeleteRegion(Region region) => RegionDAO.DeleteRegion(region);

        public List<Region> GetRegions() => RegionDAO.GetRegions();

        public List<Region> GetRegionsByRegionId(int regionId) => RegionDAO.GetRegionsByRegionId(regionId);

        public List<Region> GetRegionsByRegionName(string regionName) => RegionDAO.GetRegionsByRegionName(regionName);

        public void UpdateRegion(Region region) => RegionDAO.UpdateRegion(region);
    }
}
