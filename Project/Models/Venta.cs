using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    [Table ("Venta")]
    public partial class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idVenta { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Column("ImporteTotal", TypeName = "decimal(10, 2)")]
        public decimal ImporteTotal { get; set; }

        [Required]
        public int CantidadTotal { get; set; }

        [ForeignKey ("Cliente")]
        public int idCliente { get; set;}   
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<DetalleVenta>? DetalleVentas { get; set; }

    }
}
