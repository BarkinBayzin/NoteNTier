using NoteNTier.Model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.Model.Entities
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public UserType UserType { get; set; } //Kullanıcı admin mi standart mı
        public bool IsActive { get; set; } //Admin tarafından onaylı kullanıcı mı

        //Navigation Props. Begin
        public virtual ICollection<Password> Passwords { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
