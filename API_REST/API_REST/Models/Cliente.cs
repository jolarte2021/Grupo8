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
    
    public partial class Cliente
    {
        public int Cedula { get; set; }
        public int Nombre { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Contraseña { get; set; }
        public byte Estado { get; set; }
        public int Cod_Rol { get; set; }
    }
}