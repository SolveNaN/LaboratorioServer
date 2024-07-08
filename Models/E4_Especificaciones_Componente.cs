using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class E4_Especificaciones_Componente
    {
        public int Id { get; set; }
        public E3_Tipo_Componente? E3_Tipo_Componente { get; set; }
        public int E3_Tipo_ComponenteId { get; set; }
        public E11_Marca? E11_Marca { get; set; }
        public int E11_MarcaId { get; set; }
        public E10_Combustible? E10_Combustible { get; set; }
        public int E10_CombustibleId { get; set; }
        public E1_Tipo_Aplicacion? E1_Tipo_Aplicacion { get; set; }
        public int E1_Tipo_AplicacionId { get; set; }
        public E8_Lubricante? E8_Lubricante { get; set; }
        public int E8_LubricanteId { get; set; }
        public int Dias_Almacenamiento_Standard_E4 { get; set; }
        public string Modelo_E4 { get; set; }=string.Empty;
        public string Caracteristica_Especial_E4 { get; set; }=string.Empty;
    }
}
