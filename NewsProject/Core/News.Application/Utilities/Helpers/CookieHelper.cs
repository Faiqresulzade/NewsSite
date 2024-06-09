using Microsoft.AspNetCore.Http;

namespace News.Application.Utilities.Helpers
{
    public class CookieHelper
    {
        public static string GetCookie(HttpContext httpContext, string key)
        => httpContext.Request.Cookies[key];

        public static void SetCookie(HttpContext httpContext, string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMonths(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMonths(1);

            httpContext.Response.Cookies.Append(key, value, option);
        }
    }

}
