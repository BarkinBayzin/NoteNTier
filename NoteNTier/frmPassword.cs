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
    public partial class frmPassword : Form
    {
        PasswordService _passwordService;
        User user;
        public frmPassword(User _user)
        {
            InitializeComponent();
           _passwordService = new PasswordService();
            user = _user;
        }

        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            try
            {
                Password activePassword = _passwordService.GetActivePassword(user.ID);
                if (activePassword.Text != txtEskiSifre.Text)
                {
                    MessageBox.Show("Mevcut şifrenizi hatalı girdiniz..!");
                    return;
                }

                if (txtyeniSifre.Text != txtYeniSifreTekrar.Text)
                {
                    MessageBox.Show("Şifreler uyuşmuyor..!");
                    return;
                }

                bool check = _passwordService.Insert(new Password()
                {
                    Text = txtyeniSifre.Text,
                    UserID = user.ID
                });

                MessageBox.Show(check ? "Şifre Değiştirildi.." : "Şifre Değiştirilemedi..!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
