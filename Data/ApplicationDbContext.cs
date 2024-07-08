using LaboratorioServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace LaboratorioServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<A5_Pais> A5_Paiss { get; set; }
        public DbSet<Ejemplo> Ejemplos { get; set; }
        public DbSet<A6_Ciudad> A6_Ciudads { get; set; }
        public DbSet<A1_Tipo_Empresa> A1_Tipo_Empresas { get; set; }
        public DbSet<A3_Tipo_Usuario> A3_Tipo_Usuarios { get; set; }
        public DbSet<A2_Empresa> A2_Empresas { get; set; }
        public DbSet<A7_Sub_Empresa> A7_Sub_Empresas { get; set; }
        public DbSet<A4_Usuario> A4_Usuarios { get; set; }
        public DbSet<E16_Courrier> E16_Courriers { get; set; }
        public DbSet<E12_Tipo_Unidad> E12_Tipo_Unidads { get; set; }
        public DbSet<E13_Unidad_Medida> E13_Unidad_Medidas { get; set; }
        public DbSet<L1_Prueba> L1_Pruebas { get; set; }
        public DbSet<E10_Combustible> E10_Combustibles { get; set; }
        public DbSet<E6_Entidad_Clasificadora> E6_Entidad_Clasificadoras { get; set; }
        public DbSet<E7_Clasificacion> E7_Clasificacions { get; set; }
        public DbSet<E8_Lubricante> E8_Lubricantes { get; set; }
        public DbSet<E9_Clasificacion_Lubricante> E9_Clasificacion_Lubricantes { get; set; }
        public DbSet<E1_Tipo_Aplicacion> E1_Tipo_Aplicacions { get; set; }
        public DbSet<E3_Tipo_Componente> E3_Tipo_Componentes { get; set; }
        public DbSet<E11_Marca> E11_Marcas { get; set; }
        public DbSet<E4_Especificaciones_Componente> E4_Especificaciones_Componentes { get; set; }
        public DbSet<E2_Tipo_Maquina> E2_Tipo_Maquinas { get; set; }
        public DbSet<E5_Componente_Cliente> E5_Componente_Clientes { get; set; }
        public DbSet<E14_Muestra> E14_Muestras { get; set; }
        public DbSet<E15_Resultado> E15_Resultados { get; set; }
    }
}
