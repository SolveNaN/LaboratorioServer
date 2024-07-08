using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class A7_Sub_Empresa
    {
        public int Id { get; set; } 
        public A2_Empresa? A2_Empresa { get; set; }
        public int A2_EmpresaId { get; set; } 
        public int ID_Empresa_Nivel2_A7_A2 { get; set; } 
    }
}
