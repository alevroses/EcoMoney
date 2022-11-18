using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EcomoneyAdmin.VistaModelo;

namespace EcomoneyAdmin.Vistas.Config
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Productosconfig : ContentPage
    {
        public Productosconfig()
        {
            InitializeComponent();
            BindingContext = new VMproductosconfig(Navigation);
        }
    }
}