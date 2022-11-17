using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using EcomoneyAdmin.Vistas.Config;

namespace EcomoneyAdmin.VistaModelo
{
    public class VMmenuconfig:BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        #endregion

        #region CONSTRUCTOR
        public VMmenuconfig(INavigation navigation)
        {
            Navigation = navigation;
            Volvercomamd = new Command(async () => await Volver());
            NavegarRecolectoresconfigcomamd = new Command(async () => await Navegarrecolectoresconfig());
        }
        #endregion

        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        #endregion

        #region PROCESOS
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }
        
        private async Task Navegarrecolectoresconfig()
        {
            await Navigation.PushAsync(new Recolectoresconfig());
        }
        #endregion

        #region COMANDOS
        public Command Volvercomamd { get; }        
        public Command NavegarRecolectoresconfigcomamd { get; }                
        #endregion
    }
}
