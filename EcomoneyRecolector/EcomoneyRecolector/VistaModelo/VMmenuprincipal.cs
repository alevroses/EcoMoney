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
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace EcomoneyRecolector.VistaModelo
{
    internal class VMmenuprincipal:BaseViewModel
    {
        #region VARIABLES
        string txtnombre;
        string idrecolector;
        string txtcontadorasig;
        #endregion

        #region CONSTRUCTOR
        public VMmenuprincipal(INavigation navigation)
        {
            Navigation = navigation;
            Afiliarcommand = new Command(async () => await Afiliar());
            Mapearcommand = new Command(async () => await EjecutarMapear());
            obtenerdatosRecolector();
        }
        #endregion

        #region OBJETOS
        public string Txtnombre
        {
            get { return txtnombre; }
            set { SetValue(ref txtnombre, value); }
        }
        public string Idrecolector
        {
            get { return idrecolector; }
            set { SetValue(ref idrecolector, value); }
        }
        /*public string Txtcontadorasig
        {
            get { return txtcontadorasig; }
            set { SetValue(ref txtcontadorasig, value); }
        }*/
        #endregion

        #region PROCESOS
        public async Task obtenerdatosRecolector() //<string>
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constantes.WebapyFirebase));
                var savedfirebaseauth = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                var RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                string correo = savedfirebaseauth.User.Email;
                var funcion = new Drecolectores();
                var parametros = new Mrecolectores();
                parametros.Correo = correo;
                var data = await funcion.Mostrarrecolectores(parametros);
                foreach (var item in data)
                {
                    Txtnombre = item.Nombre;
                    Idrecolector = item.Idrecolector;
                    break;
                }
                //await Contarasignaciones();
                //return Txtcontadorasig;
            }
            catch (Exception)
            {
                //return Txtcontadorasig;
            }
        }

        private async Task Afiliar()
        {
            await Navigation.PushAsync(new Agregarcliente());
        }
        
        private async Task EjecutarMapear()
        {
            await Navigation.PushAsync(new Mapear());
            /*if (Txtcontadorasig != "0")
            {
                //Mapear.IdRecolector = Idrecolector;
                await Navigation.PushAsync(new Mapear());
            }
            else
            {
                await DisplayAlert("Sin asignaciones", "No tienes clientes asignados", "OK");
            }
            */
        }
        #endregion

        #region COMANDOS
        public Command Afiliarcommand { get; }
        public Command Mapearcommand { get; }
        #endregion
    }
}
