using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EcomoneyAdmin.Modelo;
using EcomoneyAdmin.Conexiones;
using Firebase.Database.Query;

namespace EcomoneyAdmin.Datos
{
    public class Dasignaciones
    {
        public async Task<bool> Insertar(Masignaciones parametros)
        {
            await Constantes.firebase
                .Child("Asignaciones")
                .PostAsync(new Masignaciones()
                {
                    Idsolicitud = parametros.Idsolicitud,
                    Estado = parametros.Estado,
                    Idrecolector = parametros.Idrecolector
                });
            return true;
        }
    }
}
