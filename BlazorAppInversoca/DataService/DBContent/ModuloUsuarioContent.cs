using BlazorAppInversoca.Shared.EFModels;
using BlazorAppInversoca.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppInversoca.DataService.DBContent
{
    public class BlazorAppInversocaContent: DbContext
    {
        // DBSET DE LISTAS STORED PROCEDURES (VIEWS)
        public virtual DbSet<PropiedadView> PropiedadView { get; set; }
        public virtual DbSet<ModuloView> ModuloView { get; set; }
        public virtual DbSet<RolView> RolView { get; set; }
        public virtual DbSet<UsuarioView> UsuarioView { get; set; }
        public virtual DbSet<OperacionView> OperacionView { get; set; }
        public virtual DbSet<RolOperacionView> RolOperacionView { get; set; }
        public virtual DbSet<UsuarioRolView> UsuarioRolView { get; set; }
        // DBSET DE MODELOS STORED PROCEDURES (VIEWMODELS)
        public virtual DbSet<PropiedadViewModel> PropiedadViewModel { get; set; }
        public virtual DbSet<ModuloViewModel> ModuloViewModel { get; set; }
        public virtual DbSet<RolViewModel> RolViewModel { get; set; }
        public virtual DbSet<UsuarioViewModel> UsuarioViewModel { get; set; }
        public virtual DbSet<OperacionViewModel> OperacionViewModel { get; set; }
        public virtual DbSet<UsuarioRolViewModel> UsuarioRolViewModel { get; set; }
        public virtual DbSet<RolOperacionViewModel> RolOperacionViewModel { get; set; }
        // DBSET DE MODELOS  ENTITY FRAMEWORK
        public virtual DbSet<Propiedad> Propiedad { get; set; }
        public virtual DbSet<Modulo> Modulo { get; set; }
        public virtual DbSet<RolOperacion> RolOperacion { get; set; }
        public virtual DbSet<Operacion> Operacion { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public BlazorAppInversocaContent(DbContextOptions<BlazorAppInversocaContent> options)
         : base((DbContextOptions)options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // RELACIONES DE ENTITY FRAMEWORK DE ENTIDADES
            

            modelBuilder.Entity<Operacion>()
               .HasOne(s => s.Modulo)
               .WithMany(g => g.Operaciones)
               .HasForeignKey(s => s.IdModulo)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RolOperacion>()
                .HasKey(t => new { t.IdRol, t.IdOperacion });
            modelBuilder.Entity<RolOperacion>()
                .HasOne(c => c.Rol)
                .WithMany(c => c.OperacionesPermitidas)
                .HasForeignKey(c => c.IdRol)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RolOperacion>()
                .HasOne(c => c.Operacion)
                .WithMany(c => c.RolesOperaciones)
                .HasForeignKey(c => c.IdOperacion);

            modelBuilder.Entity<UsuarioRol>()
                 .HasKey(t => new { t.IdUsuario, t.IdRol });
            modelBuilder.Entity<UsuarioRol>()
                .HasOne(c => c.Usuario)
                .WithMany(c => c.RolesAsignados)
                .HasForeignKey(c => c.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UsuarioRol>()
                .HasOne(c => c.Rol)
                .WithMany(c => c.UsuariosActivos)
                .HasForeignKey(c => c.IdRol)
                .OnDelete(DeleteBehavior.Cascade);
            // RELACIONES DE STORED PROCEDURES DE ENTIDADES VIEWMODELS
          
            modelBuilder.Entity<OperacionViewModel>()
               .HasOne(s => s.Modulo)
               .WithMany(g => g.Operaciones)
               .HasForeignKey(s => s.IdModulo);

            modelBuilder.Entity<UsuarioRolViewModel>()
                 .HasKey(t => new { t.IdUsuario, t.IdRol });
            modelBuilder.Entity<UsuarioRolViewModel>()
               .HasOne(r => r.Rol)
               .WithMany(ur => ur.UsuariosActivos)
               .HasForeignKey(r => r.IdRol);
            modelBuilder.Entity<UsuarioRolViewModel>()
                .HasOne(r => r.Usuario)
                .WithMany(ur => ur.RolesAsignados)
                .HasForeignKey(r => r.IdUsuario);

            modelBuilder.Entity<RolOperacionViewModel>()
                .HasKey(t => new { t.IdRol, t.IdOperacion });
            modelBuilder.Entity<RolOperacionViewModel>()
                .HasOne(r => r.Rol)
                .WithMany(ro => ro.OperacionesPermitidas)
                .HasForeignKey(r => r.IdRol);
            modelBuilder.Entity<RolOperacionViewModel>()
                .HasOne(r => r.Operacion)
                .WithMany(ro => ro.RolesPermitidos)
                .HasForeignKey(r => r.IdOperacion);
            // RELACIONES DE STORED PROCEDURES DE ENTIDADES viewS
            modelBuilder.Entity<UsuarioRolView>()
               .HasKey(t => new { t.IdUsuario, t.IdRol });
            modelBuilder.Entity<RolOperacionView>()
                .HasKey(t => new { t.IdRol, t.IdOperacion });
            //modelBuilder.Entity<ClienteViewModel>()
            //    .HasOne(s => s.TipoCliente)
            //    .WithMany(g => g.Clientes)
            //    .HasForeignKey(s => s.IdTipoCliente);
            //modelBuilder.Entity<ClienteViewModel>()
            //    .HasOne(s => s.FormaPago)
            //    .WithMany(g => g.Clientes)
            //    .HasForeignKey(s => s.IdFormaPago);
            //modelBuilder.Entity<ClienteViewModel>()
            //    .HasMany(cc => cc.Contactos_Cliente)
            //    .WithOne(c => c.Cliente)
            //    .HasForeignKey(cc => cc.IdCliente)
            //    .OnDelete(DeleteBehavior.Cascade);
            //modelBuilder.Entity<ClienteViewModel>()
            //    .HasMany(cc => cc.Contactos_Cliente_General)
            //    .WithOne(c => c.Cliente)
            //    .HasForeignKey(cc => cc.IdCliente)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
