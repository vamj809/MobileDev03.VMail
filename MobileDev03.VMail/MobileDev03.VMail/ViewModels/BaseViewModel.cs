using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MobileDev03.VMail.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
