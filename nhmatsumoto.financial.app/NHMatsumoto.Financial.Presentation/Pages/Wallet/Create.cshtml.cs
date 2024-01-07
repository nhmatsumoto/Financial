using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nhmatsumoto.financial.infrastructure.database.Tables;
using nhmatsumoto.financial.services.Interfaces;

namespace NHMatsumoto.Financial.Presentation.Pages.Wallet
{
    public class CreateModel : PageModel
    {
        private readonly IWalletService _walletService;


        public CreateModel(IWalletService walletService)
        {
            _walletService = walletService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WalletTable WalletTable { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            await _walletService.AddWallet(WalletTable);
            return RedirectToPage("/Index");

        }
    }
}
