using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("Adquisicion")]
    public class Adquisicion
    {
        [Key]
        [Column("Id_Adquisicion")]
        public int Id { get; set; }
        [Column("Presupuesto")]
        public decimal Presupuesto { get; set; }
        [Column("Id_servicio")]
        public int Id_Servicio { get; set; }
        [Column("Cantidad")]
        public int Cantidad { get; set; }
        [Column("Valor_Unitario")]
        public decimal Valor_Unitario { get; set; }
        [Column("Valor_Total")]
        public decimal Valor_Total { get; set; }
        [Column("Fecha_Adquisicion")]
        public string Fecha_Adquisicion { get; set; }
        [Column("Id_proveedor")]
        public int Id_Proveedor { get; set; }
        [Column("Id_unidad")]
        public int Id_Unidad { get; set; }
        [Column("Documentacion")]
        public string Documentacion { get; set; }
        [Column("Estado")]
        public int Estado { get; set; }
    }
}
