using MobileDev03.VMail.Services;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using AndroidX.Core.App;
using AndroidApp = Android.App.Application;
using Xamarin.Forms;

[assembly: Dependency(typeof(MobileDev03.VMail.Droid.AndroidNotificationManager))]
namespace MobileDev03.VMail.Droid
{
    public class AndroidNotificationManager : INotificationManager
    {
        private const string channelId = "default";
        private const string channelName = "Por defecto";
        private const string channelDescription = "Canal por defecto para las notificaciones.";

        private NotificationManager manager;

        private bool channelInitialized = false;
        private int messageId = 0;
        private int pendingIntentId = 0;

        public static AndroidNotificationManager Instance { get; private set; }

        public AndroidNotificationManager() {
            Initialize();
        }

        public void Initialize() {
            if (Instance == null) {
                CreateNotificationChannel();
                Instance = this;
            }
        }

        public void SendNotification(string title, string message) {
            if (!channelInitialized) {
                CreateNotificationChannel();
            }

            Intent intent = new Intent(AndroidApp.Context, typeof(MainActivity));
            intent.PutExtra("title", title);
            intent.PutExtra("message", message);

            PendingIntent pendingIntent = PendingIntent.GetActivity(AndroidApp.Context, pendingIntentId++, intent, PendingIntentFlags.UpdateCurrent);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(AndroidApp.Context, channelId)
                .SetContentIntent(pendingIntent)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetLargeIcon(BitmapFactory.DecodeResource(AndroidApp.Context.Resources, Resource.Drawable.ComposeIcon))
                .SetSmallIcon(Resource.Drawable.ComposeIcon)
                .SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate);

            Notification notification = builder.Build();
            manager.Notify(messageId++, notification);
        }

        void CreateNotificationChannel() {
            manager = (NotificationManager)AndroidApp.Context.GetSystemService(AndroidApp.NotificationService);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O) {
                Java.Lang.String channelNameJava = new Java.Lang.String(channelName);
                NotificationChannel channel = new NotificationChannel(channelId, channelNameJava, NotificationImportance.Default) {
                    Description = channelDescription
                };
                manager.CreateNotificationChannel(channel);
            }

            channelInitialized = true;
        }
    }
}