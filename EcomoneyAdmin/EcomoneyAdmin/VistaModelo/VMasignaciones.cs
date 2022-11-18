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
