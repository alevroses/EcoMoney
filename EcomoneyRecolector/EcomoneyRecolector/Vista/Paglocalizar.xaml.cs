using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Xamarin.Forms.GoogleMaps;
using Xamarin.Essentials;

namespace EcomoneyRecolector.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Paglocalizar : ContentPage
    {
        //Pin punto = new Pin()
        //public static double latitud = 0;
        //public static double longitud = 0;
        public Paglocalizar()
        {
            InitializeComponent();
        }

        /*
         private void map_PinDragEnd(object sender, Xamarin.Forms.GoogleMaps.PinDragEventArgs e)
        {
            var posicion = new Position(e.Pin.Position.Latitude, e.Pin.Position.Longitude);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(posicion, Distance.FromMeters(500)));
            latitud = e.Pin.Position.Latitude;
            longitud = e.Pin.Position.Longitude;
        }

        protected override async void OnAppearing()
        {
            punto = new Pin()
            {
                Label = "Tu ubicación",
                Type = PinType.Place,
                Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("camion.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "camion.png", WidthRequest = 64, HeightRequest = 64 }),
                Position = new Position(0, 0),
                IsDraggable = true
            };
            map.Pins.Add(punto);
            await LocalizacionActual();
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

         */


    }
}