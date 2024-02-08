using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    [Table("DetalleCompra")]
    public partial class DetalleCompra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idDetalleCompra { get; set; }

        [Required]
        public DateTime FechaFactura { get; set; }

        [Required]
        public int CostoTolal { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public int IVA { get; set; }

        public int EmpleadoId { get; set; }
        public int CompraId { get; set; }

        public int ProductoId { get; set; }

        [ForeignKey("CompraId")]
        public virtual Compra Compra { get; set; }

        [ForeignKey("EmpleadoId")]
        public virtual Empleado Empleado { get; set; }

        [ForeignKey("roductoId")]
        public virtual Producto Producto { get; set; }
    }
}