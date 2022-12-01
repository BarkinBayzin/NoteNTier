using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.Model.Entities
{
    public class Password:BaseEntity
    {
        public string Text { get; set; }

        //ForeignKey
        public int UserID { get; set; }

        //Navigation Props. 
        public virtual User User { get; set; }

    }
}
