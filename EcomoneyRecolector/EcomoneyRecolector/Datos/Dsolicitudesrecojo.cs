using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Database.Query;
using EcomoneyRecolector.Modelo;
using EcomoneyRecolector.Conexiones;

namespace EcomoneyRecolector.Datos
{
    public class Dsolicitudesrecojo
    {
        public async Task<List<Msolicitudesrecojo>> MostrarsolicitRecojo(Msolicitudesrecojo parametrosPedir)
        {
            return (await Constantes.firebase
                .Child("Solicitudes") //revisar BD
                .OrderByKey()
                .OnceAsync<Msolicitudesrecojo>()).Where(a => a.Object.Estado == "Asignado").Where(b => b.Key == parametrosPedir.Idsolicitud).Select(item => new Msolicitudesrecojo
                {
                    Idcliente = item.Object.Idcliente,
                    Fecha = item.Object.Fecha,
                    Estado = item.Object.Estado,
                    Idturno = item.Object.Idturno
                }).ToList();
        }

        public async Task Eliminarsolicitud(Msolicitudesrecojo parametros)
        {
            var dataEliminar = (await Constantes.firebase
                .Child("Solicitudes")
                .OnceAsync<Msolicitudesrecojo>())
                .Where(a => a.Key == parametros.Idsolicitud)
                .FirstOrDefault();
            await Constantes.firebase.Child("Solicitudes")
                .Child(dataEliminar.Key).DeleteAsync();
        }
    }
}
