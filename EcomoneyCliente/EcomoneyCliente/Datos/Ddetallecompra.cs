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

                var funcionProd = new Dproductos();
                var parametrosProd = new Mproductos();
                parametrosProd.Idproducto = item.Object.Idproducto;
                var listaPro = await funcionProd.MostrarproductosXid(parametrosProd);

                foreach (var itemPro in listaPro)
                {
                    parametros.DescripcionPro = itemPro.Descripcion;
                    parametros.Icono = itemPro.Icono;   
                }

                listaDcompra.Add(parametros);
            }
            return listaDcompra.ToList();
        }
    }
}
