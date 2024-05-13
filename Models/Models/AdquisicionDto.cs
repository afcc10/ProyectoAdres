using System;

namespace Models.Models
{
    public class AdquisicionDto
    {
        public int Id { get; set; }
        public decimal Presupuesto { get; set; }
        public int Id_Servicio { get; set; }
        public int Cantidad { get; set; }
        public decimal Valor_Unitario { get; set; }
        public DateTime Fecha_Adquisicion  { get; set; }
        public int Id_Proveedor { get; set; }
        public int Id_Unidad { get; set; }
        public string Documentacion { get; set; }
    }
}
