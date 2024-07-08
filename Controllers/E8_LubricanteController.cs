using LaboratorioServer.Data;
using LaboratorioServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class E8_LubricanteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public E8_LubricanteController(ApplicationDbContext context)
        {

            _context = context;
        }
        //Estado de conexion con el servidor
        [HttpGet]
        [Route("ConexionServidor")]
        public async Task<ActionResult<string>> GetConexionServidor()
        {
            return "Conectado";
        }
        //Estados de conexion con la tabla de la base de datos
        [HttpGet]
        [Route("ConexionDB")]
        public async Task<ActionResult<string>> GetConexionDB()
        {
            try
            {
                var usuarios = await _context.E8_Lubricantes.ToListAsync();
                return "Buena Calidad";

            }
            catch (Exception ex)
            {
                return "Mala calidad";
            }
        }
        //Aqui comienza el CRUD
        [HttpGet("Listado")]
        public async Task<ActionResult<List<E8_Lubricante>>> GetE8_Lubricantes()
        {
            var lista = await _context.E8_Lubricantes.Include(x => x.E11_Marca).ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("ConsutarId/{id}")]
        public async Task<ActionResult<List<E8_Lubricante>>> GetSingleE8_Lubricante(int id)
        {
            var miobjeto = await _context.E8_Lubricantes.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<string>> CreateE8_Lubricante(E8_Lubricante objeto)
        {
            try
            {
                _context.E8_Lubricantes.Add(objeto);
                await _context.SaveChangesAsync();
                return "Creado con éxio";
            }
            catch (Exception ex)
            {
                return "Error durante el procesi de almacenamiento";
            }

        }

        [HttpPut("Actualizar/{id}")]
        public async Task<ActionResult<List<E8_Lubricante>>> UpdateE8_Lubricante(E8_Lubricante objeto)
        {

            var DbObjeto = await _context.E8_Lubricantes.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            //DbObjeto.Nombre = objeto.Nombre;
            await _context.SaveChangesAsync();
            return Ok(await _context.E8_Lubricantes.ToListAsync());
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<ActionResult<string>> DeleteE8_Lubricante(int id)
        {
            var DbObjeto = await _context.E8_Lubricantes.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            try
            {
                _context.E8_Lubricantes.Remove(DbObjeto);
                await _context.SaveChangesAsync();

                return "Eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "No fué posible eliminar el objeto";
            }

        }
    }
}
