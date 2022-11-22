using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EcomoneyCliente.Datos;
using EcomoneyCliente.Modelo;
using System.Linq;

namespace EcomoneyCliente.VistaModelo
{
    public class VMmenu : BaseViewModel
    {
        #region VARIABLES
        public string identificacion;
        public List<Mdetallecompra> listadetallecompra = new List<Mdetallecompra>();
        public List<Mclientes> listaclientes = new List<Mclientes>();
        #endregion

        #region CONSTRUCTOR
        public VMmenu(INavigation navigation, List<Mclientes> clientes)
        {
            Navigation = navigation;
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            /*Logincommand = new Command(async () => await validarLogin());*/
            Listaclientes = clientes;
        }
        #endregion

        #region OBJETOS
        public Mclientes Clientes { get; set; }
        public string txtidentificacion
        {
            get { return identificacion; }
            set { SetValue(ref identificacion, value); }
        }

        public List<Mdetallecompra> Listadetallecompra
        {
            get { return listadetallecompra;}
            set { SetValue(ref listadetallecompra, value); }
        }

        public List<Mclientes> Listaclientes
        {
            get { return listaclientes; }
            set { SetValue(ref listaclientes, value); }
        }
        #endregion

        #region PROCESOS
        /*private async Task validarLogin()
        {
            var funcion = new Dclientes();
            var parametros = new Mclientes();
            parametros.Identificacion = txtidentificacion;
            var dt = await funcion.Validarcliente(parametros);

            if (dt.Count > 0)
            {
                await Navigation.PushAsync(new Vistas.Menu());
            }
        }*/

        public async Task MostrarDcompra()
        {
            ObtenerIdcliente();
            var funcion = new Ddetallecompra();
            Listadetallecompra = await funcion.MostrarDcompra(Clientes.Idcliente);
        }

        private void ObtenerIdcliente()
        {
            var data = Listaclientes.FirstOrDefault();
            Clientes.Idcliente = data.Idcliente;
        }
        #endregion

        #region COMANDOS
        public Command Logincommand { get; }
        #endregion
    }
}
