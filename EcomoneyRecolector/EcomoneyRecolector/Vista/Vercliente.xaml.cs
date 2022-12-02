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
    public partial class Vercliente : ContentPage
    {
        public static string nombre;
        public static string dni;
        public static string foto;
        public static string direccion;

        public Vercliente()
        {
            InitializeComponent();
            //Obtederdatos();
        }

        /*private async void btnvolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private void Obtederdatos()
        {
            lblnombre.Text = nombre;
            lbldireccion.Text = direccion;
            lbldni.Text = dni;
            fotofachada.Source = foto;
        }
        */
    }
}