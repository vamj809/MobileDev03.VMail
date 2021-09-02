using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MobileDev03.VMail.Models;

namespace MobileDev03.VMail.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<Mail> Mails { get; set; } = new ObservableCollection<Mail>() {
                new Mail("TheSender01","TheRecipient","TheSubject","SomeRandomBody",DateTime.Now),
                new Mail("TheSender02","TheRecipient2","TheSubject","SomeRandomBody",DateTime.Now)
            };

        public HomeViewModel() {

        }
    }
}
