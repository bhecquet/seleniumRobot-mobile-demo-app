using PCLStorage;
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
            //var browser = new WebView();
            //var htmlSource = new HtmlWebViewSource();
            //htmlSource.Html = WebViewHtmlContent.getHtmlContent();
            //browser.Source = htmlSource;

            //browser.VerticalOptions = LayoutOptions.Fill;
            //browser.HorizontalOptions = LayoutOptions.Fill;

            //this.Content = new ScrollView
            //{
            //    Content = browser
            //};

            WebView webView = new WebView
            {
                Source = new HtmlWebViewSource
                {
                    Html = WebViewHtmlContent.getHtmlContent(),
                },
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            // Accomodate iPhone status bar.
            //this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

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