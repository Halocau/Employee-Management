using BusinessObjects.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance = null;
        private static readonly object instanceLock = new object();
        public static EmployeeDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            var employ = new List<Employee>();
            try
            {
                using var context = new EmployeeManagementContext();
                employ = context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return employ;
        }
        public IEnumerable<Employee> GetEmployeeByName(string name)
        {
            IEnumerable<Employee> employees = null;
            try
            {
                name = name.ToLower();
                using var context = new EmployeeManagementContext();
                employees = context.Employees
                                    .Include(x => x.Job) // Include Job entity
                                    .Include(x => x.Department) // Include Department entity
                                    .Include(x => x.Manager) // Include Manager entity
                                    .AsEnumerable() // Chuyển đổi sang IEnumerable để thực hiện tìm kiếm trong bộ nhớ
                                    .Where(x => $"{x.FirstName.ToLower()} {x.LastName.ToLower()}".Contains(name))
                                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return employees;
        }

        public Employee GetEmployeeByID(int id)
        {
            Employee employ = null;
            try
            {
                using var context = new EmployeeManagementContext();
                employ = context.Employees.FirstOrDefault(x => x.EmployeeId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return employ;
        }
        public void InsertEmployee(Employee emp)
        {
            try
            {
                Employee employ = GetEmployeeByID(emp.EmployeeId);
                if (employ == null)
                {
                    using var context = new EmployeeManagementContext();
                    context.Employees.Add(employ);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member is already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateEmployee(Employee emp)
        {
            try
            {
                Employee employ = GetEmployeeByID(emp.EmployeeId);
                if (employ == null)
                {
                    using var context = new EmployeeManagementContext();
                    context.Employees.Update(employ);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteEmployee(int empID)
        {
            try
            {
                Employee employ = GetEmployeeByID(empID);
                if (employ != null)
                {
                    using var context = new EmployeeManagementContext();
                    context.Employees.Remove(employ);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
