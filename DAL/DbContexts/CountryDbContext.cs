using System;
using Microsoft.EntityFrameworkCore;
using ApiVersioning.DAL.Entities;

namespace ApiVersioning.DAL.DbContexts
{
	public class CountryDbContext : DbContext
	{
        public CountryDbContext(DbContextOptions options) : base(options)
        {

        }
		public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

