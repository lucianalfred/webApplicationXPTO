using DTO;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL.Repositories
{
    public class ProfissionalRepository : IProfissionalRepository
    {
        private readonly MarcacoesOnlineDbContext _context;

        public ProfissionalRepository(MarcacoesOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProfissionalDTO>> ObterTodosAsync()
        {
            return await _context.Profissionais
                .Select(p => new ProfissionalDTO
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Especialidade = p.Especialidade
                })
                .ToListAsync();
        }

        public async Task<ProfissionalDTO> ObterPorIdAsync(int id)
        {
            var profissional = await _context.Profissionais.FindAsync(id);
            if (profissional == null) return null;

            return new ProfissionalDTO
            {
                Id = profissional.Id,
                Nome = profissional.Nome,
                Especialidade = profissional.Especialidade
            };
        }

        public async Task<bool> CriarAsync(ProfissionalDTO dto)
        {
            var entity = new Profissional
            {
                Nome = dto.Nome,
                Especialidade = dto.Especialidade
            };

            _context.Profissionais.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AtualizarAsync(ProfissionalDTO dto)
        {
            var entity = await _context.Profissionais.FindAsync(dto.Id);
            if (entity == null) return false;

            entity.Nome = dto.Nome;
            entity.Especialidade = dto.Especialidade;

            _context.Profissionais.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var entity = await _context.Profissionais.FindAsync(id);
            if (entity == null) return false;

            _context.Profissionais.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
