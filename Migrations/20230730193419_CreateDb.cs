// Importar las librerías para las migraciones de efc
using Microsoft.EntityFrameworkCore.Migrations;

// Deshabilitar la verificación de valores nulos
#nullable disable

// Definición de la migración llamada "CreateDb"
namespace APICrud.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        // Método que se ejecuta al aplicar la migración para crear las tablas en la base de datos
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Crear la tabla "Clients" con sus columnas y restricciones
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoCliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    // Definir la clave primaria de la tabla "Clients" en la columna "IDCliente"
                    table.PrimaryKey("PK_Clients", x => x.IDCliente);
                });

            // Crear la tabla "Products" con sus columnas y restricciones
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IDProducto = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(8, 2)", nullable: false)
                },
                constraints: table =>
                {
                    // Definir la clave primaria de la tabla "Products" en la columna "IDProducto"
                    table.PrimaryKey("PK_Products", x => x.IDProducto);
                });

            // Crear la tabla "Proveedors" con sus columnas y restricciones
            migrationBuilder.CreateTable(
                name: "Proveedors",
                columns: table => new
                {
                    IDProveedor = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoProducto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    // Definir la clave primaria de la tabla "Proveedors" en la columna "IDProveedor"
                    table.PrimaryKey("PK_Proveedors", x => x.IDProveedor);
                });

            // Crear la tabla "Seccions" con sus columnas y restricciones
            migrationBuilder.CreateTable(
                name: "Seccions",
                columns: table => new
                {
                    IDSeccion = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    // Definir la clave primaria de la tabla "Seccions" en la columna "IDSeccion"
                    table.PrimaryKey("PK_Seccions", x => x.IDSeccion);
                });
        }

        /// <inheritdoc />
        // Método que se ejecuta al deshacer la migración para eliminar las tablas de la base de datos
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar las tablas "Clients", "Products", "Proveedors" y "Seccions" si existen
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Proveedors");

            migrationBuilder.DropTable(
                name: "Seccions");
        }
    }
}
