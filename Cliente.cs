using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICrud
{
    public class Cliente //clase cliente
    {
        [Key]
        // Propiedad que indica el ID del cliente (pk)
        public int IDCliente { get; set; }
        [StringLength(50)]
        // Propiedad que indica el nombre del cliente 
        public string Nombre { get; set; } = "";
        [StringLength(50)]
        // Propiedad que indica el apellido del cliente 
        public string Apellido { get; set; } = "";
        [StringLength(50)]
        // Propiedad que indica el correo del cliente 
        public string Correo { get; set; } = "";
        [StringLength(50)]
        // Propiedad que indica el tipo de cliente
        public string TipoCliente { get; set; } = "";

    }
}
