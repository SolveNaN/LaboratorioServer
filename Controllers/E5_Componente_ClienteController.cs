using LaboratorioServer.Data;
using LaboratorioServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class E5_Componente_ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public E5_Componente_ClienteController(ApplicationDbContext context)
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
                var usuarios = await _context.E5_Componente_Clientes.ToListAsync();
                return "Buena Calidad";

            }
            catch (Exception ex)
            {
                return "Mala calidad";
            }
        }
        //Aqui comienza el CRUD
        [HttpGet("Listado")]
        public async Task<ActionResult<List<E5_Componente_Cliente>>> GetE5_Componente_Clientes()
        {
            var lista = await _context.E5_Componente_Clientes.Include(x => x.E2_Tipo_Maquina).Include(x => x.E11_Marca).Include(x => x.E4_Especificaciones_Componente).Include(x => x.A2_Empresa).Include(x => x.E13_Unidad_Medida).ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("ConsutarId/{id}")]
        public async Task<ActionResult<List<E5_Componente_Cliente>>> GetSingleE5_Componente_Cliente(int id)
        {
            var miobjeto = await _context.E5_Componente_Clientes.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<string>> CreateE5_Componente_Cliente(E5_Componente_Cliente objeto)
        {
            try
            {
                _context.E5_Componente_Clientes.Add(objeto);
                await _context.SaveChangesAsync();
                return "Creado con éxio";
            }
            catch (Exception ex)
            {
                return "Error durante el procesi de almacenamiento";
            }

        }

        [HttpPut("Actualizar/{id}")]
        public async Task<ActionResult<List<E5_Componente_Cliente>>> UpdateE5_Componente_Cliente(E5_Componente_Cliente objeto)
        {

            var DbObjeto = await _context.E5_Componente_Clientes.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            //DbObjeto.Nombre = objeto.Nombre;
            await _context.SaveChangesAsync();
            return Ok(await _context.E5_Componente_Clientes.ToListAsync());
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<ActionResult<string>> DeleteE5_Componente_Cliente(int id)
        {
            var DbObjeto = await _context.E5_Componente_Clientes.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            try
            {
                _context.E5_Componente_Clientes.Remove(DbObjeto);
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
