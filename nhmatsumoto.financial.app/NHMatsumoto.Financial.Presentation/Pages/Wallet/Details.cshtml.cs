using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nhmatsumoto.financial.infrastructure.database.Tables;
using nhmatsumoto.financial.services.Interfaces;


namespace NHMatsumoto.Financial.Presentation.Pages.Wallet
{
    public class DetailsModel : PageModel
    {
        private readonly IWalletService _walletService;

        [BindProperty]
        public WalletTable WalletTable { get; set; } = default!;

        public DetailsModel(IWalletService walletService)
        {
            _walletService = walletService;
        }

        public IActionResult OnGet(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            WalletTable = _walletService.GetWallet(id);

            if (WalletTable == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
