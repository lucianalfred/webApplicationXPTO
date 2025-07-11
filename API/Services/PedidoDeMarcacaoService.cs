using DTO;
using Interfaces.Repositories;
using Interfaces.Services;
using Model;
using DAL;
using Microsoft.EntityFrameworkCore;


namespace Services
{
    public class PedidoDeMarcacaoService : IPedidoDeMarcacaoService
    {
            private readonly MarcacoesOnlineDbContext _context;
            private readonly IPedidoDeMarcacaoRepository _repository;
            private readonly IUtenteRegistadoRepository _utenteRepository;
            private IEmailRepository _emailservice;
            
            public PedidoDeMarcacaoService(IPedidoDeMarcacaoRepository repository, IEmailRepository emailRepository,IUtenteRegistadoRepository utenteRepository, MarcacoesOnlineDbContext context)
            {
                _repository = repository;
                _emailservice = emailRepository;
                _context = context;
                _utenteRepository = utenteRepository;
            }
    
            public IEnumerable<PedidoDeMarcacaoDTO> GetAll()
            {
                var pedidos = _repository.GetAllAsync().Result;
                return pedidos.Select(p => new PedidoDeMarcacaoDTO
                {
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
                Estado = pedido.EstadoDoPedidoDeMarcacao.ToString(),
                DataCriacao = pedido.DataDeCriacaoDoPedidoMarcacao,
                IntervaloDatas = pedido.IntervaloDeDatasDoPedidoDeMarcacao,
                Observacoes = pedido.Observacoes,
                UtenteRegistadoId = pedido.Utente?.Id,
                AdminstractivoId = pedido.Adminstractivo?.Id,
                DataAgendamento = pedido.DataDeAgendamentoDoPedidoDeMarcacao,
            };
        }
//

        public async Task<bool> Save(PedidoDeMarcacaoDTO dto)
        {
            var pedido = new PedidoDeMarcacao
            {
                EstadoDoPedidoDeMarcacao = Enum.TryParse(dto.Estado, out EstadoDoPedidoDeMarcacao estado) ? estado : EstadoDoPedidoDeMarcacao.PEDIDO,
                DataDeCriacaoDoPedidoMarcacao = dto.DataCriacao,
                IntervaloDeDatasDoPedidoDeMarcacao = dto.IntervaloDatas,
                Observacoes = dto.Observacoes,
                DataDeAgendamentoDoPedidoDeMarcacao = dto.DataAgendamento,
                IdUsuario = dto.IdUsuario,  // Liga ao IdentityUser

                ActosClinico = dto.ActosClinico?.Select(a => new ActoClinico
                {
                    TipoDeActoClinico = a.TipoDeActoClinico,
                    SubSistemaDeSaude = a.SubSistemaDeSaude,
                    ProfissionalId = a.ProfissionalId
                }).ToList()
            };

            if (dto.UtenteRegistadoId.HasValue)
                pedido.UtenteRegistadoId = dto.UtenteRegistadoId;

            if (dto.AdminstractivoId.HasValue)
                pedido.AdminstractivoId = dto.AdminstractivoId;

        return await _repository.SaveAsync(pedido);
    }



//


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
            };

            return _repository.UpdateAsync(pedido).Result;
        }

        public bool Delete(int id)
        {
            var pedido = _repository.GetByIdAsync(id).Result;
            if (pedido == null) return false;
            return _repository.DeleteAsync(pedido).Result;
        }


        //

        public async Task<bool> SaveAnonimo(PedidoDeMarcacaoAnonimoDTO dto)
        {
            try
            {
                // Cria o utente
                var utente = new Utilizador
                {
                    Nome = dto.Utente.Nome,
                    DataNascimento = dto.Utente.DataNascimento,
                    Morada = dto.Utente.Morada,
                    UrlDaFotografia = dto.Utente.UrlDaFotografia,
                    EstadoDoUtilizador = (bool)dto.Utente.EstadoDoUtilizador,
                    Email = dto.Email,
                    Telefone = dto.Telefone,
                    Genero = dto.Genero
            };

            var pedido = new PedidoDeMarcacao
            {
                
                
                Observacoes = dto.Observacoes,
                IntervaloDeDatasDoPedidoDeMarcacao = dto.IntervaloDatas,
                DataDeCriacaoDoPedidoMarcacao = DateTime.Now,
                EstadoDoPedidoDeMarcacao = EstadoDoPedidoDeMarcacao.PEDIDO, 
                ActosClinico = dto.ActosClinicos.Select(a => new ActoClinico
                {
                    TipoDeActoClinico = a.TipoDeActoClinico,
                    SubSistemaDeSaude = a.SubSistemaDeSaude ,
                    ProfissionalId = a.ProfissionalId
                }).ToList()
            };

            await _emailservice.EnviarConfirmacaoPedidoAsync(dto.Email, dto.Utente.Nome, dto.NumeroUtente);

            return await _repository.SaveAnonimoAsync(pedido);
        }
        catch
        {
            return false;
        }
    }


    }
     
}