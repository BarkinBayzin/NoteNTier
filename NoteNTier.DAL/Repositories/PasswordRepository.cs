using NoteNTier.DAL.Context;
using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.DAL.Repositories
{
    public class PasswordRepository
    {
        NoteDbContext _context;
        public PasswordRepository()
        {
            _context = new NoteDbContext();
        }

        //Son 3 password kontorlü
        public List<Password> GetLastThreePasswords(int userId)
        {
            return _context.Passwords.Where(a => a.UserID == userId).OrderByDescending(x => x.CreatedDate).Take(3).ToList();
        }

        public bool Insert(Password password)
        {
            _context.Passwords.Add(password);
            return _context.SaveChanges() > 0;
        }

        public Password GetActivePassword(int userId)
        {
            return _context.Passwords.Where(a => a.UserID == userId).OrderByDescending(a => a.CreatedDate).FirstOrDefault();
        }
    }
}
