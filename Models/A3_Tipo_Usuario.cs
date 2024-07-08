using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class A3_Tipo_Usuario
    {
        public int Id { get; set; }
        public A1_Tipo_Empresa? A1_Tipo_Empresa { get; set; }
        public int A1_Tipo_EmpresaId { get; set; }
        public string Descripcion_Tipo_Usuario_A3 { get; set; }=string.Empty;
        public string Ver_Equipos_A3 { get; set; }=string.Empty;
        public string Crear_Equipos_A3 { get; set; }=string.Empty;
        public string Modificar_Equipos_A3 { get; set; }=string.Empty;
        public string Inactivar_Equipos_A3 { get; set; }=string.Empty;
        public string Crear_Muestras_A3 { get; set; }=string.Empty;
        public string Ver_Resultados_A3 { get; set; }=string.Empty;
        public string Modificar_Resultados_A3 { get; set; }=string.Empty;

    }
}
