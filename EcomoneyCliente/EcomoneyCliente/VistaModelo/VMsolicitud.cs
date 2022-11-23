using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EcomoneyCliente.Datos;
using EcomoneyCliente.Modelo;
using System.ComponentModel;

namespace EcomoneyCliente.VistaModelo
{
    public class VMsolicitud:BaseViewModel
    {
        #region VARIABLES
        bool registroinicial;
        bool registrofinal;
        string idturno; //idturno
        List<Mturno> listaturnos = new List<Mturno>();
        DateTime txtfecha; //string fechaactual;
        #endregion

        #region CONSTRUCTOR
        public VMsolicitud(INavigation navigation, Mclientes cliente)
        {
            Navigation = navigation;
            Cliente = cliente;
            Registroinicial = true;
            Registrofinal = false;
            DependencyService.Get<VMstatusbar>().TransparentarStatusbar();
            Insertarsolicitudcommand = new Command(async () => await Insertarsolicitud());
            Volvercommand = new Command(async () => await Volver());
            Mostrarturnos();
            /*Fechaactual = DateTime.Now.ToString("dd/MM/yyyy");*/
        }
        #endregion

        #region OBJETOS
        public Mturno Selectturno
        {
            get { return selectturno; }
            set { SetProperty(ref selectturno, value);
                Idturno = selectturno.Idturno;
            }
        }

        public string Idturno
        {
            get { return idturno; }
            set { SetValue(ref idturno, value); }
        }

        public List<Mturno> Listaturnos
        {
            get { return listaturnos; }
            set { SetValue(ref listaturnos, value); }

        }

        public DateTime Txtfecha
        {
            get { return txtfecha; }
            set { SetValue(ref txtfecha, value); }
        }

        public bool Registroinicial
        {
            get { return registroinicial; }
            set { SetValue(ref registroinicial, value); }
        }
        public bool Registrofinal
        {
            get { return registrofinal; }
            set { SetValue(ref registrofinal, value); }
        }
        #endregion

        #region PROCESOS
        private async Task Volver()
        {
            await Navigation.PopAsync();
        }

        private async Task Mostrarturnos()
        {
            var funcion = new Dturno();
            Listaturnos = await funcion.Mostrarturnos();

        }

        public async Task Insertarsolicitud()
        {
            if (!string.IsNullOrEmpty(Idturno))
            {
                if (!string.IsNullOrEmpty(Txtfecha.ToString()))
                {
                    var funcion = new Dsolicitudesrecojo();
                    var parametros = new Msolicitud();
                    parametros.Idcliente = Cliente.Idcliente;
                    parametros.Estado = "POR CONFIRMAR";
                    parametros.Fecha = Txtfecha.ToString("dd/MM/yyyy");
                    parametros.Idturno = Idturno;
                    await funcion.InsertarSolicitud(parametros);
                    Registrofinal = true;
                    Registroinicial = false;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Datos incompletos", "Seleccine una fecha", "OK");
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Datos incompletos", "Seleccine un turno", "OK");
            }
        }

        public Mturno selectturno;
        public Mclientes Cliente { get; set; }
        #endregion

        #region COMANDOS
        public Command Insertarsolicitudcommand { get; }
        public Command Volvercommand { get; }
        #endregion
    }
}
