using DAL;
using Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL.Repositories
{
    public class PedidoDeMarcacaoRepository : IPedidoDeMarcacaoRepository
    {
        private readonly MarcacoesOnlineDbContext _context;


        public async Task<bool> SaveAnonimoAsync(PedidoDeMarcacao pedido)
{
    try
    {
        _context.PedidosDeMarcacao.Add(pedido);
        await _context.SaveChangesAsync();
        return true;
    }
    catch
    {
        return false;
    }
}

        public PedidoDeMarcacaoRepository(MarcacoesOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PedidoDeMarcacao>> GetAllAsync()
        {
            return await _context.PedidosDeMarcacao
                .Include(p => p.Utente)
                .Include(p => p.Adminstractivo)
                .Include(p => p.ActosClinico)
                .ToListAsync();
        }

        public async Task<PedidoDeMarcacao?> GetByIdAsync(int id)
        {
            return await _context.PedidosDeMarcacao
                .Include(p => p.Utilizador)
                .Include(p => p.Adminstractivo)
                .Include(p => p.ActosClinico)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

// get by user id 
        public async Task<IEnumerable<PedidoDeMarcacao>> GetByUsuarioAsync(int idUsuario)
                => await _context.PedidosDeMarcacao
                     .Include(p => p.ActosClinico)
                     .Where(p => p.IdUsuario == idUsuario) 
                     .AsNoTracking()
                     .ToListAsync();
            
        public async Task<bool> SaveAsync(PedidoDeMarcacao pedido)
        {
            _context.PedidosDeMarcacao.Add(pedido);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(PedidoDeMarcacao pedido)
        {
            _context.PedidosDeMarcacao.Update(pedido);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(PedidoDeMarcacao pedido)
        {
            _context.PedidosDeMarcacao.Remove(pedido);
            return await _context.SaveChangesAsync() > 0;
        }
    //agendar

        public async Task<bool> AgendarAsync(int id, DateTime data)
        {
            var pedido = await _context.PedidosDeMarcacao.FindAsync(id);
            if (pedido == null) return false;

            pedido.EstadoDoPedidoDeMarcacao =  Model.EstadoDoPedidoDeMarcacao.AGENDADO;
            pedido.DataDeAgendamentoDoPedidoDeMarcacao = data;
            

            _context.PedidosDeMarcacao.Update(pedido);
            return await _context.SaveChangesAsync() > 0;
        }
    
    }
}
