using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class A2_Empresa
    {
        public int Id { get; set; }
        public A1_Tipo_Empresa? A1_Tipo_Empresa { get; set; }
        public int A1_Tipo_EmpresaId { get; set; }
        public A6_Ciudad? A6_Ciudad { get; set; }
        public int A6_CiudadId { get; set; }
        public string Nombre_Empresa_A2 { get; set; }=string.Empty;
        public int ID_Empresa_Superior_A2 { get; set; }
        
        public string Direccion_A2 { get; set; }=string.Empty;
        public string Telefono_A2 { get; set; }=string.Empty;
        public DateTime Fecha_Creacion_A2 { get; set; }=DateTime.Now;
    }
}
