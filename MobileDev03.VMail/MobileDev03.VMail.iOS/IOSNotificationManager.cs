using System;
using Foundation;
using UserNotifications;
using Xamarin.Forms;
using MobileDev03.VMail.Services;

[assembly: Dependency(typeof(MobileDev03.VMail.iOS.IOSNotificationManager))]
namespace MobileDev03.VMail.iOS
{
    public class IOSNotificationManager : INotificationManager
    {
        int messageId = 0;
        bool hasNotificationsPermission;

        public void Initialize() {
            // request the permission to use local notifications
            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert, (approved, err) => {
                hasNotificationsPermission = approved;
            });
        }

        public void SendNotification(string title, string message) {
            // EARLY OUT: app doesn't have permissions
            if (!hasNotificationsPermission) {
                return;
            }

            messageId++;

            var content = new UNMutableNotificationContent() {
                Title = title,
                Subtitle = "",
                Body = message,
                Badge = 1
            };

            UNNotificationTrigger trigger;
            // Create a time-based trigger, interval is in seconds and must be greater than 0.
            trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(0.25, false);

            var request = UNNotificationRequest.FromIdentifier(messageId.ToString(), content, trigger);
            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) => {
                if (err != null) {
                    throw new Exception($"Failed to schedule notification: {err}");
                }
            });
        }
    }
}