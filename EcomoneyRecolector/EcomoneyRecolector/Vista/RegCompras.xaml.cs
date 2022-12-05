using EcomoneyRecolector.VistaModelo;
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
    public partial class RegCompras : ContentPage
    {
        public RegCompras()
        {
            InitializeComponent();
            BindingContext = new VMregCompras(Navigation);
        }
    }
}