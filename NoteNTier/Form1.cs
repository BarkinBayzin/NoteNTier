using NoteNTier.BLL.Services;
using NoteNTier.Model.Entities;
using NoteNTier.Model.Enum;
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
    public partial class Form1 : Form
    {
        UserService _userService;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            string userName = txtKullaniciAdi.Text;
            string password = txtSifre.Text;
            try
            {
                _userService = new UserService();
                User user = _userService.CheckLogin(userName, password);
                if (user != null)
                {
                    if(!user.IsActive)
                    {
                        MessageBox.Show("Admin bu kullanıcıyı onaylamamış");
                        return;
                    }

                    switch (user.UserType)
                    {
                        case UserType.Admin:
                            frmAdmin frmAdmin = new frmAdmin();
                            this.Hide();
                            frmAdmin.ShowDialog();
                            this.Show();
                            break;
                        case UserType.Standart:
                            frmMain frmMain = new frmMain();
                            this.Hide();
                            frmMain.ShowDialog();
                            this.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bilgileri kontrol edin. Eğer üye değil iseniz kayıt olun");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLblKayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister registerForm = new frmRegister();
            this.Hide();
            registerForm.ShowDialog();
            this.Show();
        }
    }
}
