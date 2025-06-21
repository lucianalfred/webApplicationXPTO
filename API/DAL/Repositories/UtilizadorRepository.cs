using DTO;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;

public class UtilizadorRepository : IUtilizadorRepository
{
    private readonly AppDbContext _context;
    public UtilizadorRepository(AppDbContext context) => _context = context;

    public async Task<List<UtilizadorDTO>> ObterTodosAsync() =>
        await _context.Utilizadores
            .Select(u => new UtilizadorDTO {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Password = u.Password,
                DataNascimento = u.DataNascimento,
                Morada = u.Morada,
                UrlDaFotografia = u.UrlDaFotografia,
                EstadoDoUtilizador = u.EstadoDoUtilizador,
                TipoUtilizador = u.TipoUtilizador.ToString()
            })
            .ToListAsync();

    public async Task<UtilizadorDTO> ObterPorIdAsync(int id) =>
        await _context.Utilizadores
            .Where(u => u.Id == id)
            .Select(u => new UtilizadorDTO {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Password = u.Password,
                DataNascimento = u.DataNascimento,
                Morada = u.Morada,
                UrlDaFotografia = u.UrlDaFotografia,
                EstadoDoUtilizador = u.EstadoDoUtilizador,
                TipoUtilizador = u.TipoUtilizador.ToString()
            })
            .FirstOrDefaultAsync();

    public async Task<bool> CriarAsync(UtilizadorDTO u)
    {
        var entity = new Utilizador {
            Nome = u.Nome,
            Email = u.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(u.Password),
            DataNascimento = u.DataNascimento,
            Morada = u.Morada,
            UrlDaFotografia = u.UrlDaFotografia,
            EstadoDoUtilizador = u.EstadoDoUtilizador,
            TipoUtilizador = Enum.Parse<TipoUtilizador>(u.TipoUtilizador)
        };
        _context.Utilizadores.Add(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> AtualizarAsync(UtilizadorDTO u)
    {
        var entity = await _context.Utilizadores.FindAsync(u.Id);
        if (entity == null) return false;
        entity.Nome = u.Nome;
        entity.Email = u.Email;
        if (!BCrypt.Net.BCrypt.Verify(u.Password, entity.Password))
            entity.Password = BCrypt.Net.BCrypt.HashPassword(u.Password);
        entity.DataNascimento = u.DataNascimento;
        entity.Morada = u.Morada;
        entity.UrlDaFotografia = u.UrlDaFotografia;
        entity.EstadoDoUtilizador = u.EstadoDoUtilizador;
        entity.TipoUtilizador = Enum.Parse<TipoUtilizador>(u.TipoUtilizador);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var entity = await _context.Utilizadores.FindAsync(id);
        if (entity == null) return false;
        _context.Utilizadores.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}
