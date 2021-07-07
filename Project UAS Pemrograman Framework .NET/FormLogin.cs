using System;
using System.Windows.Forms;

namespace Project_UAS_Pemrograman_Framework.NET
{
    public partial class FormLogin : Form
    {
        private UserDb userDb;

        public FormLogin()
        {
            InitializeComponent();
            this.userDb = new UserDb();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textUsername.Text) &&
                !String.IsNullOrEmpty(this.textPassword.Text))
            {
                string username = this.textUsername.Text;
                string password = this.textPassword.Text;

                if (this.userDb.isDataLoginValid(username, password))
                {
                    if (this.userDb.getTipeDenganUsername(username) == "Pemilik")
                    {
                        this.loginPemilik(username);
                    }
                    else if (this.userDb.getTipeDenganUsername(username) == "Pegawai" &&
                        this.userDb.isUserPegawaiAktif(username))
                    {
                        this.loginPegawai(username);
                    }
                }
                else
                {
                    MessageBox.Show("Username atau password Anda salah!", "Login Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Masukkan username dan password Anda!", "Login Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void checkBoxTampilkanPassword_CheckedChanged(object sender, EventArgs e)
        {
            this.textPassword.PasswordChar = this.checkBoxTampilkanPassword.Checked ? '\0' : '*';
        }

        //
        // Event umum
        //
        private void loginPemilik(string username)
        {
            Session.setLoggedInUsername(username);
            new FormPemilik().Show();
            this.Hide();
        }

        private void loginPegawai(string username)
        {
            Session.setLoggedInUsername(username);
            new FormPegawai().Show();
            this.Hide();
        }
    }
}
