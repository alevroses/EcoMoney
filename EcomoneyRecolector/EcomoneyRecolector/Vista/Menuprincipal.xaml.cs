using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EcomoneyRecolector.VistaModelo;

namespace EcomoneyRecolector.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menuprincipal : ContentPage
    {
        public Menuprincipal()
        {
            InitializeComponent();
            BindingContext = new VMmenuprincipal(Navigation);
        }

        protected override async void OnAppearing()
        {
            var vistamodelo = new VMmenuprincipal(Navigation);
            txtContador.Text = await vistamodelo.obtenerdatosRecolector();
        }
    }
}