using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcomoneyRecolector.Conexiones;
using EcomoneyRecolector.Datos;
using EcomoneyRecolector.Modelo;

namespace EcomoneyRecolector.Datos
{
    public class Drecolectores
    {
        public async Task<List<Mrecolectores>> Mostrarrecolectores(Mrecolectores parametrosPedir)
        {
            return (await Constantes.firebase
                .Child("Recolectores")
                .OnceAsync<Mrecolectores>()).Where(a=>a.Object.Correo==parametrosPedir.Correo).Select(item => new Mrecolectores
                {
                    Nombre = item.Object.Nombre,
                    Idrecolector = item.Key
                }).ToList();
        }
    }
}
