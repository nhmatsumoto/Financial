using Microsoft.AspNetCore.Identity;

namespace nhmatsumoto.financial.domain.Entities
{
    public class AppUser : IdentityUser
    {
        //CNPJ
        public string Document { get; set; }
        public Guid WalletId { get; set; }
    }
}
