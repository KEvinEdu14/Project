using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    [Table("Producto")]
    public partial class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }

        [Required]
        [StringLength(20)]
        public string? NombreProducto { get; set; }

        [Required]
        [Column("Precio", TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }

        [Required]
        [StringLength(20)]
        public string? Marca { get; set; }


        [Required]
        [StringLength(20)]
        public string? Categoria { get; set; }

        [Required]
        public int Stock { get; set; }
        public virtual ICollection<DetalleVenta>? DetalleVentas { get; set; }
        public virtual ICollection<DetalleCompra>? DetalleCompras { get; set; }
    }
}
