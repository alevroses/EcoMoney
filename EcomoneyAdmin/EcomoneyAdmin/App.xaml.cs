using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EcomoneyAdmin.Vistas;
using EcomoneyAdmin.Vistas.Config;

namespace EcomoneyAdmin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Menuconfig();
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
