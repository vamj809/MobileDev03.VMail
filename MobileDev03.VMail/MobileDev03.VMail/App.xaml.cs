using MobileDev03.VMail.Models;
using MobileDev03.VMail.Views;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;

namespace MobileDev03.VMail
{
    public partial class App : Application
    {
        public ObservableCollection<Mail> Mails { get; set; }
        public App() {
            InitializeComponent();

            //Load StoredMails if they exist
            string _serializedMails = Preferences.Get("VMail.StoredMails", "");
            if (string.IsNullOrWhiteSpace(_serializedMails)) {
                Mails = new ObservableCollection<Mail>();
            } else {
                Mails = JsonConvert.DeserializeObject<ObservableCollection<Mail>>(_serializedMails);
            }

            MainPage = new NavigationPage(new HomePage(Mails));
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
