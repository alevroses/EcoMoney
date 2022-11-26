using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Database.Query;
using EcomoneyRecolector.Modelo;
using EcomoneyRecolector.Conexiones;
using System.IO;
using Firebase.Storage;

namespace EcomoneyRecolector.Datos
{
    public class Dclientes
    {
        string rutafoto;
        public async Task Insertarclientes(Mclientes parametros)
        {
            await Constantes.firebase
                .Child("Clientes")
                .PostAsync(new Mclientes()
                {
                    Direccion = parametros.Direccion,
                    FotoFachada = parametros.FotoFachada,
                    Geo = parametros.Geo,
                    IdDepa = parametros.IdDepa,
                    IdDis = parametros.IdDis,
                    IdPais = parametros.IdPais,
                    IdPro = parametros.IdPro,
                    IdZona = parametros.IdZona,
                    Identificacion = parametros.Identificacion,
                    NombresApe = parametros.NombresApe,
                    Kgacumulados = parametros.Kgacumulados,
                    Puntos = parametros.Puntos,
                    Totalcobrado = parametros.Totalcobrado,
                    Totalporcobrar = parametros.Totalporcobrar
                });
        }

        public async Task<string> Subirfotofachada(Stream imageStream, string Identificacion)
        {
            var stroageImage = await new FirebaseStorage("ecomoney-13888.appspot.com")
                .Child("Fachadasclientes")
                .Child(Identificacion + ".jpg")
                .PutAsync(imageStream);
            rutafoto = stroageImage;
            return rutafoto;
        }
    }
}
