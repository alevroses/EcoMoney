using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using EcomoneyAdmin.Datos;
using EcomoneyAdmin.Modelo;
using Firebase.Auth;
using EcomoneyAdmin.Conexiones;

namespace EcomoneyAdmin.VistaModelo
{
    internal class VMrecolectoresconfig:BaseViewModel
    {
        #region VARIABLES
        string txtnombre;
        string txtcorreo;
        string txtidentificacion;
        string txtcontraseña;
        #endregion

        #region CONSTRUCTOR
        public VMrecolectoresconfig(INavigation navigation)
        {
            Navigation = navigation;
            Insertarcomamd = new Command(async () => await InsertarRecolectores());
            Volvercomamd = new Command(async () => await Volver());
        }
        #endregion

        #region OBJETOS
        public string Txtcontraseña
        {
            get { return txtcontraseña; }
            set { SetValue(ref txtcontraseña, value); }
        }

        public string Txtnombre
        {
            get { return txtnombre; }
            set { SetValue(ref txtnombre, value); }
        }

        public string Txtidentificacion
        {
            get { return txtidentificacion; }
            set { SetValue(ref txtidentificacion, value); }
        }

        public string Txtcorreo
        {
            get { return txtcorreo; }
            set { SetValue(ref txtcorreo, value); }
        }
        #endregion

        #region PROCESOS
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }

        private async Task InsertarRecolectores()
        {
            var funcion = new Drecolectores();
            var parametros = new Mrecolectores();
            
            parametros.Nombre= Txtnombre;
            parametros.Identificacion = Txtidentificacion;
            parametros.Correo = Txtcorreo;
            parametros.Estado = "Activo";
            
            var estadofuncion = await funcion.InsertarRecolectores(parametros);

            if(estadofuncion == true)
            {
                await CrearCorreo(Txtcorreo, Txtcontraseña);
            }            
        }

        private async Task CrearCorreo(string correo, string contraseña)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constantes.WebapyFirebase));
            await authProvider.CreateUserWithEmailAndPasswordAsync(correo, contraseña);
            await DisplayAlert("Estado", "Registro realizado", "Ok");
        }
        #endregion

        #region COMANDOS
        public Command Insertarcomamd { get; }
        public Command Volvercomamd { get; }
        #endregion
    }
}
