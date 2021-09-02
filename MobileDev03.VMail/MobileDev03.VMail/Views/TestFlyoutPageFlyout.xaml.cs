using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDev03.VMail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestFlyoutPageFlyout : ContentPage
    {
        public ListView ListView;

        public TestFlyoutPageFlyout() {
            InitializeComponent();

            BindingContext = new TestFlyoutPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class TestFlyoutPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<TestFlyoutPageFlyoutMenuItem> MenuItems { get; set; }

            public TestFlyoutPageFlyoutViewModel() {
                MenuItems = new ObservableCollection<TestFlyoutPageFlyoutMenuItem>(new[]
                {
                    new TestFlyoutPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new TestFlyoutPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new TestFlyoutPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new TestFlyoutPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new TestFlyoutPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "") {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}