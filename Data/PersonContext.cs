using Microsoft.EntityFrameworkCore;
using Person.Models;

namespace Person.Data;

public class PersonContext : DbContext
{
    public DbSet<PersonModel> People { get; set; } // DbSet é uma representação de uma tabela no banco de dados

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Configuração do banco de dados
    { 
        optionsBuilder.UseSqlite("Data Source=person.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}