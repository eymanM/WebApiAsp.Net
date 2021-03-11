using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial.Entities
{
    public class MeetupContext : DbContext
    {
        private string _connectionString = "Server=localhost;Database=MeetupDb;Trusted_Connection=True;";

        //tables on DB
        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Lecture> Lectures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // for meetup is one location, Location foreign key is on property MeetupId
            modelBuilder.Entity<Meetup>()
                .HasOne(m => m.Location)
                .WithOne(l => l.Meetup)
                .HasForeignKey<Location>(l => l.MeetupId);

            modelBuilder.Entity<Meetup>()
                .HasMany(m => m.Lectures)
                .WithOne(l => l.Meetup);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection with DB
            optionsBuilder.UseSqlServer(_connectionString);
            //in Packet Manager Console : add-migration <name>
            // add-migration Init
            // update-database - create database PM console
        }

    }
}
