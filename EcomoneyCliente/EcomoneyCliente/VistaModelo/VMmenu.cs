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
        public string idcliente;
        public string lblnombreuser;
        public string lbltotalcobrado;
        public string lbltotalporcobrar;
        public string imagenfachada;
        public string lblkgacumulados;
        public string lblpuntos;
        public string lblpuntosEti;

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

            ObtenerIdcliente();
            MostrarDcompra();
        }
        #endregion

        #region OBJETOS
        public string Lblkgacumulados
        {
            get { return lblkgacumulados; }
            set { SetValue(ref lblkgacumulados, value); }
        }

        public string Lblpuntos
        {
            get { return lblpuntos; }
            set { SetValue(ref lblpuntos, value); }
        }

        public string LblpuntosEti
        {
            get { return lblpuntosEti; }
            set { SetValue(ref lblpuntosEti, value); }
        }

        public string Imagenfachada
        {
            get { return imagenfachada; }
            set { SetValue(ref imagenfachada, value); }
        }

        public string Lblnombreuser
        {
            get { return lblnombreuser; }
            set { SetValue(ref lblnombreuser, value); }
        }

        public string Lbltotalcobrado
        {
            get { return lbltotalcobrado; }
            set { SetValue(ref lbltotalcobrado, value); }
        }

        public string Lbltotalporcobrar
        {
            get { return lbltotalporcobrar; }
            set { SetValue(ref lbltotalporcobrar, value); }
        }

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
            var funcion = new Ddetallecompra();
            Listadetallecompra = await funcion.MostrarDcompra(idcliente);
        }

        private void ObtenerIdcliente()
        {
            var data = Listaclientes.FirstOrDefault();
            idcliente = data.Idcliente;
            Lblnombreuser = data.NombreCom;
            Lbltotalcobrado = data.Totalcobrado;
            Lbltotalporcobrar = data.Totalporcobrar;
            Imagenfachada = data.FotoFachada;
            Lblpuntos = ((Convert.ToDouble(data.Puntos)/10)/1000).ToString();
            LblpuntosEti = data.Puntos;
            Lblkgacumulados = "Kg reciclados: [" + data.Kgacumulados + "]";
        }
        #endregion

        #region COMANDOS
        public Command Logincommand { get; }
        #endregion
    }
}
