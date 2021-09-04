using MobileDev03.VMail.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using MobileDev03.VMail.Views;

namespace MobileDev03.VMail.ViewModels
{
    public class ReadMailViewModel
    {
        public ICommand ViewImageCommand { get; }
        public ReadMailViewModel(Mail selectedMail) {
            SelectedMail = selectedMail;
            ViewImageCommand = new Command<FileResult>(GoToImageViewerPage);
        }

        private async void GoToImageViewerPage(FileResult image) {
            await Application.Current.MainPage.Navigation.PushAsync(new ImageViewerPage(image));
        }

        public Mail SelectedMail { get; }
    }
}
