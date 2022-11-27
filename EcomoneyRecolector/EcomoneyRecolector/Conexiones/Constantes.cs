using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace EcomoneyRecolector.Conexiones
{
    public class Constantes
    {
        public static FirebaseClient firebase = new FirebaseClient("https://ecomoney-13888-default-rtdb.firebaseio.com/");
        public const string WebapyFirebase = "AIzaSyBAuFoH3nLHEuZxrVrR7PId37tkOpyEv0g";
        public const string GoogleMapsApiKey = "AIzaSyD07p-6HM92_eIEXTbcvQP1gNYCRhl65Bw";
    }
}
