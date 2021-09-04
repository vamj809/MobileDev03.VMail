using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileDev03.VMail.ViewModels;

namespace MobileDev03.VMail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageViewerPage : ContentPage
    {
        public ImageViewerPage(FileResult imageFileResult) {
            InitializeComponent();
            BindingContext = new ImageViewerViewModel(imageFileResult);
        }
    }
}