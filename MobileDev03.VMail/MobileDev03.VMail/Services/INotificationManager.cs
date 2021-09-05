using System;

namespace MobileDev03.VMail.Services
{
    public interface INotificationManager
    {
        void Initialize();
        void SendNotification(string title, string message);
    }
}
