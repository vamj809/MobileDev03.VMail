using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MobileDev03.VMail.Models;
using MobileDev03.VMail.Views;
using Xamarin.Forms;

namespace MobileDev03.VMail.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Mail> Mails { get; set; } = new ObservableCollection<Mail>() {
                new Mail("TheSender01","TheRecipient","TheSubject","SomeRandomBody",DateTime.Now),
                new Mail("TheSender02","TheRecipient2","TheSubject","SomeRandomBody",DateTime.Now)
            };

        public ICommand GoToAddMailPageCommand { get; }
        public HomeViewModel() {
            GoToAddMailPageCommand = new Command(GoToAddMailPage);
        }

        private async void GoToAddMailPage() {
            await Application.Current.MainPage.Navigation.PushAsync(new AddMailPage());
        }
    }
}
