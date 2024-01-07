using AutoMapper;
using nhmatsumoto.financial.services.Interfaces;
using NHMatsumoto.Financial.Application.Interfaces;

namespace NHMatsumoto.Financial.Application.Services
{
    public class WalletApplicationService : IWalletApplicationService
    {
        private readonly IWalletService _walletService;
        private readonly IMapper _mapper;

        public WalletApplicationService(IWalletService walletService, IMapper mapper)
        {
            _walletService = walletService;
            _mapper = mapper;
        }
    }
}
