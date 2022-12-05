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
    public partial class frmAdmin : Form
    {
        UserService _userService;
        List<User> _passiveUsers;
        public frmAdmin()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            _passiveUsers = _userService.GetPassiveUsers();
            FillListView();

            //Fake user ekleme komutları sadce 1 kez çalıştırılıp yoruma alındı tekrardan oluşmasın diye
            //ICollection<Password> sifreler= new List<Password>();
            //sifreler.Add(new Password
            //{
            //    Text = "1234",
            //    UserID = 5,
            //    CreatedDate = DateTime.Now,
            //});
            //_userService.Insert(new User
            //{
            //    ID = 5,
            //    UserType = Model.Enum.UserType.Standart,
            //    FirstName = "Furkan",
            //    LastName = "Demir",
            //    UserName = "furkan",
            //    Passwords = sifreler,
            //    IsActive = false,
            //    CreatedDate = DateTime.Now                
            //});

        }

        void FillListView()
        {
            lvUsers.Items.Clear();
            ListViewItem lvi;

            foreach (User user in _passiveUsers)
            {
                lvi = new ListViewItem();
                lvi.Text = user.FirstName;
                lvi.SubItems.Add(user.LastName);
                lvi.SubItems.Add(user.UserName);
                lvi.SubItems.Add(user.IsActive ? "Aktif" : "Pasif");
                lvi.Tag = user.ID;
                lvUsers.Items.Add(lvi);
            }
        }

        private void lvUsers_DoubleClick(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(lvUsers.SelectedItems[0].Tag);

            try
            {
                _userService.UserActivated(userId);
                FillListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
