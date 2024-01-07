using Microsoft.AspNetCore.Identity;
using nhmatsumoto.financial.api.Domain.Enums;

namespace nhmatsumoto.financial.api.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        //CNPJ
        public string Document { get; set; }
        public UserType UserType { get; set; }
    }
}
