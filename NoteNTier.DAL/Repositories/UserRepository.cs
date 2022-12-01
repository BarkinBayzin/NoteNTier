using NoteNTier.DAL.Context;
using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.DAL.Repositories
{
    public class UserRepository
    {
        NoteDbContext _context;
        PasswordRepository _passwordRepository;
        public UserRepository()
        {
            _context = new NoteDbContext();
            _passwordRepository = new PasswordRepository();
        }

        public bool Insert(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges() > 0;
        }

        public User CheckLogin(string userName, string password)
        {
            User user = _context.Users.Where(a => a.UserName == userName).SingleOrDefault();
            if (user != null)
            {
                Password userPassword = _passwordRepository.GetActivePassword(user.ID);
                if (userPassword != null && userPassword.Text == password)
                    return user;
            }
            return null;
        }

        public User GetUserById(int userId) => _context.Users.Find(userId);

        public void UserActivated(User user)
        {
            User activatedUser = GetUserById(user.ID);
            activatedUser.IsActive = true;
            _context.SaveChanges();
        }

        public List<User> GetPassiveUsers() => _context.Users.Where(x => !x.IsActive).ToList();
    }
}
