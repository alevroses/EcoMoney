using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using EcomoneyRecolector.Vista;
using EcomoneyRecolector.Datos;
using EcomoneyRecolector.Modelo;
using EcomoneyRecolector.Conexiones;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Acr.UserDialogs;
using Firebase.Auth;

namespace EcomoneyRecolector.VistaModelo
{
    public class VMlogin:BaseViewModel
    {
        #region VARIABLES
        string txtcorreo;
        string txtpass;
        #endregion

        #region CONSTRUCTOR
        public VMlogin(INavigation navigation)
        {
            Navigation = navigation;
            //Logincomamd = new Command(async () => await proceso());
        }
        #endregion

        #region OBJETOS
        public string Txtcorreo
        {
            get { return txtcorreo; }
            set { SetValue(ref txtcorreo, value); }
        }
        public string Txtpass
        {
            get { return txtpass; }
            set { SetValue(ref txtpass, value); }
        }
        #endregion 

        #region PROCESOS
        private async Task<bool> Iniciarsesion()
        {
            try
            {
                UserDialogs.Instance.ShowLoading("Validando datos...");
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constantes.WebapyFirebase));
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(Txtcorreo, Txtpass);
                var serializarToken = JsonConvert.SerializeObject(auth);
                Preferences.Set("MyFirebaseRefreshToken", serializarToken);
                return true;
            }
            catch (Exception)
            {
                UserDialogs.Instance.HideLoading();
                await App.Current.MainPage.DisplayAlert("Error", "Datos incorrectos", "OK");
                return false;
            }
        }
        #endregion

        #region COMANDOS
        public Command Logincomamd { get; }
        
        #endregion
    }
}
