using IdentityNetCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityNetCore.Contexto
{
    public class IdentityContexto: IdentityDbContext<Usuario,Role,int,UsuarioNotificacion,UsuarioRole,UsuarioLogin,RoleNotificacion,UsuarioToken>
    {
        public IdentityContexto(DbContextOptions<IdentityContexto> option): base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder migrationBuilder)
        {
            base.OnModelCreating(migrationBuilder);
            migrationBuilder.Entity<Usuario>().ToTable<Usuario>("Usuario", "SEG");
            migrationBuilder.Entity<Role>().ToTable<Role>("Rol", "SEG");
            migrationBuilder.Entity<UsuarioNotificacion>().ToTable<UsuarioNotificacion>("UsuarioNotificacion", "SEG");
            migrationBuilder.Entity<UsuarioRole>().ToTable<UsuarioRole>("UsuarioRole", "SEG");
            migrationBuilder.Entity<UsuarioLogin>().ToTable<UsuarioLogin>("UsuarioLogin", "SEG");
            migrationBuilder.Entity<RoleNotificacion>().ToTable<RoleNotificacion>("RoleNotificacion", "SEG");
            migrationBuilder.Entity<UsuarioToken>().ToTable<UsuarioToken>("UsuarioToken", "SEG");

        }
    }
}
