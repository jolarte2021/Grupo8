//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_REST.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reserva
    {
        private Prueba2Entities2 db = new Prueba2Entities2();

        public int Cod_Reserva { get; set; }
        public int Cod_Sede { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Cedula_Cliente { get; set; }
        public string Cod_Pago { get; set; }
        public int Cantidad_personas { get; set; }

        public Sede ObjSede {
            get
            {
                return db.Sedes.FindAsync(Cod_Sede).Result;
            }
        }
    }
}
