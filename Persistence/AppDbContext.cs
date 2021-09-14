using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Persistence
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		public DbSet<Event> Events { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var utcConverter = new ValueConverter<DateTime, DateTime>(
				toDb => toDb,
				fromDb => DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));

			modelBuilder.Entity<Event>().Property(e => e.Date).HasConversion(utcConverter);
		}
	}
}