using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EcomoneyCliente.Conexiones;
using EcomoneyCliente.Modelo;
using Firebase.Database.Query;
using System.Linq;

namespace EcomoneyCliente.Datos
{
    public class Dproductos
    {
        public async Task <List<Mproductos>> MostrarproductosXid(Mproductos parametrosPedir)
        {
            return (await Constantes.firebase
                .Child("Productos")
                .OnceAsync<Mproductos>()).Where(a => a.Key == parametrosPedir.Idproducto).Select(item => new Mproductos
                {
                    Descripcion = item.Object.Descripcion,
                    Icono = item.Object.Icono,
                    Color = item.Object.Color
                }).ToList();
        }
    }
}
