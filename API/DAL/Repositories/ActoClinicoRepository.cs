using DAL;
using DTO;
using Interfaces;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL.Repositories
{
    public class ActoClinicoRepository : IActoClinicoRepository
    {
        private readonly MarcacoesOnlineDbContext _context;

        public ActoClinicoRepository(MarcacoesOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<List<ActoClinicoDTO>> ObterTodosAsync()
        {
            return await _context.ActosClinico
                .Select(a => new ActoClinicoDTO
                {
                    Id = a.Id,
                    TipoDeActoClinico = a.TipoDeActoClinico,
                    SubSistemaDeSaude = a.SubSistemaDeSaude,
                    Observacoes = a.Observacoes,
                    PedidoDeMarcacaoId = a.PedidoDeMarcacaoId
                }).ToListAsync();
        }

        public async Task<ActoClinicoDTO> ObterPorIdAsync(int id)
        {
            var acto = await _context.ActosClinico.FindAsync(id);
            if (acto == null) return null;

            return new ActoClinicoDTO
            {
                Id = acto.Id,
                TipoDeActoClinico = acto.TipoDeActoClinico,
                SubSistemaDeSaude = acto.SubSistemaDeSaude,
                Observacoes = acto.Observacoes,
                PedidoDeMarcacaoId = acto.PedidoDeMarcacaoId
            };
        }

        public async Task<bool> CriarAsync(ActoClinicoDTO dto)
        {
            var acto = new ActoClinico
            {
                TipoDeActoClinico = dto.TipoDeActoClinico,
                SubSistemaDeSaude = dto.SubSistemaDeSaude,
                Observacoes = dto.Observacoes,
                PedidoDeMarcacaoId = dto.PedidoDeMarcacaoId
            };

            _context.ActosClinico.Add(acto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AtualizarAsync(ActoClinicoDTO dto)
        {
            var acto = await _context.ActosClinico.FindAsync(dto.Id);
            if (acto == null) return false;

            acto.TipoDeActoClinico = dto.TipoDeActoClinico;
            acto.SubSistemaDeSaude = dto.SubSistemaDeSaude;
            acto.Observacoes = dto.Observacoes;
            acto.PedidoDeMarcacaoId = dto.PedidoDeMarcacaoId;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var acto = await _context.ActosClinico.FindAsync(id);
            if (acto == null) return false;

            _context.ActosClinico.Remove(acto);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
