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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            this.Permiso = new HashSet<Permiso>();
            this.Licencia = new HashSet<Licencia>();
            this.Salida_Empleado = new HashSet<Salida_Empleado>();
            this.Vacaciones = new HashSet<Vacaciones>();
        }
    
        public int Id_Empleado { get; set; }

        [Display(Name ="Codigo del Empleado")]
        public string Codigo_Empleado { get; set; }

        [Display(Name ="Nombre")]
        public string Nombre_Empleado { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }


        [Display(Name = "Departamento")]
        public Nullable<int> Id_Depto { get; set; }


        [Display(Name = "Cargo")]
        public Nullable<int> Id_Cargo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]


        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }
        public Nullable<decimal> Salario { get; set; }
        public bool Status { get; set; }
    
        public virtual Cargo Cargo { get; set; }
        public virtual Departamento Departamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permiso> Permiso { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Licencia> Licencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Salida_Empleado> Salida_Empleado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vacaciones> Vacaciones { get; set; }
    }
}
