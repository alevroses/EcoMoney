using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;
using EcomoneyCliente.Modelo;
using EcomoneyCliente.Conexiones;

namespace EcomoneyCliente.Datos
{
    public class Dturno
    {
        public async Task<List<Mturno>> Mostrarturnos()
        {
            return (await Constantes.firebase
                .Child("Turnosrecojo")
                .OnceAsync<Mturno>()).Select(item => new Mturno
                {
                    Idturno = item.Key,
                    Turno = item.Object.Turno
                }).ToList();
        }
    }
}
