using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class A6_Ciudad
    {
        public int Id { get; set; }
        public string Nombre_Ciudad_A6 { get; set; }=string.Empty;
        public A5_Pais? A5_Pais { get; set; }
        public int A5_PaisId { get; set; }

    }
}
