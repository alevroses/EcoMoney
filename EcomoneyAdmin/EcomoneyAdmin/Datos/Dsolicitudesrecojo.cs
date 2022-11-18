using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EcomoneyAdmin.Modelo;
using EcomoneyAdmin.Conexiones;
using Firebase.Database.Query;
using System.Linq;

namespace EcomoneyAdmin.Datos
{
    public class Dsolicitudesrecojo
    {
        public async Task <List<Msolicitudesrecojo>> Mostrarsolicitudesrecojo()
        {
            return(await Constantes.firebase
                .Child("Solicitudes")
                .OnceAsync<Msolicitudesrecojo>())
                .Select(item => new Msolicitudesrecojo
                {
                    Estado = item.Object.Estado,
                    Fecha = item.Object.Fecha,
                    Idsolicitud = item.Key
            }).ToList();
        }
    }
}
