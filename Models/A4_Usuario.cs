using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class A4_Usuario
    {
        public int Id { get; set; }
        public A3_Tipo_Usuario? A3_Tipo_Usuario { get;set;  }
        public int A3_Tipo_UsuarioId { get; set; }
        public A2_Empresa? A2_Empresa { get; set; }
        public int A2_EmpresaId { get; set; }
        public A6_Ciudad? A6_Ciudad { get; set; }
        public int A6_CiudadId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }        
        public string Nombre_A4 { get; set; }=string.Empty;
        public string Apellido_A4 { get; set; }=string.Empty;
        public string Direccion_A4 { get; set; }=string.Empty;
        public string Telefono_A4 { get; set; }=string.Empty;
        public string Mail_A4 { get; set; }=string.Empty;
        public DateTime Fecha_Creacion_A4 { get; set; }=DateTime.Now;

    }
}
