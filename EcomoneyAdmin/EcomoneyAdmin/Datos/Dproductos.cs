using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EcomoneyAdmin.Modelo;
using EcomoneyAdmin.Conexiones;
using Firebase.Database.Query;

namespace EcomoneyAdmin.Datos
{
    public class Dproductos
    {
        public async Task<bool> InsertarProductos(Mproductos parametros)
        {
            await Constantes.firebase
                .Child("Productos")
                .PostAsync(new Mproductos()
                {
                    Descripcion = parametros.Descripcion,
                    Estado = parametros.Estado,
                    Preciocompra = parametros.Preciocompra,
                    Precioventa = parametros.Precioventa,
                    Color = parametros.Color,
                    Icono = parametros.Icono,
                    Und = parametros.Und
                });
            return true;
        }
    }
}
