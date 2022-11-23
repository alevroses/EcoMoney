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
        public string identificacion;
        #endregion

        #region CONSTRUCTOR
        public VMsolicitud(INavigation navigation, Mclientes cliente)
        {
            Navigation = navigation;
            Cliente = cliente;
            /*Registroinicial = true;
            Registrofinal = false;
            Fechaactual = DateTime.Now.ToString("dd/MM/yyyy");
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            Insertarsolicitudcommand = new Command(async () => await Insertarsolicitud());
            Volvercommand = new Command(async () => await Volver());
            Mostrarturnos();*/
        }
        #endregion

        #region OBJETOS
        public string txtidentificacion
        {
            get { return identificacion; }
            set { SetValue(ref identificacion, value); }
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
