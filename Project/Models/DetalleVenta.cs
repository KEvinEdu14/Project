using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProyectoFinal.Models
{
    [Table ("Detalleventa")]
    public partial class DetalleVenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetalleVenta { get; set; }

        [Required]
        public int IVA { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Column("PrecioUnidad", TypeName = "decimal(10, 2)")]
        [Required]
        public decimal PrecioUnidad { get; set; }

        [Required,NotNull]
        public DateTime FechaRegistro { get; set; }

        [Required]
        public int Descuento { get; set; }

        [ForeignKey ("Producto")]
        public int? idProducto { get; set; }
        public virtual Producto? Producto { get; set; }

        [ForeignKey("Venta")]
        public int? idVenta { get; set; }
        public virtual Venta? Venta { get; set; }

    }
}
