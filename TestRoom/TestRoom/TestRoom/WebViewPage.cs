using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TestRoom
{
    public class WebViewPage : ContentPage
    {
        public WebViewPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Not a web view yet !" }
                }
            };
        }
    }
}