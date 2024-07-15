using BusinessObjects.BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public void DeleteDepartment(int departmentId)
        {
            DepartmentDAO.Instance.DeleteDepartment(departmentId);
        }

        public Department GetDepartmentById(int id)
        {
            return DepartmentDAO.Instance.GetDepartmentByID(id);
        }

        public IEnumerable<Department> GetDepartments() => DepartmentDAO.Instance.GetDepartments();


        public IEnumerable<Employee> GetEmployeesByDepartmentId(int departmentId)
        {
            return DepartmentDAO.Instance.GetEmployeesByDepartmentId(departmentId);
        }

        public void InsertDepartment(Department department)
        {
            DepartmentDAO.Instance.InsertDepartment(department);
        }

        public void UpdateDepartment(Department department)
        {
            DepartmentDAO.Instance.UpdateDepartment(department);
        }
    }
}
