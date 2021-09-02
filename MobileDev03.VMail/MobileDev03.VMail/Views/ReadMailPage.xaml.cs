using MobileDev03.VMail.Models;
using MobileDev03.VMail.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDev03.VMail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReadMailPage : ContentPage
    {
        public ReadMailPage(Mail selectedMail) {
            InitializeComponent();
            BindingContext = new ReadMailViewModel(selectedMail);
        }
    }
}