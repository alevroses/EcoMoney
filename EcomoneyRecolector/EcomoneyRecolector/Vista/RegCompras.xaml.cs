using EcomoneyRecolector.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EcomoneyRecolector.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegCompras : ContentPage
    {
        public RegCompras()
        {
            InitializeComponent();
            BindingContext = new VMregCompras(Navigation);
        }

        protected override async void OnAppearing()
        {
            var vistamodelo = new VMregCompras(Navigation);
            Txttotal.Text = await vistamodelo.Sumartotal();
        }

        private async void DeslizarPanelcontador(object sender, SwipedEventArgs e)
        {
            await Mostrarpaneldv();
        }

        private async Task Mostrarpaneldv()
        {
            uint duracion = 700;
            await Task.WhenAll(
                Gridprincipal.TranslateTo(0, -800, duracion, Easing.CubicIn),
                Paneldetallecompra.TranslateTo(0, 0, duracion, Easing.CubicIn),
                Paneldetallecompra.FadeTo(1, duracion)
                );
            Paneldetallecompra.IsVisible = true;

        }

        private async void DeslizarPaneldetallecompra(object sender, SwipedEventArgs e)
        {
            await Mostrargridprincipal();
        }

        private async Task Mostrargridprincipal()
        {
            uint duracion = 700;
            await Task.WhenAll(
                Gridprincipal.TranslateTo(0, 0, duracion, Easing.CubicIn),
                Paneldetallecompra.TranslateTo(0, -800, duracion, Easing.CubicIn),
                Paneldetallecompra.FadeTo(0, duracion)

                );
            Gridprincipal.IsVisible = true;
            var vistamodelo = new VMregCompras(Navigation);
            Txttotal.Text = await vistamodelo.Sumartotal();
        }
    }
}