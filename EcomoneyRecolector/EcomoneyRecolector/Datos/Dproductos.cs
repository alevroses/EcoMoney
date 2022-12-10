using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Firebase.Database.Query;
using EcomoneyRecolector.Modelo;
using EcomoneyRecolector.Conexiones;
using System.IO;
using Firebase.Storage;

namespace EcomoneyRecolector.Datos
{
    public class Dproductos
    {
        public async Task<List<Mproductos>> Mostrarproductos()
        {
            return (await Constantes.firebase
              .Child("Productos")
              .OnceAsync<Mproductos>()).Where(a => a.Key != "Modelo").Select(item => new Mproductos
              {
                  Preciocompra = item.Object.Preciocompra,
                  PreciocompraString = "Precio de compra por " + item.Object.Und + " =S/." + item.Object.Preciocompra,
                  Descripcion = item.Object.Descripcion,
                  Icono = item.Object.Icono,
                  Color = item.Object.Color,
                  Und = item.Object.Und,
                  Idproducto = item.Key,
                  Precioventa = item.Object.Precioventa

              }).ToList();
        }
        
        public async Task<List<Mproductos>> MostrarproductosXid(Mproductos parametrosPedir)
        {
            return (await Constantes.firebase
              .Child("Productos")
              .OnceAsync<Mproductos>()).Where(a => a.Key == parametrosPedir.Idproducto).Select(item => new Mproductos
              {
                  Preciocompra = item.Object.Preciocompra,
                  PreciocompraString = "Precio de compra por " + item.Object.Und + " =S/." + item.Object.Preciocompra,
                  Descripcion = item.Object.Descripcion,
                  Icono = item.Object.Icono,
                  Color = item.Object.Color,
                  Und = item.Object.Und,
                  Idproducto = item.Key,
                  Precioventa = item.Object.Precioventa

              }).ToList();
        }
    }
}
