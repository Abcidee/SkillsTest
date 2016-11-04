using System.Web;

namespace SkillsTest.Web.Infrastructure
{
    public static class FlashMessageHelper
    {
        public static dynamic Success(this object result, string message)
        {
            CreateCookieWithFlashMessage(Notifications.Success, message);
            return result;
        }

        public static dynamic Error(this object result, string message)
        {
            CreateCookieWithFlashMessage(Notifications.Error, message);
            return result;
        }

        public static dynamic Warning(this object result, string message)
        {
            CreateCookieWithFlashMessage(Notifications.Warning, message);
            return result;
        }

        public static dynamic Information(this object result, string message)
        {
            CreateCookieWithFlashMessage(Notifications.Information, message);
            return result;
        }

        private static void CreateCookieWithFlashMessage(Notifications notification, string message)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(string.Format("Flash.{0}", notification), message) { Path = "/" });
        }

        private enum Notifications
        {
            Information,
            Error,
            Warning,
            Success
        }
    }
}