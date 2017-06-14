using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using Xamarin.Forms;

namespace TestRoom
{
    public class WebViewPage : ContentPage
    {
        public WebViewPage()
        {
            WebView webView = new WebView
            {
                Source = new HtmlWebViewSource
                {
                    Html = WebViewHtmlContent.getHtmlContent(),
                },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    webView
                }
            };
        }        
    }
}