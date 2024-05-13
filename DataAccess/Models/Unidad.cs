using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table("Unidad")]
    public class Unidad : Base
    {
        [Key]
        [Column("Id_unidad")]
        public int Id { get; set; }
    }
}
