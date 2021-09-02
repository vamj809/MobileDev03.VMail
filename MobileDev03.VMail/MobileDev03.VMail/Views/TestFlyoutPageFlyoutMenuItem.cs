using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDev03.VMail.Views
{
    public class TestFlyoutPageFlyoutMenuItem
    {
        public TestFlyoutPageFlyoutMenuItem() {
            TargetType = typeof(TestFlyoutPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}