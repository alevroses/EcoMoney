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
    public class Ddetallecompra
    {
        public async Task <List<Mdetallecompra>> MostrarDcompra(string Idcliente)
        {
            var listaDcompra = new List<Mdetallecompra>();
            var data = (await Constantes.firebase
                .Child("Detallecompra")
                .OrderByKey()
                .OnceAsync<Mdetallecompra>()).Where(a => a.Object.Idcliente == Idcliente);
            
            foreach(var item in data)
            {
                var parametros = new Mdetallecompra();
                parametros.Preciocompra = "Precio de compra por " + item.Object.Und + " = S/." + item.Object.Preciocompra;
                parametros.Cantidad = item.Object.Cantidad;
                parametros.Total = "S/. " + item.Object.Total;
                parametros.Und = item.Object.Und;
                parametros.Fecha = item.Object.Fecha;

                var funcionProd = new Dproductos();
                var parametrosProd = new Mproductos();
                parametrosProd.Idproducto = item.Object.Idproducto;
                var listaPro = await funcionProd.MostrarproductosXid(parametrosProd);

                var datos = listaPro.FirstOrDefault();
                parametros.DescripcionPro = datos.Descripcion;
                parametros.Icono = datos.Icono;
                parametros.Color = datos.Color;

                listaDcompra.Add(parametros);
            }
            return listaDcompra.ToList();
        }
    }
}
