using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioServer.Models
{
    public class E5_Componente_Cliente
    {
        public int Id { get; set; }
        public E2_Tipo_Maquina? E2_Tipo_Maquina { get; set; }
        public int E2_Tipo_MaquinaId { get; set; }
        public E11_Marca? E11_Marca { get; set; }
        public int E11_MarcaId { get; set; }
        public E4_Especificaciones_Componente? E4_Especificaciones_Componente { get; set; }
        public int E4_Especificaciones_ComponenteId { get; set; }
        public A2_Empresa? A2_Empresa { get; set; }
        public int A2_EmpresaId { get; set; }
        public E13_Unidad_Medida? E13_Unidad_Medida { get; set; }
        public int E13_Unidad_MedidaId { get; set; }
        //
        public int ID_Unidad_Medida_Serv_Aceite_E5_E13 { get; set; }
        public int ID_Unidad_Medida_Serv_Componente_E5_E13 { get; set; }
        //public int ID_Unidad_Medida_Carter_E5_E13 { get; set; }//   Falta
        public int ID_Unidad_Medida_Relleno_E5_E13 { get; set; }
        public int Dias_Almacenamiento_Componente_Cliente_E5 { get; set; }
        public double Volumen_Carter_E5 { get; set; }
        public string Placa_Componente_E5 { get; set; }=string.Empty;
        public string Status_Registro_Componente_E5 { get; set; }=string.Empty;
        public string Placa_Maquina_E5 { get; set; }=string.Empty;
        public string Modelo_Maquina_E5 { get; set; }=string.Empty;
        public string Informacion_Adicional_Maquina_E5 { get; set; }=string.Empty;


    }
}
/*
Id INT PRIMARY KEY IDENTITY(1,1),
--ID_Componente_Cliente_E5 INT NULL,
E2_Tipo_MaquinaId INT NULL,
E11_MarcaId INT NULL,
E4_Especificaciones_ComponenteId INT NULL,
A2_EmpresaId INT NULL,
ID_Unidad_Medida_Serv_Componente_E5_E13 INT NULL,
--ESTOS NO SE USAN
ID_Unidad_Medida_Serv_Aceite_E5_E13 INT NULL,
E13_Unidad_MedidaId INT NULL,
ID_Unidad_Medida_Relleno_E5_E13 INT NULL,
--
Volumen_Carter_E5 FLOAT NULL,
Placa_Componente_E5 VARCHAR(100) NULL,
Dias_Almacenamiento_Componente_Cliente_E5 INT NULL,
Status_Registro_Componente_E5 VARCHAR(100) NULL,
Placa_Maquina_E5 VARCHAR(100) NULL,
Modelo_Maquina_E5 VARCHAR(100) NULL,
Informacion_Adicional_Maquina_E5 VARCHAR(100) NULL,
FOREIGN KEY(E2_Tipo_MaquinaId) REFERENCES E2_Tipo_Maquinas(Id),
FOREIGN KEY(E11_MarcaId) REFERENCES E11_Marcas(Id),
FOREIGN KEY(E4_Especificaciones_ComponenteId) REFERENCES E4_Especificaciones_Componentes(Id),
FOREIGN KEY(A2_EmpresaId) REFERENCES A2_Empresas(Id),
FOREIGN KEY(E13_Unidad_MedidaId) REFERENCES E13_Unidad_Medidas(Id),
)*/