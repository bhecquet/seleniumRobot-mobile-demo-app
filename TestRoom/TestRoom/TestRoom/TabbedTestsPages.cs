using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TestRoom
{
    class TabbedTestsPages : TabbedPage
    {
        public TabbedTestsPages()
        {
            this.Title = "Pages de tests pour robot";

            Children.Add(new TestRoomForm { Title = "Test Room" });
            //Children.Add(new CheckedForm { Title = "Checked" });
            Children.Add(new WebViewPage { Title = "Web view" });
        }
    }
}