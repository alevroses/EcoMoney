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
    }
}
