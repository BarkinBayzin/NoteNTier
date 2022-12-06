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
    public partial class frmRegister : Form
    {
        UserService _userService;
        public frmRegister()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSifre.Text != txtSifreTekrar.Text)
                {
                    MessageBox.Show("Şifreler uyuşmuyor..!");
                    return;
                }

                User user = new User();
                user.FirstName = txtAd.Text;
                user.LastName = txtSoyad.Text;
                user.UserName = txtKAdi.Text;

                user.Passwords.Add(new Password()
                {
                    Text = txtSifre.Text
                });

                bool check = _userService.Insert(user);
                MessageBox.Show(check ? "Kullanıcı Eklendi.." : "Kullanıcı eklenemedi..!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
