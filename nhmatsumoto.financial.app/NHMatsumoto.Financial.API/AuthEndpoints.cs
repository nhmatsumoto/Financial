using System.Data;

namespace nhmatsumoto.financial.api
{
    public static class AuthEndpoints
    {
        public static void RegisterAuthEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/admin", () =>
            {

            })
            .WithName("admin")
            .WithOpenApi()
            .RequireAuthorization("SysAdmin");
           
        }
    }
}
