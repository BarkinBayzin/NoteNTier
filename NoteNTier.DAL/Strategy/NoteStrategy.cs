using NoteNTier.DAL.Context;
using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.DAL.Strategy
{
    internal class NoteStrategy:CreateDatabaseIfNotExists<NoteDbContext>
    {
        protected override void Seed(NoteDbContext context)
        {
            User user = new User
            {
                FirstName = "Admin",
                LastName = "Admin",
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                UserName = "admin",
                UserType = Model.Enum.UserType.Admin
            };

            user.Passwords.Add(new Password
            {
                CreatedDate = DateTime.UtcNow,
                Text = "qwerty"
            });

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
