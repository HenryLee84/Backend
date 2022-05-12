using System.Security.Claims;

namespace Utilities.Extensions
{
    public static class ClaimPrincipalExtensions
    {
        /// <summary>
        /// 從ClaimsPrincipal取得Id
        /// </summary>
        /// <param name="user">ClaimsPrincipal</param>
        /// <returns></returns>
        public static int? GetUserID(this ClaimsPrincipal user)
        {
            var id = user.FindFirstValue("id");

            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out var result))
                return null;

            return result;
        }

        /// <summary>
        /// 從ClaimsPrincipal取得Account
        /// </summary>
        /// <param name="user">ClaimsPrincipal</param>
        /// <returns></returns>
        public static string? GetUserAccount(this ClaimsPrincipal user)
        {
            var account = user.FindFirstValue(ClaimTypes.NameIdentifier);

            return account;
        }
    }
}
