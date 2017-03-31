using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WisenetBackOfficeApp.Pages;
using WisenetBackOfficeApp.Views;
using Xamarin.Forms;

namespace WisenetBackOfficeApp
{
    public partial class App : Application
    {

        public static NavigationPage Navigator { get; internal set; }
        public static MasterPage Master { get; internal set; }
        public App()
        {
            InitializeComponent();

            //MainPage = new WisenetBackOfficeApp.MainPage();
            //MainPage = new MasterPage();
            MainPage = new Login();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
