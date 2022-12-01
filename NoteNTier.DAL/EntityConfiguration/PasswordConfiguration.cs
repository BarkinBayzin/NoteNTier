using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.DAL.EntityConfiguration
{
    internal class PasswordConfiguration:EntityTypeConfiguration<Password>
    {
        public PasswordConfiguration()
        {
            Property(a => a.Text).IsRequired().HasMaxLength(20);

            HasRequired(a => a.User).WithMany(a => a.Passwords).HasForeignKey(a => a.UserID);
        }
    }
}
