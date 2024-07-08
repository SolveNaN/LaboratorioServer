using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class E7_Clasificacion
    {
        public int Id { get; set; }
        public E6_Entidad_Clasificadora? E6_Entidad_Clasificadora { get; set; }
        public int E6_Entidad_ClasificadoraId { get; set; }
        public string Descripcion_Clasificacion_Lube_E7 { get; set; }=string.Empty;

    }
}
