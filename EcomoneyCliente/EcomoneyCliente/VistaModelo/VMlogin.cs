using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EcomoneyCliente.Datos;
using EcomoneyCliente.Modelo;

namespace EcomoneyCliente.VistaModelo
{
    public class VMlogin:BaseViewModel
    {
        #region VARIABLES
        public string identificacion;
        public List<Mclientes> listaclientes = new List<Mclientes>();   
        #endregion

        #region CONSTRUCTOR
        public VMlogin(INavigation navigation)
        {
            Navigation = navigation;
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            Logincommand = new Command(async () => await validarLogin());
        }
        #endregion

        #region OBJETOS
        public List<Mclientes> Listaclientes
        {
            get { return listaclientes; }
            set { SetValue(ref listaclientes, value); }
        }

        public string txtidentificacion
        {
            get { return identificacion; }
            set { SetValue(ref identificacion, value); }
        }
        #endregion

        #region PROCESOS
        private async Task validarLogin()
        {
            var funcion = new Dclientes();
            var parametros = new Mclientes();
            parametros.Identificacion = txtidentificacion;
            Listaclientes = await funcion.Validarcliente(parametros);

            if(Listaclientes.Count > 0)
            {
                await Navigation.PushAsync(new Vistas.Menu(Listaclientes));
            }
        }
        #endregion

        #region COMANDOS
        public Command Logincommand { get; }
        #endregion
    }
}
