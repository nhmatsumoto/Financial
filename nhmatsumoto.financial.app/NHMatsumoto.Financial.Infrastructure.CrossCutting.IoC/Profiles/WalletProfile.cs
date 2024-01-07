using AutoMapper;
using nhmatsumoto.financial.infrastructure.database.Tables;

namespace NHMatsumoto.Financial.Infrastructure.CrossCutting.IoC.Profiles
{
    public class WalletProfile : Profile
    {
        public WalletProfile()
        {
            CreateMap<WalletTable, CreateWallet>().ReverseMap();
            
        }
    }
}
