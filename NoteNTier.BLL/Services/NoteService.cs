using NoteNTier.DAL.Repositories;
using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteNTier.BLL.Services
{
    public class NoteService
    {
        NoteRepository _noteRepository;
        public NoteService()
        {
            _noteRepository = new NoteRepository();
        }

        public List<Note> GetById(int userID)
        {
            List<Note> notes = new List<Note>();

            if (userID > 0) notes = _noteRepository.GetByUserId(userID);
            else throw new Exception("Parametre değeri uygun değil");

            return notes;
        }

        public Note GetByNoteId(int noteID)
        {
            Note note = new Note();

            CheckNoteId(noteID);

            note = _noteRepository.GetByNoteId(noteID);

            return note;
        }

        void CheckNoteId(int noteID)
        {
            if (noteID <= 0) throw new Exception("Parametre değeri uygun değil");
        }

        public bool Insert(Note note)
        {
            CheckTitleContent(note);
            note.CreatedDate = DateTime.Now;
            note.IsActive = true;
            return _noteRepository.Insert(note);

        }

        void CheckTitleContent(Note note)
        {
            if (string.IsNullOrWhiteSpace(note.Content) || string.IsNullOrWhiteSpace(note.Title))
                throw new Exception("Title ve/veya Content bilgisi eksik");
        }

        public bool Update(Note note)
        {
            CheckTitleContent(note);
            if (note.ID == 0) throw new Exception("Not güncelleme için ID mutlaka atanmalıdır");
            return _noteRepository.Update(note);
        }

        public bool Delete(int id)
        {
            CheckNoteId(id);
            Note note = GetByNoteId(id);
            return _noteRepository.Delete(note);
        }

        public bool Delete(Note note)
        {
            CheckNoteId(note.ID);
            return _noteRepository.Delete(note);
        }
    }
}
