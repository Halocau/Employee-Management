
using BusinessObjects.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IAccountMemberRepository
    {
        AccountMember GetAccountWithDetails(string username, string password);
        IEnumerable<AccountMember> GetAccountMembers();
        AccountMember GetAccountMemberByID(int accountid);
        void InsertAccountMember(AccountMember member);
        void UpdateAccountMember(AccountMember member);
        void DeleteAccountMember(int accountid);
        AccountMember GetAccountMemberByEmail(string email);
        AccountMember? CheckAccount(string email,string password);
    }
}
