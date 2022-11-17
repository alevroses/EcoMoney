using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EcomoneyAdmin.Modelo;
using EcomoneyAdmin.Conexiones;
using Firebase.Database.Query;

namespace EcomoneyAdmin.Datos
{
    public class Drecolectores
    {
        public async Task<bool> InsertarRecolectores(Mrecolectores parametros)
        {
            await Constantes.firebase
                .Child("Recolectores")
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
