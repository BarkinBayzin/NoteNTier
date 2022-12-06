using NoteNTier.BLL.Services;
using NoteNTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteNTier
{
    public partial class frmMain : Form
    {
        NoteService _noteService;
        User user;
        public frmMain(User _user)
        {
            InitializeComponent();
            _noteService = new NoteService();
            user = _user;
        }
        void TextHide()
        {
            txtContent.Hide();
            txtTitle.Hide();
        }

        void TextShow()
        {
            txtContent.Show();
            txtTitle.Show();
        }

        void TextClear()
        {
            txtContent.Clear();
            txtTitle.Clear();
        }
        void FillNotes()
        {
            try
            {
                List<Note> notes = _noteService.GetById(user.ID);
                lstNotes.DataSource = notes;
                lstNotes.DisplayMember = "Title";
                lstNotes.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            TextHide();
            FillNotes();
        }


        private void btnNewNote_Click(object sender, EventArgs e)
        {
            lstNotes.SelectedIndex = -1;
            TextShow();
            TextClear();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            bool check;
            try
            {
                if (lstNotes.SelectedIndex == -1)//seçili not yok ise işlem insert
                {
                    check = _noteService.Insert(new Note()
                    {
                        Content = txtContent.Text,
                        Title = txtTitle.Text,
                        UserID = user.ID
                    });

                    MessageBox.Show(check ? "Ekleme Başarılı" : "Ekleme Başarısız");
                }
                else //update alanı
                {
                    int noteId = Convert.ToInt32(lstNotes.SelectedValue);

                    check = _noteService.Update(new Note()
                    {
                        ID = noteId,
                        Content = txtContent.Text,
                        Title = txtTitle.Text
                    });

                    MessageBox.Show(check ? "Güncelleme Başarılı" : "Güncelleme Başarısız");

                }
                TextClear();
                TextHide();
                FillNotes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void lstNotes_MouseClick(object sender, MouseEventArgs e)
        {
            TextShow();

            int noteID = Convert.ToInt32(lstNotes.SelectedValue);
            try
            {
                Note note = _noteService.GetByNoteId(noteID);
                txtContent.Text = note.Content;
                txtTitle.Text = note.Title;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void linkLblSifre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int noteID = Convert.ToInt32(lstNotes.SelectedValue);

            try
            {
               bool check =_noteService.Delete(noteID);
                MessageBox.Show(check ? "Silme işlemi başarılı" : "İşlem Başarısız..!");
                TextClear();
                TextHide();
                FillNotes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
