using Microsoft.EntityFrameworkCore;
using WebMVC.Models;



public class contextoAplicacion : DbContext
{
    public contextoAplicacion(DbContextOptions<contextoAplicacion> options)
        : base(options)
    {
    }    

    public DbSet<Login> login { get; set; }

    public DbSet<CursoEstudiante> CursoEstudiante { get; set; }

    public DbSet<Curso> curso { get; set; }

    public DbSet<Estudiante> Estudiante { get; set; }

    public DbSet<Programa> programa { get; set; }

    public DbSet<Matricula> matricula { get; set; }

    public DbSet<Clase> clase { get; set; }

    public DbSet<Profesor> profesor { get; set; }

    public DbSet<Feriado> feriado { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CursoEstudiante>()
            .HasKey(c => new { c.Id_curso, c.Id_estudiante });

        /*modelBuilder.Entity<CursoEstudiante>()
            .HasOne(x => x.estudiante).WithMany(x => x.cursosEstudiante);

        modelBuilder.Entity<Clase>()
            .HasOne(x => x.estudiante).WithMany(x => x.clases);

        modelBuilder.Entity<Matricula>()
            .HasOne(x => x.estudiante).WithMany(x => x.matriculas);

        modelBuilder.Entity<Programa>()
            .HasMany(x => x.Cursos).WithOne(x => x.programa);

        modelBuilder.Entity<Profesor>()
            .HasMany(x => x.clases).WithOne(x => x.profesor);

        modelBuilder.Entity<Curso>()
            .HasMany(x => x.cursoEstudiantes).WithOne(x => x.curso);*/


        base.OnModelCreating(modelBuilder);
    }
}
