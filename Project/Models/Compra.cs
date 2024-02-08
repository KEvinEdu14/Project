using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    [Table("Compra")]
    public partial class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCompra { get; set; }

        [Required]
        public int CostoTotal { get; set; }

        [Required]
        public DateTime FechaCompra { get; set; }

        [Required]
        [StringLength(50)]
        public string? TipoComprobante { get; set; }

        public int ProveedorId { get; set; }
        [ForeignKey("ProveedorId")]
        public virtual Proveedor Proveedor { get; set; }

        public virtual ICollection<DetalleCompra>? DetalleCompras { get; set; }
    }
}
