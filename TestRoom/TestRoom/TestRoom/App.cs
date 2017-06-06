using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TestRoom
{
    public class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new TabbedTestsPages());
        }
    }
}