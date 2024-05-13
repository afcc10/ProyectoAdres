using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("Servicio")]
    public class Servicio : Base
    {
        [Key]
        [Column("Id_Servicio")]
        public int Id { get; set; }
    }
}
