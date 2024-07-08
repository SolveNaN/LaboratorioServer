using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class L1_Prueba
    {
        public int Id { get; set; }
        public string Nombre_Prueba_L1 { get; set; }=string.Empty;
        public E13_Unidad_Medida? E13_Unidad_Medida { get; set; }
        public int E13_Unidad_MedidaId { get; set; }
    }
}
