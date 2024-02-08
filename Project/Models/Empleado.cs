using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    [Table("Empleado")]
    public partial class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idEmpleado { get; set; }

        [Required]
        [StringLength(20)]
        public string? PrimerNombre { get; set; }
        [Required]
        [StringLength(20)]
        public string? SegundoNombre { get; set; }

        [Required]
        [StringLength(20)]
        public string? ApellidoParterno { get; set; }

        [Required]
        [StringLength(20)]
        public string? ApellidoMaterno { get; set; }

        [Required]
        [StringLength(10)]
        public string? Cedula { get; set; }

        [Required]
        [StringLength(50)]
        public string? Direccion { get; set; }

        [Required]
        [StringLength(10)]
        public string? Telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string? Email { get; set; }

        [Required]
        [StringLength(20)]
        public string? Contraseña { get; set; }

        [Required]
        [StringLength(20)]
        public string? Rol { get; set; }

        [Required]
        [StringLength(6)]
        public string? CodAdmin { get; set; }

        public virtual ICollection<DetalleCompra>? DetalleCompras { get; set; }

    }
}
