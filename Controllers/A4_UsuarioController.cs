using LaboratorioServer.Data;
using LaboratorioServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LaboratorioServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class A4_UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public A4_UsuarioController(ApplicationDbContext context)
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
                var usuarios = await _context.A4_Usuarios.ToListAsync();
                return Ok("Buena Calidad");

            }
            catch (Exception ex)
            {
                return BadRequest("Mala calidad");
            }
        }

        [HttpGet("Datos"), Authorize(Roles = "Conductor,Admin,Usuario")]
        public async Task<ActionResult<List<A4_Usuario>>> GetCuenta()
        {
            var lista = await _context.Usuarios.ToListAsync();
            return Ok(lista);
        }

        public static A4_Usuario usuario = new A4_Usuario();
        [HttpPost("Registrar")]
        public async Task<ActionResult<string>> CreateCuenta(UsuarioDTO objeto)
        {
            try
            {
                CreatePasswordHash(objeto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                usuario.Nombre_A4 = objeto.Nombre;
                usuario.Apellido_A4 = objeto.Apellido;
                usuario.Direccion_A4 = objeto.Direccion;
                usuario.Telefono_A4 = objeto.Telefono_A4;
                usuario.Mail_A4 = objeto.Correo;
                usuario.Fecha_Creacion_A4 = objeto.Fecha_Creacion_A4;
                usuario.A3_Tipo_UsuarioId = objeto.ID_Tipo_Usuario_A4_A3;
                usuario.A2_EmpresaId = objeto.ID_Empresa_A4_A2;
                usuario.A6_CiudadId = objeto.ID_Ciudad_A4_A6;
              //  usuario.ID_Tipo_Usuario_A4_A3 = objeto.ID_Tipo_Usuario_A4_A3;
              //  usuario.ID_Ciudad_A4_A6 = objeto.ID_Ciudad_A4_A6;
              //  usuario.ID_Empresa_A4_A2 = objeto.ID_Empresa_A4_A2;
                usuario.PasswordHash = passwordHash;
                usuario.PasswordSalt = passwordSalt;                
                _context.A4_Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                var respuesta = "Registrado Con Exito";

                return Ok(respuesta) ;
            }
            catch (Exception ex)
            {
                return BadRequest("Error dutante el registro");
            }

        }
        [HttpPost("Login")]
        public async Task<ActionResult<string>> InicioSesion(UsuarioDTO objeto)
        {
            var cuanta = await _context.A4_Usuarios.Where(x => x.Nombre_A4 == objeto.Correo).FirstOrDefaultAsync();
            if (cuanta == null)
            {
                return BadRequest("Usuario no encontrado");
            }
            if (!VerifyPasswordHash(objeto.Password, cuanta.PasswordHash, cuanta.PasswordSalt))
            {
                return BadRequest("Contraseña incorrecta");
            }
            string token = CreateToken(cuanta);
            return Ok(token);

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }


        private string CreateToken(A4_Usuario user)
        {
            List<Claim> claims = new List<Claim>
     {
         new Claim(ClaimTypes.Name, user.Nombre_A4),
         new Claim(ClaimTypes.Role,"General User")
     };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                "PROYECTO_LABORATORIO_ACTIVO_PARA_MUESTRAS_EN_DIFERETES_PAISES_PROBANDO_EQUIPOS_Y_COMBUSYIBLES"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        [HttpGet("Listado")]
        public async Task<ActionResult<List<A4_Usuario>>> GetEjemplos()
        {
            var lista = await _context.A4_Usuarios.Include(u=>u.A3_Tipo_Usuario).Include(e=>e.A2_Empresa).Include(c=>c.A6_Ciudad).ToListAsync();
            return Ok(lista);
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<ActionResult<string>> DeleteUsuario(int id)
        {
            var DbObjeto = await _context.A4_Usuarios.FirstOrDefaultAsync(Ob => Ob.Id == id);
            if (DbObjeto == null)
            {
                return NotFound("no existe :/");
            }

            try
            {
                _context.A4_Usuarios.Remove(DbObjeto);
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
