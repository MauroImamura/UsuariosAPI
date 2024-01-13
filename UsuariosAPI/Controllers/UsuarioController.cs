using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService cadastroService)
    {
        _usuarioService = cadastroService;
    }

    [HttpPost("Cadastro")]
    public async Task<IActionResult> CadastraUsuarioAsync(CreateUsuarioDto dto)
    {
        await _usuarioService.CadastrarUsuarioAsync(dto);
        return Ok("Usuário cadastrado com sucesso!");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto)
    {
        var token = await _usuarioService.LoginAsync(dto);
        return Ok(token);
    }
}
