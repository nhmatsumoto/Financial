using Microsoft.AspNetCore.Mvc.RazorPages;
using nhmatsumoto.financial.infrastructure.database.Tables;
using nhmatsumoto.financial.services.Interfaces;
using NHMatsumoto.Financial.Domain.Exceptions;

namespace nhmatsumoto.financial.presentation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWalletService _walletService;

        public string Message { get; set; }
        public List<WalletTable> Wallets { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IWalletService walletService)
        {
            _logger = logger ?? throw new ApiException(500, "Serviço indisponível");
            _walletService = walletService ?? throw new ApiException(500, "Serviço indisponível");
        }

        public void OnGet()
        {
            Message = "Listagem de carteiras";

            Wallets = _walletService.GetWallets();

            if(Wallets is null)
            {
                throw new ApiException(404, "Nenhum item encontrado");
            }

        }
    }
}
