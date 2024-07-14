using BusinessObjects.BusinessObjects;
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

    }
}
