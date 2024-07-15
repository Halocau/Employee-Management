using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessObjects.BusinessObjects;

namespace DataAccessLayer
{
    public static class RegionDAO
    {
        public static List<Region> GetRegions()
        {
            List<Region> regions = new List<Region>();
            EmployeeManagementContext employeeManagementContext = new EmployeeManagementContext();
            regions = employeeManagementContext.Regions.ToList();
            return regions;
        }

        public static void AddRegion(Region region)
        {
            EmployeeManagementContext employeeManagementContext = new EmployeeManagementContext();
            employeeManagementContext.Regions.Add(region);
            employeeManagementContext.SaveChanges();
        }
        public static void DeleteRegion(Region region) {
            EmployeeManagementContext employeeManagementContext = new EmployeeManagementContext();
            employeeManagementContext.Regions.Remove(region);
            employeeManagementContext.SaveChanges();
        }
        public static void UpdateRegion(Region region)
        {
            EmployeeManagementContext employeeManagementContext = new EmployeeManagementContext();
            Region regionToUpdate = employeeManagementContext.Regions.Find(region.RegionId);
            regionToUpdate.RegionName = region.RegionName;
            employeeManagementContext.SaveChanges();
        }
        public static List<Region> GetRegionsByRegionId(int regionId)
        {
            List<Region> regions = GetRegions();
            List<Region> regionsByRegionId = regions.FindAll(r => r.RegionId == regionId);
            return regionsByRegionId;
        }
        public static List<Region> GetRegionsByRegionName(string regionName)
        {
            List<Region> regions = GetRegions();
            List<Region> regionsByRegionName = regions.FindAll(r => r.RegionName == regionName);
            return regionsByRegionName;
        }
    }
}
