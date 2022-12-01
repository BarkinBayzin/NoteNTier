using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.Model.Entities
{
    public class Note : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; } //Not silinmek istenir ise db'den silmeyeceğiz, pasife çekeceğiz
        public int UserID { get; set; }

        //Navigation Props
        public virtual User User { get; set; }
    }
}
