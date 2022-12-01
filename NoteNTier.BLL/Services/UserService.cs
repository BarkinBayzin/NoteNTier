using NoteNTier.DAL.Repositories;
using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.BLL.Services
{
    public class UserService
    {
        UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public bool Insert(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
                throw new Exception("FirstName ve/veya LastName bilgilerini giriniz.");

            Password firstPassword = user.Passwords.FirstOrDefault();
            if (firstPassword == null) throw new Exception("Password giriniz");

            user.CreatedDate = DateTime.Now;
            user.Passwords.FirstOrDefault().CreatedDate=DateTime.Now;
            user.IsActive = false;
            user.UserType = Model.Enum.UserType.Standart;
            return _userRepository.Insert(user);
        }

        public User CheckLogin(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                throw new Exception("userName ve/veya password bilgilerini giriniz.");
            return _userRepository.CheckLogin(userName, password);
        }

        public void UserActivated(User user)
        {
            CheckUserId(user);
            _userRepository.UserActivated(user);
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        void CheckUserId(User user)
        {
            if (user.ID <= 0) throw new Exception("User id boş olamaz");
        }

        public void UserActivated(int id)
        {
            User user = _userRepository.GetUserById(id);
            CheckUserId(user);
            _userRepository.UserActivated(user);
        }

        public List<User> GetPassiveUsers()
        {
            return _userRepository.GetPassiveUsers();
        }
    }
}
