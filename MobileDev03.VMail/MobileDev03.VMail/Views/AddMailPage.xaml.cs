using MobileDev03.VMail.Models;
using MobileDev03.VMail.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDev03.VMail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMailPage : ContentPage
    {
        public AddMailPage(ObservableCollection<Mail> mails) {
            InitializeComponent();
            BindingContext = new AddMailViewModel(mails);
        }
    }
}