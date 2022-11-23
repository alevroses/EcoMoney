using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EcomoneyCliente.VistaModelo;
using EcomoneyCliente.Modelo;

namespace EcomoneyCliente.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Solicitud : ContentPage
    {
        public Solicitud(Mclientes cliente)
        {
            InitializeComponent();
            BindingContext = new VMsolicitud(Navigation, cliente);
        }
    }
}