using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class E9_Clasificacion_Lubricante
    {
        public int Id { get; set; }
        public E8_Lubricante? E8_Lubricante { get; set; }
        public int E8_LubricanteId { get; set; }
        public E7_Clasificacion? E7_Clasificacion { get; set; }
        public int E7_ClasificacionId { get; set; }

    }
}
