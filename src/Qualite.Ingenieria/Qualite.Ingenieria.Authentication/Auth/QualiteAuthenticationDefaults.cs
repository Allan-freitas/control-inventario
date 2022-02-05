using Microsoft.AspNetCore.Http;

namespace Qualite.Ingenieria.Authentication.Auth
{
    public static class QualiteAuthenticationDefaults
    {
        public static string AuthenticationScheme => "Authentication";

        public static string ExternalAuthenticationScheme => "ExternalAuthentication";

        public static PathString LoginPath => new PathString("/login");

        public static PathString AccessDeniedPath => new PathString("/page-not-found");

        public static string ClaimsIssuer => "qualite";
    }
}
