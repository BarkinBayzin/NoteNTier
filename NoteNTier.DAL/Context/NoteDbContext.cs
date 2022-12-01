using NoteNTier.DAL.EntityConfiguration;
using NoteNTier.DAL.Strategy;
using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.DAL.Context
{
    internal class NoteDbContext:DbContext
    {
        public NoteDbContext():base("Data Source=.\\SQLEXPRESS; Initial Catalog=NTierNoteDb;Integrated Security=True;")
        {
            //Strategy
            Database.SetInitializer(new NoteStrategy());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Password> Passwords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NoteConfiguration());
            modelBuilder.Configurations.Add(new PasswordConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
        }
    }
}
