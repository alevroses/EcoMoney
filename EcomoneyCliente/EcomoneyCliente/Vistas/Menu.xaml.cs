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
    public partial class Menu : ContentPage
    {
        public Menu(List<Mclientes> clientes)
        {
            InitializeComponent();
            BindingContext = new VMmenu(Navigation, clientes);
        }
    }
}