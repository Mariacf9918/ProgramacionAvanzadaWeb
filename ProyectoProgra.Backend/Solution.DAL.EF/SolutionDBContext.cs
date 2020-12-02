using Microsoft.EntityFrameworkCore;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.DAL.EF
{
    public class SolutionDBContext:DbContext
    {
        public SolutionDBContext(DbContextOptions<SolutionDBContext> options)
            : base(options)
        {

        }

        public DbSet<Calificaciones> Calificaciones { get; set; }
        public DbSet<Grados> Grados { get; set; }
        public DbSet<Grupos> Grupos { get; set; }
        public DbSet<Instituciones> Instituciones { get; set; }
        public DbSet<Materias> Materias { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<TipoOperaciones> TipoOperaciones { get; set; }
        public DbSet<TipoPeriodo> TipoPeriodo { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuarioXGrupo> UsuarioXGrupo { get; set; }
        public DbSet<UsuarioXInstitucion> UsuarioXInstitucion { get; set; }

    }
}
