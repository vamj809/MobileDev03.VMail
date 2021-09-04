using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDev03.VMail.ViewModels
{
    public class ImageViewerViewModel : BaseViewModel
    {
        public string ImageFilePath { get; set; }
        public ImageViewerViewModel(FileResult imageFileResult) {
            LoadImageAsync(imageFileResult);
        }

        private async void LoadImageAsync(FileResult imageFileResult) {
            _ = await imageFileResult.OpenReadAsync();
            ImageFilePath = imageFileResult.FullPath;
        }
    }
}
