using NoteNTier.DAL.Repositories;
using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.BLL.Services
{
    public class PasswordService
    {
        PasswordRepository _passwordRepository;
        public PasswordService()
        {
            _passwordRepository = new PasswordRepository();
        }

        bool CheckLastThreePasswords(Password password)
        {
            List<Password> lastPasswords = _passwordRepository.GetLastThreePasswords(password.UserID);
            foreach (var item in lastPasswords)
                if (item.Text == password.Text) throw new Exception("Bu şifre son üç şifreden biri");

            return true;
        }

        public bool Insert(Password password)
        {
            if(CheckLastThreePasswords(password))
            {
                password.CreatedDate = DateTime.Now;
                return _passwordRepository.Insert(password);
            }
            return false;
        }

        public Password GetActivePassword(int userId)
        {
            if (userId <= 0) throw new Exception("Parametre geçersiz");
            return _passwordRepository.GetActivePassword(userId);
        }
    }
}
