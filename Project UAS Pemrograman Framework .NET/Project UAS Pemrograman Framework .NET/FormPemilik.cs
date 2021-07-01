using System;
using System.Windows.Forms;

namespace Project_UAS_Pemrograman_Framework.NET
{
    public partial class FormPemilik : Form
    {
        private PegawaiDb pegawaiDb;
        private UserDb userDb;

        public FormPemilik()
        {
            InitializeComponent();
            pegawaiDb = new PegawaiDb();
            userDb = new UserDb();
            this.isiDataGridPegawaiInsert();
            this.isiDataGridPegawaiUpdateDanHapus();
            this.isiDataGridLihatBarang();
            this.isiDataGridLihatBarangMasuk();
            this.isiDataGridLihatBarangKeluar();
        }

        private void FormPemilik_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //
        // Event tab control insert
        //
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string nama = this.textNamaInsert.Text;
            string alamat = this.textAlamatInsert.Text;
            string jenisKelamin = this.radioButtonPriaInsert.Checked ?
                this.radioButtonPriaInsert.Text : this.radioButtonWanitaInsert.Text;
            string email = this.textEmailInsert.Text;
            string nomorTelepon = this.textNomorTeleponInsert.Text;
            string statusAktif = "Aktif";

            DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin untuk menginsert data?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (konfirmasi == DialogResult.Yes)
            {
                this.userDb.insertUser(nama, "pegawai123", "Pegawai");
                int idUser = this.userDb.getIdUserDenganUsername(nama);
                this.pegawaiDb.insertPegawai(idUser, nama, alamat, jenisKelamin, email, nomorTelepon, statusAktif);
                this.isiDataGridPegawaiInsert();
                this.isiDataGridPegawaiUpdateDanHapus();
                MessageBox.Show("Insert data berhasil!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridPegawaiInsert_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.textNamaInsert.Text = Convert.ToString(this.dataGridPegawaiInsert[1, e.RowIndex].Value);
                this.textAlamatInsert.Text = Convert.ToString(dataGridPegawaiInsert[2, e.RowIndex].Value);
                if (Convert.ToString(this.dataGridPegawaiInsert[3, e.RowIndex].Value) == radioButtonPriaInsert.Text)
                {
                    this.radioButtonPriaInsert.Checked = true;
                }
                else
                {
                    this.radioButtonWanitaInsert.Checked = true;
                }
                this.textEmailInsert.Text = Convert.ToString(dataGridPegawaiInsert[4, e.RowIndex].Value);
                this.textNomorTeleponInsert.Text = Convert.ToString(dataGridPegawaiInsert[5, e.RowIndex].Value);
            }
        }

        private void isiDataGridPegawaiInsert()
        {
            this.dataGridPegawaiInsert.Rows.Clear();

            foreach (Pegawai pegawai in this.pegawaiDb.getAllPegawai())
            {
                this.dataGridPegawaiInsert.Rows.Add(pegawai.getIdPegawai(), pegawai.getNama(), pegawai.getAlamat(),
                    pegawai.getJenisKelamin(), pegawai.getEmail(), pegawai.getNomorTelepon(),
                    pegawai.getStatusAktif());
            }
        }

