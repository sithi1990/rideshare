using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using UrbanAirship.Push;
using UrbanAirship;
using Android.Support.V4.Content;
using Android.Util;
using DriverLocatorFormsPortable.SharedInterfaces;

namespace DriverLocatorFormsPortable.Droid
{
    [BroadcastReceiver(Exported = false)]
    [IntentFilter(new string[] { "com.urbanairship.push.CHANNEL_UPDATED", "com.urbanairship.push.OPENED", "com.urbanairship.push.DISMISSED", "com.urbanairship.push.RECEIVED" },
        Categories = new string[] { "@PACKAGE_NAME@" })]
    public class UrbanAirshipReceiver : AirshipReceiver, IUrbanAirshipNotificationService
    {

        public const string ACTION_CHANNEL_UPDATED = "channel_updated";

        private const string TAG = "UrbanAirshipReceiver";

        public event EventHandler OnRegistrationSucceeded;
        public event EventHandler OnRegistrationFailed;
        public event EventHandler OnPushMessageReceived;
        public event EventHandler OnPushNotificationPosted;
        public event EventHandler OnPushNotificationOpened;
        public event EventHandler OnPushNotificationDismissed;

        protected override void OnChannelRegistrationSucceeded(Context context, String channelId)
        {
            Log.Info(TAG, "Channel registration updated. Channel Id:" + channelId);

            Intent intent = new Intent(ACTION_CHANNEL_UPDATED);
            LocalBroadcastManager.GetInstance(context).SendBroadcast(intent);

            OnRegistrationSucceeded(this,new OnRegistrationSucceededEventArgs() {ChannelId = channelId });
        }

        protected override void OnChannelRegistrationFailed(Context context)
        {
            Log.Info(TAG, "Channel registration failed.");
            OnRegistrationFailed(this, null);
        }

        protected override void OnPushReceived(Context context, PushMessage message, bool notificationPosted)
        {
            Log.Info(TAG, "Received push message. Alert: " + message.Alert + ". Notification posted: " + notificationPosted);
            OnPushMessageReceived(this, new OnPushMessageReceivedEventArgs() { Message = message.Alert });

        }

        protected override void OnNotificationPosted(Context context, AirshipReceiver.NotificationInfo notificationInfo)
        {
            Log.Info(TAG, "Notification posted. Alert: " + notificationInfo.Message.Alert + ". Notification ID: " + notificationInfo.NotificationId);
            OnPushNotificationPosted(this, new OnPushNotificationPostedEventArgs() { Message = notificationInfo.Message.Alert, NotificationId = notificationInfo.NotificationId });
        }

        protected override bool OnNotificationOpened(Context context, AirshipReceiver.NotificationInfo notificationInfo)
        {
            Log.Info(TAG, "Notification opened. Alert: " + notificationInfo.Message.Alert + ". Notification ID: " + notificationInfo.NotificationId);

            OnPushNotificationOpened(this, new OnPushNotificationOpenedEventArgs() { Message = notificationInfo.Message.Alert, NotificationId = notificationInfo.NotificationId, Button= ButtonType.None });
            // Return false here to allow Urban Airship to auto launch the launcher
            // activity for foreground notification action buttons
            return false;
        }

        protected override bool OnNotificationOpened(Context context, AirshipReceiver.NotificationInfo notificationInfo, AirshipReceiver.ActionButtonInfo actionButtonInfo)
        {
            Log.Info(TAG, "User clicked notification button. Button ID: " + actionButtonInfo.ButtonId + " Alert: " + notificationInfo.Message.Alert);

            // Return false here to allow Urban Airship to auto launch the launcher
            // activity for foreground notification action buttons
            OnPushNotificationOpened(this, new OnPushNotificationOpenedEventArgs() { Message = notificationInfo.Message.Alert, NotificationId = notificationInfo.NotificationId, Button = ButtonType.Confirm });
            return false;
        }

        protected override void OnNotificationDismissed(Context context, AirshipReceiver.NotificationInfo notificationInfo)
        {
            Log.Info(TAG, "Notification dismissed. Alert: " + notificationInfo.Message.Alert + ". Notification ID: " + notificationInfo.NotificationId);
            OnPushNotificationDismissed(this, new OnPushNotificationDismissedEventArgs() { Message = notificationInfo.Message.Alert, NotificationId = notificationInfo.NotificationId });
        }
    }
}