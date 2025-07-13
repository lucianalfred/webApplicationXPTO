using DTO;
using Interfaces.Repositories;
using Interfaces.Services;
using Model;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared;

public class UtilizadorService : IUtilizadorService
{
    private readonly UserManager<Utilizador> _manager;
    private readonly IMapper _map;      

    public UtilizadorService(UserManager<Utilizador> manager, IMapper map)
    { _manager = manager; _map = map; }

    public async Task<IEnumerable<UtilizadorDTO>> ObterTodosAsync()
        => _map.ProjectTo<UtilizadorDTO>(_manager.Users);

    public async Task<UtilizadorDTO?> ObterPorIdAsync(int id)
    {
        var u = await _manager.Users.FirstOrDefaultAsync(x => x.Id == id);
        return u == null ? null : _map.Map<UtilizadorDTO>(u);
    }
    public async Task<bool> CriarAsync(UtilizadorDTO dto)
    {
        var u = _map.Map<Utilizador>(dto);
        var res = await _manager.CreateAsync(u, "SenhaForte123!");
        return res.Succeeded;
    }

    public async Task<bool> AtualizarAsync(UtilizadorDTO dto)
    {
        var u = await _manager.FindByIdAsync(dto.Id.ToString());
        if (u is null) return false;
        _map.Map(dto, u);
        var res = await _manager.UpdateAsync(u);
        return res.Succeeded;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var u = await _manager.FindByIdAsync(id.ToString());
        if (u is null) return false;
        var res = await _manager.DeleteAsync(u);
        return res.Succeeded;
    }
}
