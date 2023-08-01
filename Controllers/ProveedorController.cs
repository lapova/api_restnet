using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICrud.BaseDatos;
using Microsoft.EntityFrameworkCore;

namespace APICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ApiDB _context;

        public ProveedorController(ApiDB context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Proveedor>>> GetProveedor()
        {
            return Ok(await _context.Proveedors.ToListAsync());
        }

        [HttpGet("{IDProveedor}")]
        public ActionResult<Proveedor> GetProveedor(int IDProveedor)
        {
            var Proveedor = _context.Proveedors.Find(IDProveedor);
            if (Proveedor == null)
            {
                return NotFound();
            }
            return Proveedor;
        }

        [HttpPost]
        public async Task<ActionResult<Proveedor>> Create(Proveedor proveedor)
        {
            _context.Add(proveedor);
            await _context.SaveChangesAsync();
            return Ok(proveedor);
        }

        [HttpPut("{IDProveedor}")]
        public async Task<ActionResult> Update(int IDProveedor, Proveedor proveedor)
        {
            if (IDProveedor != proveedor.IDProveedor)
                return BadRequest();

            _context.Entry(proveedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{IDProveedor}")]
        public async Task<ActionResult> Delete(int IDProveedor)
        {
            var proveedor = await _context.Proveedors.FindAsync(IDProveedor);
            if (proveedor == null)
            {
                return NotFound("IDProveedor Incorrecto");
            }
            _context.Proveedors.Remove(proveedor);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
