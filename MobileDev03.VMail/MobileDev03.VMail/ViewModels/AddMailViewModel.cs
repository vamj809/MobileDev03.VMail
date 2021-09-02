using MobileDev03.VMail.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileDev03.VMail.ViewModels
{
    public class AddMailViewModel : BaseViewModel
    {
        public ICommand SendMailCommand { get; }

        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public AddMailViewModel(ObservableCollection<Mail> mails) {
            _mails = mails;
            SendMailCommand = new Command(AddMailToCollection);
        }

        private ObservableCollection<Mail> _mails;

        private async void AddMailToCollection() {
            if(string.IsNullOrEmpty(Sender) || string.IsNullOrEmpty(Recipient) || string.IsNullOrEmpty(Subject) || string.IsNullOrEmpty(Body)) {
                await Application.Current.MainPage.DisplayAlert("Alerta!", "Debe especificar un emisor y receptor.", "OK");
            } else {
                _mails.Add(new Mail(Sender, Recipient, Subject, Body));
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
