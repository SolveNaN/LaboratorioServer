using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class Usuario
    {
        //datos del usuario
        public int Id { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string TelefonoCelular { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;//Dueño o arrendatario
        //datos de la sesion
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Token { get; set; } = string.Empty;
        public string Rol { get; set; } = "Usuario"; //administrador y residente, vigilante     
        public string CodigoVerificacion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaNacimiento { get; set; } = DateTime.Now;

        //Aqui se colocan todos los demas datos que tenga el usuario como nombres, direcciones, fechas, edad, estados etc
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string NoIdentidad { get; set; } = string.Empty;
        //datos del archivo foto o archivo general de identificacion
        public int UploadResultId { get; set; } //Hace referencia a la clase con la cual se guarda un archivo y col el cual se asocia esta clase
    }
}