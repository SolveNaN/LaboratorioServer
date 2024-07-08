using LaboratorioServer.Data;
using LaboratorioServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class E1_Tipo_AplicacionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public E1_Tipo_AplicacionController(ApplicationDbContext context)
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
                var usuarios = await _context.E1_Tipo_Aplicacions.ToListAsync();
                return "Buena Calidad";

            }
            catch (Exception ex)
            {
                return "Mala calidad";
            }
        }
        //Aqui comienza el CRUD
        [HttpGet("Listado")]
        public async Task<ActionResult<List<E1_Tipo_Aplicacion>>> GetE1_Tipo_Aplicacions()
        {
            var lista = await _context.E1_Tipo_Aplicacions.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("ConsutarId/{id}")]
        public async Task<ActionResult<List<E1_Tipo_Aplicacion>>> GetSingleE1_Tipo_Aplicacion(int id)
        {
            var miobjeto = await _context.E1_Tipo_Aplicacions.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<string>> CreateE1_Tipo_Aplicacion(E1_Tipo_Aplicacion objeto)
        {
            try
            {
                _context.E1_Tipo_Aplicacions.Add(objeto);
                await _context.SaveChangesAsync();
                return "Creado con éxio";
            }
            catch (Exception ex)
            {
                return "Error durante el procesi de almacenamiento";
            }

        }

        [HttpPut("Actualizar/{id}")]
        public async Task<ActionResult<List<E1_Tipo_Aplicacion>>> UpdateE1_Tipo_Aplicacion(E1_Tipo_Aplicacion objeto)
        {

            var DbObjeto = await _context.E1_Tipo_Aplicacions.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            //DbObjeto.Nombre = objeto.Nombre;
            await _context.SaveChangesAsync();
            return Ok(await _context.E1_Tipo_Aplicacions.ToListAsync());
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<ActionResult<string>> DeleteE1_Tipo_Aplicacion(int id)
        {
            var DbObjeto = await _context.E1_Tipo_Aplicacions.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            try
            {
                _context.E1_Tipo_Aplicacions.Remove(DbObjeto);
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
