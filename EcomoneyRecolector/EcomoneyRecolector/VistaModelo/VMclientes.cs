using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using EcomoneyRecolector.Vista;
using EcomoneyRecolector.Datos;
using EcomoneyRecolector.Modelo;
using Plugin.Media.Abstractions;

namespace EcomoneyRecolector.VistaModelo
{
    public class VMclientes:BaseViewModel
    {
        #region VARIABLES
        public List<Mubicaciones> listpais = new List<Mubicaciones>();
        public List<Mubicaciones> listdepa = new List<Mubicaciones>();
        public List<Mubicaciones> listprov = new List<Mubicaciones>();
        public List<Mubicaciones> listdist = new List<Mubicaciones>();
        public List<Mubicaciones> listzona = new List<Mubicaciones>();
        Mubicaciones selectPais;
        Mubicaciones selectDepa;
        Mubicaciones selectProv;
        Mubicaciones selectDist;
        Mubicaciones selectZona;
        public bool panelGeolocalizacion = false;
        public bool panelRegistro = true;
        public bool panelRegistrado = false;
        private string Idpais;
        private string Iddepa;
        private string Idprov;
        private string Iddist;
        private string Idzona;
        string rutafoto;
        MediaFile foto;
        public string Direccion;
        public string FotoFachada;
        public static string Geolocalizacion = "0";
        public string IdDepa;
        public string IdDis;
        public string IdPais;
        public string IdPro;
        public string IdZona;
        public string Identificacion;
        public string NombresApe;
        #endregion

        #region CONSTRUCTOR
        public VMclientes(INavigation navigation)
        {
            Navigation = navigation;
            //Logincomamd = new Command(async () => await proceso());
        }
        #endregion

        #region OBJETOS
        public Mubicaciones SelectPais
        {
            get { return selectPais; }
            set
            {
                SetProperty(ref selectPais, value);
                Idpais = selectPais.Idpais;
            }
        }

        public Mubicaciones SelectDepa
        {
            get { return selectDepa; }
            set
            {
                SetProperty(ref selectDepa, value);
                Iddepa = selectDepa.Iddepartamento;

            }
        }
        public Mubicaciones SelectProv
        {
            get { return selectProv; }
            set
            {
                SetProperty(ref selectProv, value);
                Idprov = selectProv.Idprovincia;

            }
        }
        public Mubicaciones SelectDist
        {
            get { return selectDist; }
            set
            {
                SetProperty(ref selectDist, value);
                Iddist = selectDist.Iddistrito;

            }
        }
        public Mubicaciones SelectZona
        {
            get { return selectZona; }
            set
            {
                SetProperty(ref selectZona, value);
                Idzona = selectZona.Idzona;

            }
        }

        public List<Mubicaciones> Listpais
        {
            get { return listpais; }
            set { SetValue(ref listpais, value); }
        }
        public List<Mubicaciones> ListDepa
        {
            get { return this.listdepa; }
            set
            {
                SetValue(ref this.listdepa, value);
            }
        }
        public List<Mubicaciones> ListProv
        {
            get { return this.listprov; }
            set
            {
                SetValue(ref this.listprov, value);
            }
        }
        public List<Mubicaciones> ListDistr
        {
            get { return this.listdist; }
            set
            {
                SetValue(ref this.listdist, value);
            }
        }
        public List<Mubicaciones> ListZona
        {
            get { return this.listzona; }
            set
            {
                SetValue(ref this.listzona, value);
            }
        }

        public bool PanelGeolocalizacion
        {
            get { return this.panelGeolocalizacion; }
            set
            {
                SetValue(ref this.panelGeolocalizacion, value);
            }
        }
        public bool Panelregistro
        {
            get { return this.panelRegistro; }
            set
            {
                SetValue(ref this.panelRegistro, value);
            }
        }
        public bool PanelRegistrado
        {
            get { return this.panelRegistrado; }
            set
            {
                SetValue(ref this.panelRegistrado, value);
            }
        }
        public string Direcciontxt
        {
            get
            {
                return Direccion;
            }
            set
            {
                SetProperty(ref Direccion, value);
            }
        }
        public string Identificaciontxt
        {
            get
            {
                return Identificacion;
            }
            set
            {
                SetProperty(ref Identificacion, value);
            }
        }
        public string NombresApellidtxt
        {
            get
            {
                return NombresApe;
            }
            set
            {
                SetProperty(ref NombresApe, value);
            }
        }
        #endregion

        #region PROCESOS
        private async Task Mostrarpais()
        {
            var funcion = new Dubicaciones();
            Listpais = await funcion.Mostrarpais();
        }
        public async Task MostrarDepa()
        {
            var funcion = new Dubicaciones();
            this.ListDepa = await funcion.Mostrardepartamento();
        }
        public async Task MostrarProv()
        {
            var funcion = new Dubicaciones();
            this.ListProv = await funcion.MostrarProvincia();
        }
        public async Task MostrarDist()
        {
            var funcion = new Dubicaciones();
            this.ListDistr = await funcion.Mostrardistrito();
        }
        public async Task MostrarZonas()
        {
            var funcion = new Dubicaciones();
            this.ListZona = await funcion.MostrarZona();
        }
        #endregion

        #region COMANDOS
        public Command Logincomamd { get; }
        //public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
