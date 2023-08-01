// Importar el namespace para trabajar con Entity Framework Core
using Microsoft.EntityFrameworkCore;

namespace APICrud.BaseDatos
{
    // Clase que representa la bd de la API
    public class ApiDB : DbContext
    {
        // Constructor que recibe las opciones de configuración para la bd
        public ApiDB(DbContextOptions<ApiDB> options) : base(options)
        {
        }

        //DbSet: clase que brinda efc, representa una tabla en la bd y se utiliza para crud.
        // facilita las operaciones con la bd desde la app

        // DbSet para la entidad Cliente
        public DbSet<Cliente> Clients { get; set; }
        // DbSet para la entidad Proveedor
        public DbSet<Proveedor> Proveedors { get; set; }
        // DbSet para la entidad Seccion
        public DbSet<Seccion> Seccions { get; set; }
        // DbSet para la entidad Producto
        public DbSet<Producto> Products { get; set; }
    }
}