        // 
        // Event tab control update dan hapus
        //
        private void buttonUpdatePegawai_Click(object sender, EventArgs e)
        {
            int idPegawai = Convert.ToInt32(this.textIdPegawaiUpdate.Text);
            string nama = this.textNamaUpdate.Text;
            string alamat = this.textAlamatUpdate.Text;
            string jenisKelamin = this.radioButtonPriaUpdate.Checked ?
                this.radioButtonPriaUpdate.Text : this.radioButtonWanitaUpdate.Text;
            string email = this.textEmailUpdate.Text;
            string nomorTelepon = this.textNomorTeleponUpdate.Text;
            string statusAktif = this.radioButtonAktifUpdate.Checked ?
                this.radioButtonAktifUpdate.Text : this.radioButtonTidakAktifUpdate.Text;
            this.pegawaiDb.updatePegawai(idPegawai, nama, alamat, jenisKelamin, email, nomorTelepon, statusAktif);
            this.isiDataGridPegawaiUpdateDanHapus();
            this.isiDataGridPegawaiInsert();
            MessageBox.Show("Update data pegawai berhasil!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //private void buttonHapusPegawai_Click(object sender, EventArgs e)
        //{
        //    int idPegawai = Convert.ToInt32(this.textIdPegawaiUpdateDanHapus.Text);
        //    this.pegawaiDb.hapusPegawaiDenganId(idPegawai);
        //    this.isiDataGridPegawaiUpdateDanHapus();
        //    this.isiDataGridPegawaiInsert();
        //    MessageBox.Show("Data pegawai berhasil dihapus!", "Info", 
        //        MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        private void buttonRefreshTabel_Click(object sender, EventArgs e)
        {
            this.isiDataGridPegawaiUpdateDanHapus();
        }

        private void dataGridPegawaiUpdateDanHapus_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.textIdPegawaiUpdate.Text = Convert.ToString(
                    dataGridPegawaiUpdate[0, e.RowIndex].Value);
                this.textNamaUpdate.Text = Convert.ToString(
                    this.dataGridPegawaiUpdate[1, e.RowIndex].Value);
                this.textAlamatUpdate.Text = Convert.ToString(
                    dataGridPegawaiUpdate[2, e.RowIndex].Value);
                if (Convert.ToString(this.dataGridPegawaiUpdate[3, e.RowIndex].Value) ==
                    radioButtonPriaUpdate.Text)
                {
                    this.radioButtonPriaUpdate.Checked = true;
                }
                else
                {
                    this.radioButtonWanitaUpdate.Checked = true;
                }
                this.textEmailUpdate.Text = Convert.ToString(
                    dataGridPegawaiUpdate[4, e.RowIndex].Value);
                this.textNomorTeleponUpdate.Text = Convert.ToString(
                    dataGridPegawaiUpdate[5, e.RowIndex].Value);
                if (Convert.ToString(this.dataGridPegawaiUpdate[6, e.RowIndex].Value) == radioButtonAktifUpdate.Text)
                {
                    this.radioButtonAktifUpdate.Checked = true;
                }
                else
                {
                    this.radioButtonTidakAktifUpdate.Checked = true;
                }
            }
        }

        private void isiDataGridPegawaiUpdateDanHapus()
        {
            this.dataGridPegawaiUpdate.Rows.Clear();

            foreach (Pegawai pegawai in this.pegawaiDb.getAllPegawai())
            {
                this.dataGridPegawaiUpdate.Rows.Add(pegawai.getIdPegawai(), pegawai.getNama(),
                    pegawai.getAlamat(), pegawai.getJenisKelamin(), pegawai.getEmail(),
                    pegawai.getNomorTelepon(), pegawai.getStatusAktif());
            }
        }

        private void isiDataGridLihatBarang()
        {
            this.dataGridLihatBarang.Rows.Clear();

            this.dataGridLihatBarang.Rows.Add(1, "Shampo", 50, "Shampo merek Rejoice");
            this.dataGridLihatBarang.Rows.Add(2, "Indomie Goreng Jumbo", 140, "Mie goreng berkualitas");
            this.dataGridLihatBarang.Rows.Add(3, "Beras Merah", 230, "Beras merah impor");
        }

        private void isiDataGridLihatBarangMasuk()
        {
            this.dataGridLihatBarangMasuk.Rows.Clear();

            this.dataGridLihatBarangMasuk.Rows.Add(1, 1, 1, "Shampo", "21 Januari 2021", 4);
            this.dataGridLihatBarangMasuk.Rows.Add(1, 1, 3, "Beras Merah", "26 Januari 2021", 6);
            this.dataGridLihatBarangMasuk.Rows.Add(1, 1, 2, "Indomie Goreng", "21 Februari 2021", 12);
        }

        private void isiDataGridLihatBarangKeluar()
        {
            this.dataGridLihatBarangKeluar.Rows.Clear();

            this.dataGridLihatBarangKeluar.Rows.Add(1, 1, 1, "Shampo", "22 Januari 2021", 2);
            this.dataGridLihatBarangKeluar.Rows.Add(1, 1, 3, "Beras Merah", "27 Januari 2021", 4);
            this.dataGridLihatBarangKeluar.Rows.Add(1, 1, 2, "Indomie Goreng", "22 Februari 2021", 8);
        }

        private void buttonLogoutInsert_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }

        private void buttonLogoutUpdate_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }

        private void buttonLogoutLihatBarang_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }

        private void buttonLogoutLihatBarangMasuk_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }
    }
}
