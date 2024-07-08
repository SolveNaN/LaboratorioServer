using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class E14_Muestra
    {
        public int Id { get; set; }
        public E5_Componente_Cliente? E5_Componente_Cliente { get; set; }
        public int E5_Componente_ClienteId { get; set; }
        public A4_Usuario? A4_Usuario { get; set; }
        public int A4_UsuarioId { get; set; }
        public E16_Courrier? E16_Courrier { get; set; }
        public int E16_CourrierId { get; set; }
        public DateTime Fecha_Registro_E14 { get; set; }= DateTime.Now;
        public string Numero_Guia_E14 { get; set; }= string.Empty;
        public string Servicio_Componente_E14 { get; set; }= string.Empty;
        public string Servicio_Aceite_E14 { get; set; }= string.Empty;
        public string Relleno_E14 { get; set; }= string.Empty;

    }
}
