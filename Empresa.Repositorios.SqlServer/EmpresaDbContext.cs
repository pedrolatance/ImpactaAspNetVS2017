﻿using Empresa.Dominio;
using Microsoft.EntityFrameworkCore;
using System;

namespace Empresa.Repositorios.SqlServer
{
    public class EmpresaDbContext : DbContext
    {
        public EmpresaDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Contato> Contatos { get; set; }
    }
}
