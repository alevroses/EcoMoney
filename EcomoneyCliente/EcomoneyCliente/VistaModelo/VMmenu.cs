using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EcomoneyCliente.Datos;
using EcomoneyCliente.Modelo;

namespace EcomoneyCliente.VistaModelo
{
    public class VMmenu : BaseViewModel
    {
        #region VARIABLES
        public string identificacion;
        #endregion

        #region CONSTRUCTOR
        public VMmenu(INavigation navigation)
        {
            Navigation = navigation;
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            Logincommand = new Command(async () => await validarLogin());
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
        private async Task validarLogin()
        {
            var funcion = new Dclientes();
            var parametros = new Mclientes();
            parametros.Identificacion = txtidentificacion;
            var dt = await funcion.Validarcliente(parametros);

            if (dt.Count > 0)
            {
                await Navigation.PushAsync(new Vistas.Menu());
            }
        }
        #endregion

        #region COMANDOS
        public Command Logincommand { get; }
        #endregion
    }
}
