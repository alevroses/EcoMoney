using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using EcomoneyAdmin.Datos;
using EcomoneyAdmin.Modelo;

namespace EcomoneyAdmin.VistaModelo
{
    public class VMproductosconfig:BaseViewModel
    {
        #region VARIABLES
        public string descripcion;
        public string preciocompra;
        public string precioventa;
        public string unidadmedida;
        public string color;
        public string estado;
        #endregion

        #region CONSTRUCTOR
        public VMproductosconfig(INavigation navigation)
        {
            Navigation = navigation;
            Insertarcomamd = new Command(async () => await InsertarProductos());
            Volvercomamd = new Command(async () => await Volver());
        }
        #endregion

        #region OBJETOS
        public string txtDescripcion
        {
            get { return descripcion; }
            set { SetValue(ref descripcion, value); }
        }

        public string txtPreciocompra 
        {
            get { return preciocompra; }
            set { SetProperty(ref preciocompra, value); }
        }

        public string txtPrecioventa
        {
            get { return precioventa; }
            set { SetProperty(ref precioventa, value); }
        }

        public string txtUndmedida
        {
            get { return unidadmedida; }
            set { SetProperty(ref unidadmedida, value); }
        }

        public string txtColor
        {
            get { return color; }
            set { SetProperty(ref color, value); }
        }
        #endregion

        #region PROCESOS
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }

        public async Task InsertarProductos()
        {
            var funcion = new Dproductos();
            var parametros = new Mproductos();
            parametros.Descripcion = txtDescripcion;
            parametros.Precioventa = txtPrecioventa;
            parametros.Preciocompra = txtPreciocompra;
            parametros.Und = txtUndmedida;
            parametros.Color = txtColor;
            parametros.Icono = "-";
            parametros.Estado = "Activo";

            var estadofuncion = await funcion.InsertarProductos(parametros);

            if (estadofuncion == true)
            {
                await DisplayAlert("Registrado", "Registro realizado correctamente", "Ok");
            }
        }
        
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public Command Insertarcomamd { get; }
        public Command Volvercomamd { get; }
        #endregion
    }
}
