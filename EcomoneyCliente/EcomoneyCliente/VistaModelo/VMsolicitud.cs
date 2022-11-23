using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EcomoneyCliente.Datos;
using EcomoneyCliente.Modelo;

namespace EcomoneyCliente.VistaModelo
{
    public class VMsolicitud:BaseViewModel
    {
        #region VARIABLES
        public bool registroinicial;
        public bool registrofinal;
        #endregion

        #region CONSTRUCTOR
        public VMsolicitud(INavigation navigation, Mclientes cliente)
        {
            Navigation = navigation;
            Cliente = cliente;
            Registroinicial = true;
            Registrofinal = false;
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            /*Fechaactual = DateTime.Now.ToString("dd/MM/yyyy");
            
            Insertarsolicitudcommand = new Command(async () => await Insertarsolicitud());
            Volvercommand = new Command(async () => await Volver());
            Mostrarturnos();*/
        }
        #endregion

        #region OBJETOS
        public bool Registroinicial
        {
            get { return registroinicial; }
            set { SetValue(ref registroinicial, value); }
        }
        public bool Registrofinal
        {
            get { return registrofinal; }
            set { SetValue(ref registrofinal, value); }
        }
        #endregion

        #region PROCESOS
        public Mclientes Cliente { get; set; }
        #endregion

        #region COMANDOS
        public Command Logincommand { get; }
        #endregion
    }
}
