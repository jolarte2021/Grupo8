using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelCliente.Entidades
{
    public class Reserva
    {
        public int Cod_Reserva { get; set; }

        [Display(Name = "Sede:")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int Cod_Sede { get; set; }

        [Display(Name = "Fecha Reservación:")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public System.DateTime Fecha { get; set; }

        public string FechaMuestra { get; set; }

        [Display(Name = "Cedula Cliente:")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int Cedula_Cliente { get; set; }

        [Display(Name = "Forma Pago:")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Cod_Pago { get; set; }

        [Display(Name = "#Personas:")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int Cantidad_personas { get; set; }
       
        public Sede ObjSede { get; set; }

        public string NombreSede { get; set; }
        

    }
}