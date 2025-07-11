using DTO;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;
using DAL;

namespace DAL.Repositories
{
    public class UtilizadorRepository : IUtilizadorRepository
    {
        private readonly MarcacoesOnlineDbContext _context;
        public UtilizadorRepository(MarcacoesOnlineDbContext context) => _context = context;

        public async Task<List<UtilizadorDTO>> ObterTodosAsync() =>
            await _context.Utilizadores
                .Select(u => new UtilizadorDTO {
                    Nome = u.Nome,
                    DataNascimento = u.DataNascimento,
                    Morada = u.Morada,
                    UrlDaFotografia = u.UrlDaFotografia,
                    EstadoDoUtilizador = (bool)u.EstadoDoUtilizador,
                    TipoUtilizador = u.TipoUtilizador.ToString()
                })
                .ToListAsync();

        public async Task<UtilizadorDTO?> ObterPorIdAsync(int id) =>
            await _context.Utilizadores
                .Where(u => u.Id == id)
                .Select(u => new UtilizadorDTO {
                    Nome = u.Nome,
                    DataNascimento = u.DataNascimento,
                    Morada = u.Morada,
                    UrlDaFotografia = u.UrlDaFotografia,
                    EstadoDoUtilizador = (bool)u.EstadoDoUtilizador,
                    TipoUtilizador = u.TipoUtilizador.ToString()
                })
                .FirstOrDefaultAsync();

        public async Task<bool> CriarAsync(UtilizadorDTO u)
        {
            var entity = new Utilizador {
                Nome = u.Nome,
                DataNascimento = u.DataNascimento,
                Morada = u.Morada,
                UrlDaFotografia = u.UrlDaFotografia,
                EstadoDoUtilizador =  true,
                TipoUtilizador = Enum.Parse<TipoUtilizador>(u.TipoUtilizador)
            };
            _context.Utilizadores.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AtualizarAsync(UtilizadorDTO u)
        {
            var entity = await _context.Utilizadores.FindAsync(u.Nome);
            if (entity == null) return false;
            entity.Nome = u.Nome;
            entity.DataNascimento = u.DataNascimento;
            entity.Morada = u.Morada;
            entity.UrlDaFotografia = u.UrlDaFotografia;
            entity.EstadoDoUtilizador = true;
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

        public async Task<Utilizador?> ObterPorEmailAsync(string email)
        {
            return await _context.Utilizadores.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
