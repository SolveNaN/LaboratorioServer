using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class UsuarioDTO
    {
        public A3_Tipo_Usuario? A3_Tipo_Usuario { get; }
        public int ID_Tipo_Usuario_A4_A3 { get; set; }
        public A2_Empresa? A2_Empresa { get; }
        public int ID_Empresa_A4_A2 { get; set; }
        public A6_Ciudad? A6_Ciudad { get; }
        public int ID_Ciudad_A4_A6 { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        //Aqui se colocan todos los demas datos que tenga el usuario como nombres, direcciones, fechas, edad, estados etc

        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono_A4 { get; set; } = string.Empty;
        public DateTime Fecha_Creacion_A4 { get; set; } = DateTime.Now;
    }


}
