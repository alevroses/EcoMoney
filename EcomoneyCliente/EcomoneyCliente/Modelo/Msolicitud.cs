using System;
using System.Collections.Generic;
using System.Text;

namespace EcomoneyCliente.Modelo
{
    public class Msolicitud
    {
        public string Idsolicitud { get; set; } //Modelo
        public string Estado { get; set; }
        public string Fecha { get; set; }
        public string Idcliente { get; set; }
        public string Idturno { get; set; }
    }
}
