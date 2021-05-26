using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelCliente.Entidades
{
    public class Sede
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}