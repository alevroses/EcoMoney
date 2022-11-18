using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EcomoneyAdmin.Modelo;
using EcomoneyAdmin.Conexiones;
using Firebase.Database.Query;

namespace EcomoneyAdmin.Datos
{
    public class Dpatron
    {
        public async Task<bool> Insertar(Mrecolectores parametros)
        {
            await Constantes.firebase
                .Child("Tu tabla")
                .PostAsync(new Mrecolectores()
                {
                    Correo = parametros.Correo,
                    Estado = parametros.Estado,
                    Identificacion = parametros.Identificacion,
                    Nombre = parametros.Nombre
                });
            return true;
        }
    }
}
