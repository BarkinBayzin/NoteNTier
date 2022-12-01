using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.DAL.EntityConfiguration
{
    internal class UserConfiguration:EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(a => a.FirstName).IsRequired().HasMaxLength(100);
            Property(a => a.LastName).IsRequired().HasMaxLength(100);
            Property(a => a.UserName).IsRequired().HasMaxLength(20);

            HasIndex(a => a.UserName).IsUnique();

            //Relation / Navigation

            HasMany(a => a.Passwords).WithRequired(a => a.User).HasForeignKey(a => a.UserID);

            HasMany(a => a.Notes).WithRequired(a => a.User).HasForeignKey(a => a.UserID);
        }
    }
}
