using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EcomoneyRecolector.VistaModelo;
using EcomoneyRecolector.Modelo;

namespace EcomoneyRecolector.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agregarcompra : ContentPage
    {
        public Agregarcompra(Mproductos productos)
        {
            InitializeComponent();
            BindingContext = new VMagregarcompra(Navigation, productos);
        }
    }
}