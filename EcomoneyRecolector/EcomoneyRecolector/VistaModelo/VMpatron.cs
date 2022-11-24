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
    public class VMpatron:BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        #endregion

        #region CONSTRUCTOR
        public VMpatron(INavigation navigation)
        {
            Navigation = navigation;
            Logincomamd = new Command(async () => await proceso());
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
        public async Task proceso()
        {

        }
        
        public void ProcesoSimple()
        {

        }
        #endregion

        #region COMANDOS
        public Command Logincomamd { get; }
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
