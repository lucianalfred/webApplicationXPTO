using Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;
using DAL;

namespace Repositories
{
    public class PedidoDeMarcacaoRepository : IPedidoDeMarcacaoRepository
    {
        private readonly MarcacoesOnlineDbContext _context;

        public PedidoDeMarcacaoRepository(MarcacoesOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<List<PedidoDeMarcacao>> ObterTodosAsync()
        {
            return await _context.PedidosDeMarcacao
                .Include(p => p.Utente)
                .Include(p => p.Adminstractivo)
                .Include(p => p.ActosClinico)
                .ToListAsync();
        }

        public async Task<PedidoDeMarcacao> ObterPorIdAsync(int id)
        {
            return await _context.PedidosDeMarcacao
                .Include(p => p.Utente)
                .Include(p => p.Adminstractivo)
                .Include(p => p.ActosClinico)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PedidoDeMarcacao> CriarAsync(PedidoDeMarcacao pedido)
        {
            _context.PedidosDeMarcacao.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task AtualizarAsync(PedidoDeMarcacao pedido)
        {
            _context.PedidosDeMarcacao.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(PedidoDeMarcacao pedido)
        {
            _context.PedidosDeMarcacao.Remove(pedido);
            await _context.SaveChangesAsync();
        }
    }
}
