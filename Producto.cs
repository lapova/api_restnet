using System.ComponentModel.DataAnnotations;

namespace APICrud
{
    public class Producto
    {
        [Key]
        public int IDProducto { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = "";
        public float Precio { get; set; }
    }
}
