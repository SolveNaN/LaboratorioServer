using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class E13_Unidad_Medida
    {
        public int Id { get; set; }
        public E12_Tipo_Unidad? E12_Tipo_Unidad { get; set; }
        public int E12_Tipo_UnidadId { get; set; }
        public string Nombre_Unidad_Medida_E13 { get; set; }=string.Empty;
        public string Nemotecnico_E13 { get; set; }=string.Empty;

    }
}
