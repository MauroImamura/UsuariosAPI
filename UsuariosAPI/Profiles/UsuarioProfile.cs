using AutoMapper;
using UsuariosApi.Models;
using UsuariosAPI.Data.Dtos;

namespace UsuariosApi.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}