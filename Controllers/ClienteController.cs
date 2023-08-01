// Importar las librerías necesarias
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICrud.BaseDatos;
using Microsoft.EntityFrameworkCore;

namespace APICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        // Instancia del contexto de la base de datos ApiDB
        private readonly ApiDB _context;

        // Constructor que recibe el contexto de la base de datos 
        public ClienteController(ApiDB context)
        {
            _context = context;
        }

        // Método para obtener todos los clientes (get: api/Cliente)
        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> GetCliente()
        {
            // Obtener y devolver una lista de clientes usando el contexto de la base de datos
            return Ok(await _context.Clients.ToListAsync());
        }

        // Método para obtener un cliente por su id (get: api/Cliente/{IDCliente})
        [HttpGet("{IDCliente}")]
        public ActionResult<Cliente> GetCliente(int IDCliente)
        {
            // Buscar un cliente por su id en el contexto de la base de datos
            var Cliente = _context.Clients.Find(IDCliente);
            // Si no se encuentra el cliente, devolver un error 404 
            if (Cliente == null)
            {
                return NotFound();
            }
            // Si se encuentra el cliente, devolverlo como resultado
            return Cliente;
        }

        // Método para crear un nuevo cliente (post: api/Cliente)
        [HttpPost]
        public async Task<ActionResult<Cliente>> Create(Cliente cliente)
        {
            // Agregar el nuevo cliente al contexto de la base de datos
            _context.Add(cliente);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devolver el cliente recién creado como resultado
            return Ok(cliente);
        }

        // Método para actualizar un cliente que existe por su id (put: api/Cliente/{IDCliente})
        [HttpPut("{IDCliente}")]
        public async Task<ActionResult> Update(int IDCliente, Cliente cliente)
        {
            // Verificar que el id del cliente sea el id que da la URL
            if (IDCliente != cliente.IDCliente)
                // Si no coinciden, devolver un error 400 
                return BadRequest();

            // Marcar el cliente como modificado en el contexto de la base de datos
            _context.Entry(cliente).State = EntityState.Modified;
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devolver un resultado ok
            return Ok();
        }

        // Método para eliminar un cliente por su id (delete: api/Cliente/{IDCliente})
        [HttpDelete("{IDCliente}")]
        public async Task<ActionResult> Delete(int IDCliente)
        {
            // Buscar el cliente por su id en el contexto de la base de datos
            var cliente = await _context.Clients.FindAsync(IDCliente);
            // Si el cliente no se encuentra, devolver un error 404 con un mensaje
            if (cliente == null)
            {
                return NotFound("IDCliente Incorrecto");
            }
            // Si el cliente se encuentra, eliminarlo del contexto de la base de datos
            _context.Clients.Remove(cliente);
            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
            // Devolver un resultado ok
            return Ok();
        }
    }
}
