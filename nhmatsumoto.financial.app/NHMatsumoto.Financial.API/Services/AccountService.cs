using AutoMapper;
using Microsoft.AspNetCore.Identity;
using nhmatsumoto.financial.api.Context.Interfaces;
using nhmatsumoto.financial.api.Context.Tables;
using nhmatsumoto.financial.api.Domain.Entities;
using nhmatsumoto.financial.api.Services.Interfaces;
using System.Linq.Expressions;
using System.Security.Claims;

namespace nhmatsumoto.financial.api.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<AccountTable> _accountRepository;
        private readonly IRepository<CostTable> _costRepository;
        private readonly UserManager<AppUser> _userManager;

        public AccountService(IRepository<AccountTable> accountRepository, 
            IRepository<CostTable> costRepository,
            UserManager<AppUser> userManager)
        {
            _accountRepository = accountRepository;
            _costRepository = costRepository;
            _userManager = userManager;
        }

        public async Task AddAccount(AccountTable account)
        {
            var user = await _userManager.GetUserAsync(ClaimsPrincipal.Current);
            
            if(user is not null)
            {
                account.UserCreated = user.GetHashCode();

                await _accountRepository.Add(account);

            }
           
            throw new Exception("Usuário não encontrado");
        }

        public async Task UpdateAccount(AccountTable account)
        {
            await _accountRepository.Update(account);
        }

        public async Task DeleteAccount(AccountTable account)
        {
            await _accountRepository.Remove(account);
        }

        public AccountTable GetAccount(int id)
        {
            //Map para DTO
            var account = _accountRepository.GetById(id);
            var costs = _costRepository
                .GetByExpression(x => x.AccountTableId == account.Id)
                .FirstOrDefault();

            account.Balance = account.Balance - costs.Value;

            account.Costs.Add(costs);

            return account;
        }

        public IEnumerable<AccountTable> GetAccounts()
        {
            return _accountRepository.GetAll().ToList();
        }

        public IEnumerable<AccountTable> GetAccounts(Expression<Func<AccountTable, bool>> predicate)
        {
            return _accountRepository.GetByExpression(predicate);
        }

    }
}
