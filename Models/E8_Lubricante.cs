using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class E8_Lubricante
    {
        public int Id { get; set; }
        public string Descripcion_Lubricante_E8 { get; set; }=string.Empty;
        public E11_Marca? E11_Marca { get; set; }
        public int E11_MarcaId { get; set; }
        public string Uso_Aplicacion_Lubricante_E8 {  get; set; }=string.Empty;

    }
}
