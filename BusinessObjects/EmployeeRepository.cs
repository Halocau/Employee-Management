using BusinessObjects.BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void DeleteEmployee(int empID)
        {
            EmployeeDAO.Instance.DeleteEmployee(empID);
        }

        public Employee GetEmployeeByID(int id)
        {
            return EmployeeDAO.Instance.GetEmployeeByID(id);
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
        {
            return EmployeeDAO.Instance.GetEmployeeByName(name);
        }

        public IEnumerable<Employee> GetEmployees() => EmployeeDAO.Instance.GetEmployees();


        public void InsertEmployee(Employee employee)
        {
            EmployeeDAO.Instance.InsertEmployee(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            EmployeeDAO.Instance.UpdateEmployee(employee);
        }
    }
}
