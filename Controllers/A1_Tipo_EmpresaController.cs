using LaboratorioServer.Data;
using LaboratorioServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class A1_Tipo_EmpresaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public A1_Tipo_EmpresaController(ApplicationDbContext context)
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
                var usuarios = await _context.A1_Tipo_Empresas.ToListAsync();
                return "Buena Calidad";

            }
            catch (Exception ex)
            {
                return "Mala calidad";
            }
        }
        //Aqui comienza el CRUD
        [HttpGet("Listado")]
        public async Task<ActionResult<List<A1_Tipo_Empresa>>> GetA1_Tipo_Empresas()
        {
            var lista = await _context.A1_Tipo_Empresas.ToListAsync();
            return Ok(lista);
        }


        [HttpGet]
        [Route("ConsutarId/{id}")]
        public async Task<ActionResult<List<A1_Tipo_Empresa>>> GetSingleA1_Tipo_Empresa(int id)
        {
            var miobjeto = await _context.A1_Tipo_Empresas.FirstOrDefaultAsync(ob => ob.Id == id);
            if (miobjeto == null)
            {
                return NotFound(" :/");
            }

            return Ok(miobjeto);
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<string>> CreateA1_Tipo_Empresa(A1_Tipo_Empresa objeto)
        {
            try
            {
                _context.A1_Tipo_Empresas.Add(objeto);
                await _context.SaveChangesAsync();
                return "Creado con éxio";
            }
            catch (Exception ex)
            {
                return "Error durante el procesi de almacenamiento";
            }

        }

        [HttpPut("Actualizar/{id}")]
        public async Task<ActionResult<List<A1_Tipo_Empresa>>> UpdateA1_Tipo_Empresa(A1_Tipo_Empresa objeto)
        {

            var DbObjeto = await _context.A1_Tipo_Empresas.FindAsync(objeto.Id);
            if (DbObjeto == null)
                return BadRequest("no se encuentra");
            //DbObjeto.Nombre = objeto.Nombre;
            await _context.SaveChangesAsync();
            return Ok(await _context.A1_Tipo_Empresas.ToListAsync());
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<ActionResult<string>> DeleteA1_Tipo_Empresa(int id)
        {
            var DbObjeto = await _context.A1_Tipo_Empresas.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            try
            {
                _context.A1_Tipo_Empresas.Remove(DbObjeto);
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
