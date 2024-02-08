using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    [Table("Cliente")]
    public partial class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(20)]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string? ApellidoMaterno { get; set; }

        [Required][StringLength(20)]
        public string? ApellidoPaterno { get; set; }

        [Required]
        [StringLength(10)]
        public string? Cedula { get; set; }

        [Required][StringLength (10)]
        public string? telefono { get; set; }

        [Required][StringLength(50)]
        public string? email { get; set; }

        [Required]
        public int? NiveLealtad { get; set;}

        [Required] 
        public int? PuntosRecompensa { get; set; }

        [Required]
        [MaxLength(20)]
        public string? contraseña { get; set; }

        public virtual ICollection<Venta>? Ventas { get; set; }
    }
}
