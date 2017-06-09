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
            this.Title = "Selenium Robot test app";

            Children.Add(new TestRoomForm { Title = "Test Room" });

            Children.Add(new WebViewPage { Title = "Web view" });
        }
    }
}