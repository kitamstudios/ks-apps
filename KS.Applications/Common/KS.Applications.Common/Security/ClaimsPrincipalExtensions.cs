namespace KS.Applications.Common.Security
{
    using System.Diagnostics.Contracts;
    using System.Security.Claims;

    public static class ClaimsPrincipalExtensions
    {
        public static Claim GetClaim(this ClaimsPrincipal @this, string type)
        {
            Contract.Requires(@this != null);

            return @this.FindFirst(type);
        }
    }
}
