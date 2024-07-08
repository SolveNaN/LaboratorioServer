using LaboratorioServer.Data;
using LaboratorioServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class E4_Especificaciones_ComponenteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public E4_Especificaciones_ComponenteController(ApplicationDbContext context)
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
                var usuarios = await _context.E4_Especificaciones_Componentes.ToListAsync();
                return "Buena Calidad";

            }
            catch (Exception ex)
            {
                return "Mala calidad";
            }
        }
        //Aqui comienza el CRUD
        [HttpGet("Listado")]
        public async Task<ActionResult<List<E4_Especificaciones_Componente>>> GetE4_Especificaciones_Componentes()
        {
            var lista = await _context.E4_Especificaciones_Componentes.Include(x => x.E1_Tipo_Aplicacion).Include(x => x.E3_Tipo_Componente).Include(x => x.E11_Marca).Include(x => x.E8_Lubricante).Include(x => x.E10_Combustible).ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("ConsutarId/{id}")]
        public async Task<ActionResult<List<E4_Especificaciones_Componente>>> GetSingleE4_Especificaciones_Componente(int id)
        {
            var miobjeto = await _context.E4_Especificaciones_Componentes.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<string>> CreateE4_Especificaciones_Componente(E4_Especificaciones_Componente objeto)
        {
            try
            {
                _context.E4_Especificaciones_Componentes.Add(objeto);
                await _context.SaveChangesAsync();
                return "Creado con éxio";
            }
            catch (Exception ex)
            {
                return "Error durante el procesi de almacenamiento";
            }

        }

        [HttpPut("Actualizar/{id}")]
        public async Task<ActionResult<List<E4_Especificaciones_Componente>>> UpdateE4_Especificaciones_Componente(E4_Especificaciones_Componente objeto)
        {

            var DbObjeto = await _context.E4_Especificaciones_Componentes.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            //DbObjeto.Nombre = objeto.Nombre;
            await _context.SaveChangesAsync();
            return Ok(await _context.E4_Especificaciones_Componentes.ToListAsync());
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<ActionResult<string>> DeleteE4_Especificaciones_Componente(int id)
        {
            var DbObjeto = await _context.E4_Especificaciones_Componentes.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            try
            {
                _context.E4_Especificaciones_Componentes.Remove(DbObjeto);
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
