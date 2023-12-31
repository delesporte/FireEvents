﻿using FireEvents.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FireEvents.Data.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Associação de entidades N-N
            modelBuilder.Entity<PalestranteEvento>().HasKey(p => new
            {
                p.EventoId,
                p.PalestranteId
            });
        }
    }
}
