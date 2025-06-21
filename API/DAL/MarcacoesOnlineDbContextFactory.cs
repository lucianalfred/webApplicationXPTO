using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DAL;

public class MarcacoesOnlineDbContextFactory : IDesignTimeDbContextFactory<MarcacoesOnlineDbContext>
{
    public MarcacoesOnlineDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MarcacoesOnlineDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=master;User Id=sa;Password=PalavraPasse@123;TrustServerCertificate=True;Encrypt=False;");

        return new MarcacoesOnlineDbContext(optionsBuilder.Options);
    }
}
