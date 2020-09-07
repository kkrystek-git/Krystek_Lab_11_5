using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Krystek_Lab_11_5
{
	// Define access to SQL database Sakila.
	class SakilaContext : DbContext
	{
		public DbSet<Film> Film { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// Data connection string to updated version of Sakila databasewith no NULLs allowed.
			optionsBuilder.UseSqlServer(@"server=KRYSTEKPC;Database=sakila;Trusted_Connection=True;");
		}
	}
}
