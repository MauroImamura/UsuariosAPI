﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsuariosApi.Models;

namespace UsuariosAPI.Data;

public class UsuarioDbContext : IdentityDbContext<Usuario>
{
	public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opts) : base(opts)
	{

	}
}
