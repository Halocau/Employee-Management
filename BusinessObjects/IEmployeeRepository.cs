using BusinessObjects.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByID(int id);
        IEnumerable<Employee> GetEmployeeByName(string name);
        void DeleteEmployee(int empID);
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
    }
}
