using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Base
    {
        [Column("Descripcion")]
        public string Descripcion { get; set; }
        [Column("Estado")]
        public int Estado { get; set; }
    }
}
