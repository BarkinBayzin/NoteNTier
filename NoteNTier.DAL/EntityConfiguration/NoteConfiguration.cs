using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.DAL.EntityConfiguration
{
    class NoteConfiguration : EntityTypeConfiguration<Note>
    {
        public NoteConfiguration()
        {
            //modelbuilder.Entity<Note>
            Property(a => a.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); //Key yapılar otomatik identity'dir int ise. Identity olmaması için DatabaseGeneratedOption.None yapılmalıdır.

            Property(a => a.Content).IsRequired();
            Property(a => a.Title).IsRequired().HasMaxLength(100);
        }
    }
}
