﻿ using BusinessObjects.BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AccountMemberRepository : IAccountMemberRepository
    {
        public AccountMember CheckAccount(string email, string password) => AccountMemberDAO.Instance.GetMemberByEmailAndPassword(email, password);


        public void DeleteAccountMember(int accountid)
        {
            AccountMemberDAO.Instance.Delete(accountid);
        }

        public AccountMember GetAccountMemberByID(int accountid) => AccountMemberDAO.Instance.GetAccountMemberByID(accountid);


        public AccountMember GetAccountMemberByEmail(string email) => AccountMemberDAO.Instance.GetMemberByEmail(email);


        public IEnumerable<AccountMember> GetAccountMembers() => AccountMemberDAO.Instance.GetAccountList();


        public void InsertAccountMember(AccountMember member) => AccountMemberDAO.Instance.AddNew(member);


        public void UpdateAccountMember(AccountMember member) => AccountMemberDAO.Instance.Update(member);

        public AccountMember GetAccountWithDetails(string username, string password)
        {
            using (var context = new EmployeeManagementContext())
            {
                var accountMember = context.AccountMembers
                    .Where(am => am.FullName == username && am.MemberPassword == password)
                    .Select(am => new AccountMember
                    {
                        MemberId = am.MemberId,
                        FullName = am.FullName,
                        EmailAddress = am.EmailAddress,
                        MemberRole = am.MemberRole,
                        EmployeeId = am.EmployeeId,
                        // Join với bảng Employees để lấy thông tin chi tiết
                        Employee = context.Employees
                            .Where(emp => emp.EmployeeId == am.EmployeeId)
                            .Select(emp => new Employee
                            {
                                EmployeeId = emp.EmployeeId,
                                FirstName = emp.FirstName,
                                LastName = emp.LastName,
                                Email = emp.Email,
                                Phone = emp.Phone,
                                HireDate = emp.HireDate,
                                JobId = emp.Job.JobTitle,
                                Salary = emp.Salary,
                                CommissionPct = emp.CommissionPct,
                                ManagerId = emp.ManagerId,
                                DepartmentId = emp.DepartmentId,
                                // Join với bảng Departments để lấy thông tin phòng ban
                                Department = context.Departments
                                    .Where(d => d.DepartmentId == emp.DepartmentId)
                                    .Select(d => new Department
                                    {
                                        DepartmentId = d.DepartmentId,
                                        DepartmentName = d.DepartmentName,
                                        ManagerId = d.ManagerId,
                                        LocationId = d.LocationId,
                                        // Join với bảng Locations để lấy thông tin địa điểm
                                        Location = context.Locations
                                            .Where(l => l.LocationId == d.LocationId)
                                            .Select(l => new Location
                                            {
                                                LocationId = l.LocationId,
                                                StreetAddress = l.StreetAddress,
                                                PostalCode = l.PostalCode,
                                                City = l.City,
                                                StateProvince = l.StateProvince,
                                                CountryId = l.CountryId,
                                            }).FirstOrDefault()
                                    }).FirstOrDefault()
                            }).FirstOrDefault()
                    }).FirstOrDefault();

                return accountMember;
            }
        }

    }
}
