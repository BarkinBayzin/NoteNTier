using NoteNTier.DAL.Context;
using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.DAL.Repositories
{
    public class NoteRepository //Note ile ilgili işlemleri barındıracak, işlemlerden sorumlu class
    {
        NoteDbContext _context;
        public NoteRepository()
        {
           _context = new NoteDbContext();
        }
        /// <summary>
        /// Kullanıcıya ait notları çeker
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Note> GetByUserId(int userId) => 
            _context.Notes.Where(x => x.UserID == userId && x.IsActive).ToList();

        /// <summary>
        /// Argüman kullanılarak ilgili note datasını getirir
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns>Argümanla eşleşen data dönülür</returns>
        public Note GetByNoteId(int noteId) =>
            _context.Notes.Find(noteId);

        public bool Insert(Note note)
        {
            _context.Notes.Add(note);
            return _context.SaveChanges() > 0; //SaveChanges işlemi başarılı döndüğü takdirde true yani 1 değerini dönecektir, aksi takdirde false yani 0 değerini döner, böylelikle insert methodunun dönüşü ile algortimalar şekillenebilir.
        }
        public bool Update(Note note)
        {
            Note updatedNote = GetByNoteId(note.ID);
            updatedNote.Title = note.Title;
            updatedNote.Content = note.Content;
            return _context.SaveChanges() > 0;
        }

        public bool Delete(Note note)
        {
            Note deletedNote = GetByNoteId(note.ID);
            deletedNote.IsActive = false;
            return _context.SaveChanges() > 0;
        }
    }
}
