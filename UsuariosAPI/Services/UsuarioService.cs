using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosApi.Models;
using UsuariosAPI.Data.Dtos;

namespace UsuariosAPI.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        public async Task CadastrarUsuarioAsync(CreateUsuarioDto dto)
        {
            var usuario = _mapper.Map<Usuario>(dto);
            var resultado = await _userManager.CreateAsync(usuario, dto.Password);
            if (!resultado.Succeeded) throw new ApplicationException("Falha ao cadastrar o usuário.");
        }

        public async Task<string> LoginAsync(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            if (!resultado.Succeeded) throw new ApplicationException("Usuário não autenticado.");
            var usuario = _signInManager.UserManager.Users.FirstOrDefault(u => u.NormalizedUserName== dto.Username.ToUpper());
            return _tokenService.GenerateToken(usuario);
        }
    }
}
