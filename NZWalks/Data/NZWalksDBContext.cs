using System;
using NZWalks.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.Data
{
	public class NZWalksDBContext:DbContext
	{
		public NZWalksDBContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
			
		}
		public DbSet<Difficulty> difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walks> Walks { get; set; }
    }
}

