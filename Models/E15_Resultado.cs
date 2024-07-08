using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class E15_Resultado
    {
        public int Id { get; set; }
        public E14_Muestra? E14_Muestra { get; set; }
        public int E14_MuestraId { get; set; }
        public L1_Prueba? L1_Prueba { get; set; }
        public int L1_PruebaId { get; set; }
        public string Texto_Prueba_L15 { get; set; }=string.Empty;
        public double Valor_Prueba_L15 { get; set; }
    }
}
