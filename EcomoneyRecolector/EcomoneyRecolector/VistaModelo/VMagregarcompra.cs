using System;
using System.Collections.Generic;
using System.Text;
using EcomoneyRecolector.Modelo;
using EcomoneyRecolector.Datos;
using EcomoneyRecolector.Vista;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace EcomoneyRecolector.VistaModelo
{
    public class VMagregarcompra : BaseViewModel
    {
        #region VARIABLES
        private string Total;
        private string Cantidad;
        private double Ganancia;
        private double Precioventa;
        public static string Idcliente;

        #endregion
        #region CONSTRUCTOR
        public VMagregarcompra(INavigation navigation, Mproductos productos)
        {
            Navigation = navigation;
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            //Insertarcommand = new Command(async () => await Insertardetallecompra());
            Productos = productos;
        }

        #endregion
        #region OBJETOS
        public Mproductos Productos { get; set; }
        public string Cantidadtxt
        {
            get { return Cantidad; }
            set { SetValue(ref Cantidad, value); }
        }
        
        public string Totaltxt
        {
            get { return Total; }
            set { SetValue(ref Total, value); }
        }
        #endregion
        #region PROCESOS
        private async Task Insertardetallecompra()
        {
            CalcularTotal();
            var funcion = new Ddetallecompras();
            var parametros = new Mdetallecompras();
            parametros.Ganancia = Ganancia.ToString();
            parametros.Idcliente = Idcliente;
            parametros.Idproducto = Productos.Idproducto;
            parametros.Cantidad = Cantidadtxt;
            parametros.Preciocompra = Productos.Preciocompra;
            parametros.PrecioVenta = Productos.Precioventa;
            parametros.Total = Totaltxt;
            parametros.Und = Productos.Und;
            parametros.Puntos = "-";
            parametros.Estado = "SIN CONFIRMAR";
            await funcion.InsertarDetallecompra(parametros);
            await Navigation.PopAsync();
        }

        private void CalcularTotal()
        {
            if (!string.IsNullOrEmpty(Cantidadtxt))
            {
                double cant = Convert.ToDouble(Cantidadtxt);
                double preciocomp = Convert.ToDouble(Productos.Preciocompra);
                double precioventa = Convert.ToDouble(Productos.Precioventa);
                Totaltxt = (cant * preciocomp).ToString();
                Ganancia = cant * precioventa - cant * preciocomp;
            }
            else
            {
                Application.Current.MainPage.DisplayAlert("Error", "Ingrese un valor", "OK");
            }
        }
        #endregion
        #region COMANDOS
        public Command Insertarcommand { get; }
        #endregion
    }
}
