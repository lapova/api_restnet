using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICrud.BaseDatos;
using Microsoft.EntityFrameworkCore;

namespace APICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApiDB _context;

        public ProductoController(ApiDB context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProducto()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("{IDProducto}")]
        public ActionResult<Producto> GetProducto(int IDProducto)
        {
            var Producto = _context.Products.Find(IDProducto);
            if (Producto == null)
            {
                return NotFound();
            }
            return Producto;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> Create(Producto producto)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
            return Ok(producto);
        }

        [HttpPut("{IDProducto}")]
        public async Task<ActionResult> Update(int IDProducto, Producto producto)
        {
            if (IDProducto != producto.IDProducto)
                return BadRequest();

            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{IDProducto}")]
        public async Task<ActionResult> Delete(int IDProducto)
        {
            var producto = await _context.Products.FindAsync(IDProducto);
            if (producto == null)
            {
                return NotFound("IDProducto Incorrecto");
            }
            _context.Products.Remove(producto);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
