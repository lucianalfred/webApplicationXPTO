using AutoMapper;
using DAL;
using DTO;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Services
{
    public class PedidoDeMarcacaoService : IPedidoDeMarcacaoService
    {
        private readonly MarcacoesOnlineDbContext _context;
        private readonly IMapper _mapper;

        public PedidoDeMarcacaoService(MarcacoesOnlineDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PedidoDeMarcacaoDTO>> ObterTodosAsync()
        {
            var pedidos = await _context.PedidosDeMarcacao
                .Include(p => p.Utente)
                .Include(p => p.Adminstractivo)
                .Include(p => p.ActosClinico)
                .ToListAsync();

            return _mapper.Map<List<PedidoDeMarcacaoDTO>>(pedidos);
        }

        public async Task<PedidoDeMarcacaoDTO> ObterPorIdAsync(int id)
        {
            var pedido = await _context.PedidosDeMarcacao
                .Include(p => p.Utente)
                .Include(p => p.Adminstractivo)
                .Include(p => p.ActosClinico)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pedido == null) return null;

            return _mapper.Map<PedidoDeMarcacaoDTO>(pedido);
        }

        public async Task<PedidoDeMarcacaoDTO> CriarAsync(PedidoDeMarcacaoDTO novoPedidoDto)
        {
            var pedido = _mapper.Map<PedidoDeMarcacao>(novoPedidoDto);

            _context.PedidosDeMarcacao.Add(pedido);
            await _context.SaveChangesAsync();

            return _mapper.Map<PedidoDeMarcacaoDTO>(pedido);
        }

        public async Task<bool> AtualizarAsync(PedidoDeMarcacaoDTO pedidoAtualizadoDto)
        {
            var pedidoExistente = await _context.PedidosDeMarcacao.FindAsync(pedidoAtualizadoDto.Id);

            if (pedidoExistente == null)
                return false;

            _mapper.Map(pedidoAtualizadoDto, pedidoExistente);
            _context.PedidosDeMarcacao.Update(pedidoExistente);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var pedido = await _context.PedidosDeMarcacao.FindAsync(id);
            if (pedido == null)
                return false;

            _context.PedidosDeMarcacao.Remove(pedido);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
