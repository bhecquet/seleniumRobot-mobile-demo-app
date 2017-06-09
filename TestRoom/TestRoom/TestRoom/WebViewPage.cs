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
        public interface IBaseUrl { string Get(); }
        public WebViewPage()
        {
            var source = new HtmlWebViewSource();
            source.BaseUrl = DependencyService.Get<IBaseUrl>().Get();

            var assembly = typeof(TestRoom.WebViewPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("TestRoom.pageParente.html");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = @reader.ReadToEnd();
            }
            Debug.WriteLine(text);
            var browser = new WebView();
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = WebViewHtmlContent.getHtmlContent();

            browser.Source = htmlSource;

            browser.VerticalOptions = LayoutOptions.Fill;
            browser.HorizontalOptions = LayoutOptions.Fill;

            this.Content = new ScrollView
            {
                Content = browser
            };
        }        
    }
}