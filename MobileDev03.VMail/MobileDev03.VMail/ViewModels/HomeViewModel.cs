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
        private Mail _selectedMail;
        public Mail SelectedMail {
            get => _selectedMail;
            set {
                _selectedMail = value;
                if (_selectedMail != null) {
                    GoToReadMailPageCommand.Execute(_selectedMail);
                    _selectedMail = null;
                }
            }
        }

        public ObservableCollection<Mail> Mails { get; set; } = new ObservableCollection<Mail>() {
            //new Mail("TheSender01","TheRecipient","TheSubject","SomeRandomBody"),
            //new Mail("BiasSender","Another Recipient","The Other Subject","Still SomeRandomBody")
        };

        private ICommand GoToReadMailPageCommand { get; }
        public ICommand GoToAddMailPageCommand { get; }
        public ICommand DeleteMailCommand { get; }
        public ICommand SetFavoriteMailCommand { get; }
        public HomeViewModel() {
            GoToAddMailPageCommand = new Command(GoToAddMailPage);
            GoToReadMailPageCommand = new Command<Mail>(GoToReadMailPage);
            DeleteMailCommand = new Command<Mail>(DeleteMail);
            SetFavoriteMailCommand = new Command<Mail>(SetFavoriteMail);
        }

        private async void GoToAddMailPage() {
            await Application.Current.MainPage.Navigation.PushAsync(new AddMailPage(Mails));
        }

        private async void GoToReadMailPage(Mail mail) {
            await Application.Current.MainPage.Navigation.PushAsync(new ReadMailPage(mail));
        }

        private void DeleteMail(Mail mail) {
            Mails.Remove(mail);
        }

        private void SetFavoriteMail(Mail mail) {
            mail.IsFavorite = !mail.IsFavorite;
            _ = mail.FavoriteIcon;
        }
    }
}
