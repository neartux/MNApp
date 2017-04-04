﻿using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WisenetBackOfficeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Master = this;
            App.Navigator = this.Navigator;
        }
    }
}
