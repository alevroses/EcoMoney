using System;
using System.Collections.Generic;
using System.Text;
using EcomoneyCliente.Modelo;
using EcomoneyCliente.Conexiones;
using System.Threading.Tasks;
using System.Linq;

namespace EcomoneyCliente.Datos
{
    public class Dclientes
    {
        public async Task<List<Mclientes>> Validarcliente(Mclientes parametrosPedir)
        {
            return (await Constantes.firebase
                .Child("Clientes")
                .OnceAsync<Mclientes>()).Where(a => a.Object.Identificacion == parametrosPedir.Identificacion).Select(item => new Mclientes
                {
                    Identificacion = item.Object.Identificacion,
                    NombresApe = item.Object.NombresApe,
                    FotoFachada = item.Object.FotoFachada,
                    Idcliente = item.Key,
                    Totalcobrado = item.Object.Totalcobrado,
                    Totalporcobrar = item.Object.Totalporcobrar,
                    Puntos = item.Object.Puntos,
                    Kgacumulados = item.Object.Kgacumulados,
                }).ToList();
        }
    }
}
