using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using nwtf_mobile_bl;
using nwtf_mobile.app;

namespace nwtf_mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //one time initialization
            //nwtf_mobile_bl.dataservices.Database.initializeDB();

            MainPage = new SyncPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
