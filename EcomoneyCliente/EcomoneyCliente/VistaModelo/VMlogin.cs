using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EcomoneyCliente.VistaModelo
{
    public class VMlogin:BaseViewModel
    {
        public VMlogin()
        {
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
        }
    }
}
