using LaboratorioServer.Data;
using LaboratorioServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class E9_Clasificacion_LubricanteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public E9_Clasificacion_LubricanteController(ApplicationDbContext context)
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
                var usuarios = await _context.E9_Clasificacion_Lubricantes.ToListAsync();
                return "Buena Calidad";

            }
            catch (Exception ex)
            {
                return "Mala calidad";
            }
        }
        //Aqui comienza el CRUD
        [HttpGet("Listado")]
        public async Task<ActionResult<List<E9_Clasificacion_Lubricante>>> GetE9_Clasificacion_Lubricantes()
        {
            var lista = await _context.E9_Clasificacion_Lubricantes.Include(x => x.E8_Lubricante).Include(x => x.E7_Clasificacion).ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("ConsutarId/{id}")]
        public async Task<ActionResult<List<E9_Clasificacion_Lubricante>>> GetSingleE9_Clasificacion_Lubricante(int id)
        {
            var miobjeto = await _context.E9_Clasificacion_Lubricantes.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<string>> CreateE9_Clasificacion_Lubricante(E9_Clasificacion_Lubricante objeto)
        {
            try
            {
                _context.E9_Clasificacion_Lubricantes.Add(objeto);
                await _context.SaveChangesAsync();
                return "Creado con éxio";
            }
            catch (Exception ex)
            {
                return "Error durante el procesi de almacenamiento";
            }

        }

        [HttpPut("Actualizar/{id}")]
        public async Task<ActionResult<List<E9_Clasificacion_Lubricante>>> UpdateE9_Clasificacion_Lubricante(E9_Clasificacion_Lubricante objeto)
        {

            var DbObjeto = await _context.E9_Clasificacion_Lubricantes.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            //DbObjeto.Nombre = objeto.Nombre;
            await _context.SaveChangesAsync();
            return Ok(await _context.E9_Clasificacion_Lubricantes.ToListAsync());
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<ActionResult<string>> DeleteE9_Clasificacion_Lubricante(int id)
        {
            var DbObjeto = await _context.E9_Clasificacion_Lubricantes.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            try
            {
                _context.E9_Clasificacion_Lubricantes.Remove(DbObjeto);
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
