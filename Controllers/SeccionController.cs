using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICrud.BaseDatos;
using Microsoft.EntityFrameworkCore;

namespace APICrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionController : ControllerBase
    {
        private readonly ApiDB _context;

        public SeccionController(ApiDB context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Seccion>>> GetSeccion()
        {
            return Ok(await _context.Seccions.ToListAsync());
        }

        [HttpGet("{IDSeccion}")]
        public ActionResult<Seccion> GetSeccion(int IDSeccion)
        {
            var Seccion = _context.Seccions.Find(IDSeccion);
            if (Seccion == null)
            {
                return NotFound();
            }
            return Seccion;
        }

        [HttpPost]
        public async Task<ActionResult<Seccion>> Create(Seccion seccion)
        {
            _context.Add(seccion);
            await _context.SaveChangesAsync();
            return Ok(seccion);
        }

        [HttpPut("{IDSeccion}")]
        public async Task<ActionResult> Update(int IDSeccion, Seccion seccion)
        {
            if (IDSeccion != seccion.IDSeccion)
                return BadRequest();

            _context.Entry(seccion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{IDSeccion}")]
        public async Task<ActionResult> Delete(int IDSeccion)
        {
            var seccion = await _context.Seccions.FindAsync(IDSeccion);
            if (seccion == null)
            {
                return NotFound("IDSeccion Incorrecto");
            }
            _context.Seccions.Remove(seccion);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
