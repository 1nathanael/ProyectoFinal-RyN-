//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoFinal__RyN__.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Salida_Empleado
    {
        public int Id_Salida { get; set; }
        public Nullable<int> Id_Empleado { get; set; }

        [Display(Name ="Tipo de Salida")]
        public string Tipo_Salida { get; set; }
        public string Motivo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        [Display(Name = "Fecha de Salida")]
        public Nullable<System.DateTime> Fecha_Salida { get; set; }
    
        public virtual Empleado Empleado { get; set; }
    }
}
