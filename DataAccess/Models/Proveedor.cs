using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("Proveedor")]
    public class Proveedor : Base
    {
        [Key]
        [Column("Id_Proveedor")]
        public int Id { get; set; }
    }
}
