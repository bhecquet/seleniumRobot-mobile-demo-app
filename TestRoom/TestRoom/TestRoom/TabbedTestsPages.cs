using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestRoom
{
    class TabbedTestsPages : TabbedPage
    {
        //private void InitializeComponent()
        //{
        //    this.LoadFromXaml(typeof(TabbedTestsPages));
        //}
        
        public TabbedTestsPages()
        {
            this.Title = "Selenium Robot test app";

            Children.Add(new FormList { Title = "Test Room" });

            Children.Add(new WebViewPage { Title = "Web view" });
        }
    }
}