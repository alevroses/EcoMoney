using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using EcomoneyRecolector.Vista;
using EcomoneyRecolector.Datos;
using EcomoneyRecolector.Modelo;

namespace EcomoneyRecolector.VistaModelo
{
    public class VMregCompras : BaseViewModel
    {
        #region VARIABLES
        public static string idcliente;
        public string identificacion;
        /*string total;
        bool gridprincipal;
        bool paneldetallecompra;
        public static string Idsolicitud;
        List<Mdetallecompras> listadetallecompras = new List<Mdetallecompras>();*/
        private List<Mproductos> listaproductos = new List<Mproductos>();

        #endregion
        #region CONSTRUCTOR
        public VMregCompras(INavigation navigation)
        {
            Navigation = navigation;
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            /*AgregarcompraNavcommand = new Command<Mproductos>(async (p) => await NavegaragregarCompra(p));
            Guardarcommand = new Command(async () => await Guardardetallecompra());
            Eliminardcompracommand = new Command<Mdetallecompras>(async (d) => await EliminarDcompra(d));
            Mostrardcompracommand = new Command(async () => await MostrarDetallecompra());
            Gridprincipal = true;
            Paneldetallecompra = false;*/
            Mostrarproductos();
            //Sumartotal();
        }

            #endregion
            #region OBJETOS
        public List<Mproductos> Listaproductos
        {
            get { return listaproductos; }
            set { SetValue(ref listaproductos, value); }
        }
        /*public List<Mdetallecompras> Listadetallecompras
        {
            get { return listadetallecompras; }
            set { SetValue(ref listadetallecompras, value); }
        }
        public string Total
        {
            get { return total; }
            set { SetValue(ref total, value); }
        }
        public bool Gridprincipal
        {
            get { return gridprincipal; }
            set { SetValue(ref gridprincipal, value); }
        }

        public bool Paneldetallecompra
        {
            get { return paneldetallecompra; }
            set { SetValue(ref paneldetallecompra, value); }
        }*/
        #endregion
        #region PROCESOS
        private async Task Mostrarproductos()
        {
            var funcion = new Dproductos();
            Listaproductos = await funcion.Mostrarproductos();
        }
        /*private async Task NavegaragregarCompra(Mproductos productos)
        {
            VMagregarcompra.Idcliente = idcliente;
            await Navigation.PushAsync(new Agregarcompra(productos));

        }
        
        public async Task<string> Sumartotal()
        {
            var funcion = new Ddetallecompras();
            var parametros = new Mdetallecompras();
            parametros.Idcliente = idcliente;
            Total = await funcion.SumarTotal(parametros);
            return Total;
        }
        public async Task SumartotalLabel()
        {
            var funcion = new Ddetallecompras();
            var parametros = new Mdetallecompras();
            parametros.Idcliente = idcliente;
            Total = await funcion.SumarTotal(parametros);

        }
        private async Task Guardardetallecompra()
        {
            var funcion = new Ddetallecompras();
            var parametros = new Mdetallecompras();
            parametros.Idcliente = idcliente;
            await funcion.Confirmardetallecompra(parametros);
            await Eliminarasignacion();
            await Eliminarsolicitud();
            await DisplayAlert("Registrado", "Compra guardada correctamente", "OK");
            await Navigation.PopAsync();
        }
        private async Task Eliminarsolicitud()
        {
            var funcion = new Dsolicitudesrecojo();
            var parametros = new Msolicitudesrecojo();
            parametros.Idsolicitud = Idsolicitud;
            await funcion.Eliminarsolicitud(parametros);
        }
        private async Task Eliminarasignacion()
        {
            var funcion = new Dasignaciones();
            var parametros = new Masignaciones();
            parametros.idsolicitud = Idsolicitud;
            await funcion.Eliminarasignacion(parametros);
        }
        private async Task EliminarDcompra(Mdetallecompras parametrosPedir)
        {
            var funcion = new Ddetallecompras();
            var parametros = new Mdetallecompras();
            parametros.Iddetallecompra = parametrosPedir.Iddetallecompra;
            await funcion.EliminarDcompra(parametros);
            await MostrarDetallecompra();
            await SumartotalLabel();
            await Sumartotal();

        }
        public async Task MostrarDetallecompra()
        {
            var funcion = new Ddetallecompras();
            Listadetallecompras = await funcion.MostrarDcompra(idcliente);
            await SumartotalLabel();
        }*/

        #endregion
        #region COMANDOS
        /*public Command AgregarcompraNavcommand { get; }
        public Command Guardarcommand { get; }
        public Command Eliminardcompracommand { get; }
        public Command Mostrardcompracommand { get; }*/
        #endregion
    }
}
