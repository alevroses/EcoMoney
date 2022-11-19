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
    public class VMasignaciones:BaseViewModel
    {
        #region VARIABLES
        string idrecolector;
        public static string idsolicitud;
        string txtidentificacion;
        string txtnombreRecolector;
        #endregion

        #region CONSTRUCTOR
        public VMasignaciones(INavigation navigation)
        {
            Navigation = navigation;
            Insertarcomamd = new Command(async () => await Insertarasignaciones());
            Volvercomamd = new Command(async () => await Volver());
        }
        #endregion

        #region OBJETOS
        public string Idrecolector
        {
            get { return idrecolector; }
            set { SetValue(ref idrecolector, value); }
        }

        public string TxtnombreRecolector
        {
            get { return txtnombreRecolector; }
            set { SetValue(ref txtnombreRecolector, value); }
        }

        public string Txtidentificacion
        {
            get { return txtidentificacion; }
            set { SetValue(ref txtidentificacion, value); }
        }
        #endregion

        #region PROCESOS
        public async Task Insertarasignaciones()
        {
            var funcion = new Dasignaciones();
            var parametros = new Masignaciones();
            parametros.Estado = "Pendiente";
            parametros.Idrecolector = Idrecolector;
            parametros.Idsolicitud = idsolicitud;

            var estadofuncion = await funcion.Insertar(parametros);

            if (estadofuncion == true)
            {
                await DisplayAlert("Registrado", "Registro realizado", "Ok");
            }
        }

        private async Task BuscarRecolectores()
        {
            var funcion = new Drecolectores();
            var parametros = new Mrecolectores();
            parametros.Identificacion = Txtidentificacion;

            var lista = await funcion.Buscarrecolectores(parametros);

            foreach (var data in lista)
            {
                TxtnombreRecolector = data.Nombre;
                Idrecolector = data.Idrecolectores;
            }
        }

        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        #endregion

        #region COMANDOS
        public Command Insertarcomamd { get; }
        public Command Volvercomamd { get; }
        #endregion
    }
}
