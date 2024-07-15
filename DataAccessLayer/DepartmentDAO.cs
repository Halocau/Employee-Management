using BusinessObjects.BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DepartmentDAO
    {
        private static DepartmentDAO instance = null;
        private static readonly object instanceLock = new object();
        public static DepartmentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new DepartmentDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Department> GetDepartments()
        {
            var departments = new List<Department>();
            try
            {
                using var context = new EmployeeManagementContext();
                departments = context.Departments.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return departments;
        }

        public Department GetDepartmentByID(int id)
        {
            Department department = null;
            try
            {
                using var context = new EmployeeManagementContext();
                department = context.Departments.FirstOrDefault(x => x.DepartmentId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return department;
        }

        public IEnumerable<Employee> GetEmployeesByDepartmentId(int departmentId)
        {
            var employees = new List<Employee>();
            try
            {
                using var context = new EmployeeManagementContext();
                employees = context.Employees
                                    .Include(e => e.Department)
                                    .Include(e => e.Job)
                                    .Include(e => e.Manager)
                                    .Where(e => e.DepartmentId == departmentId)
                                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return employees;
        }

        public void InsertDepartment(Department department)
        {
            try
            {
                Department existingDepartment = GetDepartmentByID(department.DepartmentId);
                if (existingDepartment == null)
                {
                    using var context = new EmployeeManagementContext();
                    context.Departments.Add(department);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The department already exists");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateDepartment(Department department)
        {
            try
            {
                Department existingDepartment = GetDepartmentByID(department.DepartmentId);
                if (existingDepartment != null)
                {
                    using var context = new EmployeeManagementContext();
                    context.Departments.Update(department);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The department does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteDepartment(int departmentID)
        {
            try
            {
                Department existingDepartment = GetDepartmentByID(departmentID);
                if (existingDepartment != null)
                {
                    using var context = new EmployeeManagementContext();
                    context.Departments.Remove(existingDepartment);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The department does not exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}