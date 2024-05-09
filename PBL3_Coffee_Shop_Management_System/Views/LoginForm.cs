using PBL3_Coffee_Shop_Management_System.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3_Coffee_Shop_Management_System.Views
{
    public partial class LoginForm : Form
    {
        private int _Authentication = 0;
        public int Authentication { get { return _Authentication; } private set { } }
        public LoginForm()
        {
            InitializeComponent();
        }
        private int checkAuth(string ID)
        {
            if (ID[0] == 'M') return 1;
            else if (ID[0] == 'E') return 2;
            return 0;
        }
        internal UserAccountDTO GetUserAccount()
        {
            return UserAccountDTO.Instance.list.Find(x => x.UserName == textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu", "Empty Field");
                return;
            }
            foreach (UserAccountDTO u in UserAccountDTO.Instance.list)
            {
                if (textBox1.Text == u.UserName)
                {
                    if (textBox2.Text == u.Password)
                    {
                        Authentication = checkAuth(u.ID);
                        return;
                    }
                    else
                    {
                        DialogResult = DialogResult.None;
                        MessageBox.Show("Sai mật khẩu", "Wrong password");
                    }
                    return;
                }
            }
            DialogResult = DialogResult.None;
            MessageBox.Show("Tài khoản không tồn tại", "Account not found");
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
