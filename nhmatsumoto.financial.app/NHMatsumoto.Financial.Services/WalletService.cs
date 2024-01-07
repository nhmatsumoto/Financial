using Microsoft.AspNetCore.Identity;
using nhmatsumoto.financial.domain.Entities;
using nhmatsumoto.financial.infrastructure.database.Interfaces;
using nhmatsumoto.financial.infrastructure.database.Tables;
using nhmatsumoto.financial.services.Interfaces;
using NHMatsumoto.Financial.Domain.Exceptions;
using System.Linq;
using System.Linq.Expressions;

namespace nhmatsumoto.financial.services
{
    public class WalletService : IWalletService
    {
        private readonly IRepository<WalletTable> _walletRepository;
        private readonly IRepository<CostTable> _costRepository;
        private readonly UserManager<AppUser> _userManager;

        public WalletService(IRepository<WalletTable> accountRepository,
            IRepository<CostTable> costRepository,
            UserManager<AppUser> userManager)
        {
            _walletRepository = accountRepository;
            _costRepository = costRepository;
            _userManager = userManager;
        }

        public async Task AddWallet(WalletTable Wallet)
        {
            await _walletRepository.Add(Wallet);
        }

        public async Task UpdateWallet(WalletTable Wallet)
        {
            await _walletRepository.Update(Wallet);
        }

        public async Task DeleteWallet(WalletTable Wallet)
        {
            await _walletRepository.Remove(Wallet);
        }

        public WalletTable GetWallet(int id)
        {
            //Map para DTO
            var wallet = _walletRepository.GetById(id);

            if(wallet is null)
            {
                throw new ApiException(404, "Esta carteira não existe");
            }

            var costs = _costRepository
                .GetByExpression(x => x.WalletId == wallet.Id).ToList();

            if(costs.Any())
            {
                wallet.Costs = costs;
            }

            return wallet;
        }

        public List<WalletTable> GetWallets()
        {
            return _walletRepository.GetAll().ToList();
        }

        public List<WalletTable> GetByExpression(Expression<Func<WalletTable, bool>> predicate)
        {
            return _walletRepository.GetByExpression(predicate).ToList();
        }

    }
}
