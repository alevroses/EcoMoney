using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.ExternalMaps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Essentials;
using EcomoneyRecolector.VistaModelo;
using EcomoneyRecolector.Datos;
using EcomoneyRecolector.Modelo;

namespace EcomoneyRecolector.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapear : ContentPage
    {
        public static string IdRecolector;
        double latitud = 0;
        double longitud = 0;
        string idcliente;
        string idsolicitud;
        string nombre;
        string direccion;
        string foto;
        string dni;
        Pin punto = new Pin();

        public Mapear()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            punto = new Pin()
            {
                Label = "Tu ubicación",
                Type = PinType.Place,
                Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("truck.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "truck.png", WidthRequest = 64, HeightRequest = 64 }),
                Position = new Position(0, 0),
                IsDraggable = true
            };
            map.Pins.Add(punto);
            await LocalizacionActual();
            await MapearSolicitudes();
        }
        public async Task LocalizacionActual()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {

                        DesiredAccuracy = GeolocationAccuracy.High,
                        Timeout = TimeSpan.FromSeconds(30)
                    });

                }
                if (location == null)
                {
                    await DisplayAlert("Alerta", "Sin acceso al GPS", "OK");
                }
                else
                {
                    latitud = location.Latitude;
                    longitud = location.Longitude;
                    var posicion = new Position(latitud, longitud);
                    punto.Position = new Position(latitud, longitud);
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(posicion, Distance.FromMeters(500)));
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "Sin acceso al GPS", "OK");
            }
        }

        private async Task MapearSolicitudes()
        {
            var funcion = new Dasignaciones();
            var parametros = new Masignaciones();
            parametros.idrecolector = IdRecolector;
            var Listasolicitudes = await funcion.MostrarclientesAsignados(parametros);
            
            foreach (var data in Listasolicitudes)
            {
                string coordenadas = data.Geolocalizacion;
                string label = data.Direccion + "|" + data.Turno + "|" + data.Idcliente + "|" + data.Idsolicitud;
                string[] separadas = coordenadas.Split(',');
                double latitud = Convert.ToDouble(separadas[0]);
                double longitud = Convert.ToDouble(separadas[1]);
                Pin Puntocliente = new Pin();
                Puntocliente = new Pin() //Puntocliente
                {
                    Label = label,
                    Type = PinType.Place,
                    Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("location-pin.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "location-pin.png", WidthRequest = 64, HeightRequest = 64 }),
                    Position = new Position(latitud, longitud),
                    IsDraggable = true
                };
                map.Pins.Add(Puntocliente); //Puntocliente

            }

        }

        private async void btnver_Clicked(object sender, EventArgs e)
        {
            try
            {
                string titulo = map.SelectedPin.Label.ToString();
                string[] separadas = titulo.Split('|');
                idcliente = separadas[2];
                var funcion = new Dclientes();
                var parametros = new Mclientes();
                parametros.Idcliente = idcliente;
                var lista = await funcion.MostrarclientesXid(parametros);

                foreach (var data in lista)
                {
                    nombre = data.NombresApe;
                    direccion = data.Direccion;
                    dni = data.Identificacion;
                    foto = data.FotoFachada;
                    break;
                }

                Vercliente.nombre = nombre;
                Vercliente.direccion = direccion;
                Vercliente.dni = dni;
                Vercliente.foto = foto;
                await Navigation.PushAsync(new Vercliente());
            }
            catch (Exception)
            {
                await DisplayAlert("No permitido", "Accion denegada", "OK");
            }
        }
        

        private async void btnir_Clicked(object sender, EventArgs e)
        {
            try
            {
                string cx = map.SelectedPin.Position.Latitude.ToString();
                string cy = map.SelectedPin.Position.Longitude.ToString();
                string titulo = "Cliente";
                var proceso = await CrossExternalMaps.Current.
                    NavigateTo(titulo, Convert.ToDouble(cx), Convert.ToDouble(cy));
            }
            catch (Exception)
            {
                await DisplayAlert("Sin coordenadas", "Seleccione un destino/ Revise que Google maps este instalado", "OK");
            }
        }

        private async void btnComprar_Clicked(object sender, EventArgs e)
        {
            try
            {
                string titulo = map.SelectedPin.Label.ToString();
                string[] separadas = titulo.Split('|');
                idcliente = separadas[2];
                idsolicitud = separadas[3];

                await Eliminarcomprasincon();
                VMregCompras.idcliente = idcliente;
                VMregCompras.Idsolicitud = idsolicitud;
                await Navigation.PushAsync(new RegCompras());
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        private async Task Eliminarcomprasincon()
        {
            var funcion = new Ddetallecompras();
            var parametros = new Mdetallecompras();
            parametros.Idcliente = idcliente;
            await funcion.EliDcompraSinconfirmar(parametros);
        }
    }
}