using System.ComponentModel.DataAnnotations;

namespace APICrud
{
    public class Seccion
    {
        [Key]
        public int IDSeccion { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = "";
        [StringLength(50)]
        public string Descripcion { get; set; } = "";
    }
}
