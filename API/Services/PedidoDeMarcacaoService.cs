using DTO;
using Interfaces.Repositories;
using Interfaces.Services;
using Model;

namespace Services
{
    public class PedidoDeMarcacaoService : IPedidoDeMarcacaoService
    {
        private readonly IPedidoDeMarcacaoRepository _repository;

        public PedidoDeMarcacaoService(IPedidoDeMarcacaoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<PedidoDeMarcacaoDTO> GetAll()
        {
            var pedidos = _repository.GetAllAsync().Result;
            return pedidos.Select(p => new PedidoDeMarcacaoDTO
            {
                Id = p.Id,
                Estado = p.EstadoDoPedidoDeMarcacao.ToString(),
                DataCriacao = p.DataDeCriacaoDoPedidoMarcacao,
                IntervaloDatas = p.IntervaloDeDatasDoPedidoDeMarcacao,
                Observacoes = p.Observacoes,
                UtenteRegistadoId = p.Utente?.Id,
                AdminstractivoId = p.Adminstractivo?.Id,
                DataAgendamento = p.DataDeAgendamentoDoPedidoDeMarcacao,

            });
        }

        public PedidoDeMarcacaoDTO GetById(int id)
        {
            var pedido = _repository.GetByIdAsync(id).Result;
            if (pedido == null) return null;

            return new PedidoDeMarcacaoDTO
            {
                Id = pedido.Id,
                Estado = pedido.EstadoDoPedidoDeMarcacao.ToString(),
                DataCriacao = pedido.DataDeCriacaoDoPedidoMarcacao,
                IntervaloDatas = pedido.IntervaloDeDatasDoPedidoDeMarcacao,
                Observacoes = pedido.Observacoes,
                UtenteRegistadoId = pedido.Utente?.Id,
                AdminstractivoId = pedido.Adminstractivo?.Id,
                DataAgendamento = pedido.DataDeAgendamentoDoPedidoDeMarcacao,
                ActosClinicoIds = pedido.ActosClinico?.Select(a => a.Id).ToList()
            };
        }

        public bool Save(PedidoDeMarcacaoDTO dto)
        {
            var pedido = new PedidoDeMarcacao
            {
                EstadoDoPedidoDeMarcacao = Enum.Parse<EstadoDoPedidoDeMarcacao>(dto.Estado),
                DataDeCriacaoDoPedidoMarcacao = dto.DataCriacao,
                IntervaloDeDatasDoPedidoDeMarcacao = dto.IntervaloDatas,
                Observacoes = dto.Observacoes,
                DataDeAgendamentoDoPedidoDeMarcacao = dto.DataAgendamento,
                Utente = dto.UtenteRegistadoId != null ? new UtenteRegistado { Id = dto.UtenteRegistadoId.Value } : null,
                Adminstractivo = dto.AdminstractivoId != null ? new Adminstractivo { Id = dto.AdminstractivoId.Value } : null,
                ActosClinico = dto.ActosClinicoIds?.Select(id => new ActoClinico { Id = id }).ToList()

            };

            return _repository.SaveAsync(pedido).Result;
        }

        public bool Update(PedidoDeMarcacaoDTO dto)
        {
            var pedido = new PedidoDeMarcacao
            {
                Id = dto.Id,
                EstadoDoPedidoDeMarcacao = Enum.Parse<EstadoDoPedidoDeMarcacao>(dto.Estado),
                DataDeCriacaoDoPedidoMarcacao = dto.DataCriacao,
                IntervaloDeDatasDoPedidoDeMarcacao = dto.IntervaloDatas,
                Observacoes = dto.Observacoes,
                DataDeAgendamentoDoPedidoDeMarcacao = dto.DataAgendamento,
                Utente = dto.UtenteRegistadoId != null ? new UtenteRegistado { Id = dto.UtenteRegistadoId.Value } : null,
                Adminstractivo = dto.AdminstractivoId != null ? new Adminstractivo { Id = dto.AdminstractivoId.Value } : null,
                ActosClinico = dto.ActosClinicoIds?.Select(id => new ActoClinico { Id = id }).ToList()
            };

            return _repository.UpdateAsync(pedido).Result;
        }

        public bool Delete(int id)
        {
            var pedido = _repository.GetByIdAsync(id).Result;
            if (pedido == null) return false;
            return _repository.DeleteAsync(pedido).Result;
        }
    }
}
