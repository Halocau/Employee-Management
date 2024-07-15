using BusinessObjects.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartmentById(int id);
        IEnumerable<Employee> GetEmployeesByDepartmentId(int departmentId);
        void InsertDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int departmentId);
    }
}
