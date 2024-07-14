
using BusinessObjects.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AccountMemberDAO
    {
        private static AccountMemberDAO instance = null;
        private static readonly object instanceLock = new object();
        public static AccountMemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountMemberDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<AccountMember> GetAccountList()
        {
            var members = new List<AccountMember>();
            try
            {
                using var context = new EmployeeManagementContext();
                context.AccountMembers.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return members;
        }
        public AccountMember GetAccountMemberByID(int accountId)
        {
            AccountMember accountMember = null;
            try
            {
                using var context = new EmployeeManagementContext();
                accountMember = context.AccountMembers.FirstOrDefault(x => x.MemberId == accountId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return accountMember;
        }
        public void AddNew(AccountMember member)
        {
            try
            {
                AccountMember acc = GetAccountMemberByID(member.MemberId);
                if (acc == null)
                {
                    using var context = new EmployeeManagementContext();
                    context.AccountMembers.Add(member);
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
        public void Update(AccountMember member)
        {
            try
            {
                AccountMember acc = GetAccountMemberByID(member.MemberId);
                if (acc != null)
                {
                    using var context = new EmployeeManagementContext();
                    context.AccountMembers.Update(member);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int accountid)
        {
            try
            {
                AccountMember acc = GetAccountMemberByID(accountid);
                if (acc != null)
                {
                    using var context = new EmployeeManagementContext();
                    context.AccountMembers.Remove(acc);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public AccountMember GetMemberByEmail(string email)
        {
            AccountMember acc = null;
            try
            {
                using var context = new EmployeeManagementContext();
                acc = context.AccountMembers.FirstOrDefault(m => m.EmailAddress.Equals(email));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }
        public AccountMember GetMemberByEmailAndPassword(string email, string password)
        {
            AccountMember acc = null;
            try
            {
                using var context = new EmployeeManagementContext();
               acc = context.AccountMembers.FirstOrDefault(m => m.EmailAddress.Equals(email) && m.MemberPassword.Equals(password));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return acc;
        }
    }
}