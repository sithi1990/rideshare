using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using UrbanAirshipClient.Common;
using UrbanAirshipClient.Models;

namespace UrbanAirshipClient
{
    public enum DeviceTypes
    {
        Android,
        IOS
    }

    public class UrbanAirship : INotificationClient
    {
        private const string REGISTER_USER_URL = "https://go.urbanairship.com/api/named_users/associate";

        public string AppKey { get; set; }
        public string AppMasterSecret { get; set; }

        public UrbanAirship(string appKey,string appMasterSecret)
        {
            this.AppKey = appKey;
            this.AppMasterSecret = appMasterSecret;
        }

        public bool RegisterUser(RegisterUserRequest regUserRequest)
        {
            HttpRequestHandler requestHandler = new HttpRequestHandler();
            requestHandler.BasicAuthorization.UserName = AppKey;
            requestHandler.BasicAuthorization.Password = AppMasterSecret;
            requestHandler.Url = REGISTER_USER_URL;
            requestHandler.Method = "POST";
            return requestHandler.SendRequest<RegisterUserRequest,RegisterUserResponse>(regUserRequest).Success;
        }
    }
}
