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
    public class Dsolicitudesrecojo
    {
        public async Task InsertarSolicitud(Msolicitud parametros)
        {
            await Constantes.firebase
                .Child("Solicitudes") //ver nombre en Firebase
                .PostAsync(new Msolicitud()
                {
                    Estado = parametros.Estado,
                    Fecha = parametros.Fecha,
                    Idcliente = parametros.Idcliente,
                    Idturno = parametros.Idturno
                });
        }
    }
}
