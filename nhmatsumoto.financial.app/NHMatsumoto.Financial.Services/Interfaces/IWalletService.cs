using nhmatsumoto.financial.infrastructure.database.Tables;
using System.Linq.Expressions;

namespace nhmatsumoto.financial.services.Interfaces
{
    public interface IWalletService
    {
        Task AddWallet(WalletTable account);
        Task UpdateWallet(WalletTable account);
        Task DeleteWallet(WalletTable account);
        WalletTable GetWallet(int id);
        List<WalletTable> GetWallets();
        List<WalletTable> GetByExpression(Expression<Func<WalletTable, bool>> predicate);
    }
}
