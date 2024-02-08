using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    [Table("Proveedor")]
    public partial class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProveedor { get; set; }

        [Required]
        [StringLength(20)]
        public string? NombreProvedor { get; set; }

        [Required]
        [StringLength(20)]
        public string? NombreEmpresa { get; set; }

        [Required]
        [StringLength(50)]
        public string? Direccion { get; set; }

        [Required]
        [StringLength(10)]
        public string? Telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string? Email { get; set; }

        public virtual ICollection<Compra>? Compras { get; set; }
        }
}
