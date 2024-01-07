using Microsoft.EntityFrameworkCore;
using nhmatsumoto.financial.domain.Entities;
using nhmatsumoto.financial.infrastructure.database.Context;
using nhmatsumoto.financial.infrastructure.database.Tables;
using NHMatsumoto.Financial.Domain.Exceptions;

namespace NHMatsumoto.Financial.Infrastructure.Database.Repository
{
    public class WalletRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<WalletTable> _dbSet;

        public WalletRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<WalletTable>();
        }

        public async Task<WalletTable> GetFullWalletInfo(int id)
        {
            var wallet = await _dbSet.Where(x => x.Id == id)
             .Select(w => new 
             {
                 Wallet = w,
                 Costs = _dbContext.Costs.Where(e => e.WalletId == w.Id).ToList()
             })
             .FirstOrDefaultAsync();

            if(wallet is null)
            {
                throw new ApiException(404, "Nenhum registro foi encontrado");
            }

            return new WalletTable
            {
                Id = wallet.Wallet.Id,
                Name = wallet.Wallet.Name,
                Email = wallet.Wallet.Email,
                Costs = wallet.Costs
            };
        }
    }
}
