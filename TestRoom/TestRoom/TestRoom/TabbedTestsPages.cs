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
        public TabbedTestsPages()
        {
            this.Title = "Selenium Robot test app";

            Children.Add(new FormList { Title = "Test Room" });
            Children.Add(new WebViewPage { Title = "Web view" });
        }
    }
}

/*
 
    //Use this for android
    Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) => {
        if (null != e.View.StyleId) {
            e.NativeView.ContentDescription = e.View.StyleId;
        }
    };

    //And this for iOS
    Forms.ViewInitialized += (object sender, ViewInitializedEventArgs e) => {
        if (null != e.View.StyleId) {
            e.NativeView.AccessibilityIdentifier = e.View.StyleId;
        }
    };

    */