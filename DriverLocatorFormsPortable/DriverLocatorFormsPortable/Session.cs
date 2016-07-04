using Authentication.Common;

namespace DriverLocatorFormsPortable
{
	public static class Session
	{
        public static IAuthenticationService AuthenticationService { get; set; }

        public static string CurrentUserName { get; set; }
        public static string AppKey { get { return "7RaPmFE0QP-L_pDKsTyLCA"; } }
        public static string AppMasterSecret { get { return "JEf6KdsJRY-G7a6QOg19Jg"; } }

    }

}
