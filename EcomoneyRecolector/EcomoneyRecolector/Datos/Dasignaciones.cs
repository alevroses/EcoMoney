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
    public class Dasignaciones
    {
        public async Task<List<Masignaciones>> Mostrarasignaciones(Masignaciones parametrosPedir)
        {
            return (await Constantes.firebase
                .Child("Asignaciones")
                .OrderByKey()
                .OnceAsync<Masignaciones>()).Where(a => a.Object.idrecolector == parametrosPedir.idrecolector).Select(item => new Masignaciones
                {
                    idsolicitud = item.Object.idsolicitud
                }).ToList();
        }
    }
}
