using nhmatsumoto.financial.api.Context.Tables;
using System.Linq.Expressions;

namespace nhmatsumoto.financial.api.Services.Interfaces
{
    public interface IAccountService
    {
        Task AddAccount(AccountTable account);
        Task UpdateAccount(AccountTable account);
        Task DeleteAccount(AccountTable account);
        AccountTable GetAccount(int id);
        IEnumerable<AccountTable> GetAccounts();
        IEnumerable<AccountTable> GetAccounts(Expression<Func<AccountTable, bool>> predicate);
    }
}
