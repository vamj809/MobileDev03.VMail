using MobileDev03.VMail.Models;
using MobileDev03.VMail.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDev03.VMail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage(ObservableCollection<Mail> mails) {
            InitializeComponent();
            BindingContext = new HomeViewModel(mails);
        }
    }
}