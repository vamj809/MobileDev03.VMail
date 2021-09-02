using MobileDev03.VMail.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MobileDev03.VMail.ViewModels
{
    public class ReadMailViewModel
    {
        public ReadMailViewModel(Mail selectedMail) {
            SelectedMail = selectedMail;
        }

        public Mail SelectedMail { get; }
    }
}
