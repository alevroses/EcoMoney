using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EcomoneyCliente.Modelo;
using EcomoneyCliente.VistaModelo;

namespace EcomoneyCliente.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detallecompra : ContentPage
    {
        public Detallecompra(List<Mclientes> clientes)
        {
            InitializeComponent();
            BindingContext = new VMmenu(Navigation, clientes);
        }
    }
}