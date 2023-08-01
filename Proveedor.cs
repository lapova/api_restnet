using System.ComponentModel.DataAnnotations;
namespace APICrud
{
    public class Proveedor
    {
        [Key]
        public int IDProveedor { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = "";
        [StringLength(50)]
        public string Direccion { get; set; } = "";
        [StringLength(100)]
        public string Telefono { get; set; } = "";
        [StringLength(20)]
        public string TipoProducto { get; set; } = "";

    }
}
