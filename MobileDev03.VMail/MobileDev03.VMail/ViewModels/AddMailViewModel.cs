using MobileDev03.VMail.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileDev03.VMail.ViewModels
{
    public class AddMailViewModel : BaseViewModel
    {
        public ICommand SendMailCommand { get; }
        public ICommand AttachImageCommand { get; }
        public ICommand RemoveAttachmentCommand { get; }

        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public ObservableCollection<FileResult> Attachments { get; set; } = new ObservableCollection<FileResult>();
        public AddMailViewModel(ObservableCollection<Mail> mails) {
            _mails = mails;
            SendMailCommand = new Command(AddMailToCollection);
            AttachImageCommand = new Command(AttachImageToEmail);
            RemoveAttachmentCommand = new Command<FileResult>(RemoveAttachment);
        }

        private ObservableCollection<Mail> _mails;

        private async void AddMailToCollection() {
            if (string.IsNullOrEmpty(Sender) || string.IsNullOrEmpty(Recipient) || string.IsNullOrEmpty(Subject) || string.IsNullOrEmpty(Body)) {
                await Application.Current.MainPage.DisplayAlert("Alerta!", "Debe especificar un emisor y receptor.", "OK");
            }
            else {
                _mails.Add(new Mail(Sender, Recipient, Subject, Body, Attachments));
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        private async void AttachImageToEmail() {
            FileResult image = await MediaPicker.PickPhotoAsync();
            if (image != null) {
                Attachments.Add(image);
            }
            else {
                await Application.Current.MainPage.DisplayAlert("Error", "No se pudo adjuntar la imagen correctamente.", "OK");
            }
        }

        private void RemoveAttachment(FileResult image) {
            Attachments.Remove(image);
        }
    }
}
