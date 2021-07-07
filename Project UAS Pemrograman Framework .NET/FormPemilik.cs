using System;
using System.Windows.Forms;

namespace Project_UAS_Pemrograman_Framework.NET
{
    public partial class FormPemilik : Form
    {
        private UserDb userDb;
        private PegawaiDb pegawaiDb;
        private BarangDb barangDb;
        private TransaksiDb transaksiDb;

        public FormPemilik()
        {
            InitializeComponent();
            this.userDb = new UserDb();
            this.pegawaiDb = new PegawaiDb();
            this.barangDb = new BarangDb();
            this.transaksiDb = new TransaksiDb();
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
            if (!String.IsNullOrEmpty(this.textNamaInsert.Text) &&
                !String.IsNullOrEmpty(this.textAlamatInsert.Text) &&
                !String.IsNullOrEmpty(this.textEmailInsert.Text) &&
                !String.IsNullOrEmpty(this.textNomorTeleponInsert.Text))
            {
                string nama = this.textNamaInsert.Text;
                string alamat = this.textAlamatInsert.Text;
                string jenisKelamin = this.radioButtonPriaInsert.Checked ?
                    this.radioButtonPriaInsert.Text : this.radioButtonWanitaInsert.Text;
                string email = this.textEmailInsert.Text;
                string nomorTelepon = this.textNomorTeleponInsert.Text;

                DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin untuk insert data?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (konfirmasi == DialogResult.Yes)
                {
                    this.userDb.insertUser(nama, "pegawai123", "Pegawai");
                    int idUser = this.userDb.getIdUserDenganUsername(nama);
                    this.pegawaiDb.insertPegawai(idUser, nama, alamat, jenisKelamin, email, nomorTelepon, "Aktif");
                    this.isiDataGridPegawaiInsert();
                    this.isiDataGridPegawaiUpdateDanHapus();
                    MessageBox.Show("Insert data berhasil!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Masukkan semua kolom isian!", "Update Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonLogoutInsert_Click(object sender, EventArgs e)
        {
            this.logout();
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
            if (!String.IsNullOrEmpty(this.textIdPegawaiUpdate.Text) &&
                !String.IsNullOrEmpty(this.textNamaUpdate.Text) &&
                !String.IsNullOrEmpty(this.textAlamatUpdate.Text) &&
                !String.IsNullOrEmpty(this.textEmailUpdate.Text) &&
                !String.IsNullOrEmpty(this.textNomorTeleponUpdate.Text))
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
            else
            {
                MessageBox.Show("Masukkan semua kolom isian!", "Update Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void buttonLogoutUpdate_Click(object sender, EventArgs e)
        {
            this.logout();
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

        //
        // Event tab control lihat barang
        //
        private void buttonLogoutLihatBarang_Click(object sender, EventArgs e)
        {
            this.logout();
        }

        private void isiDataGridLihatBarang()
        {
            this.dataGridLihatBarang.Rows.Clear();

            foreach (Barang barang in this.barangDb.getAllBarangAktif())
            {
                this.dataGridLihatBarang.Rows.Add(barang.getIdBarang(), barang.getNama(),
                    barang.getStok(), barang.getDeskripsi());
            }
        }

        //
        // Event tab control barang masuk
        //
        private void buttonLogoutLihatBarangMasuk_Click(object sender, EventArgs e)
        {
            this.logout();
        }

        private void isiDataGridLihatBarangMasuk()
        {
            this.dataGridLihatBarangMasuk.Rows.Clear();

            foreach (Transaksi transaksi in this.transaksiDb.getAllBarangMasuk())
            {
                this.dataGridLihatBarangMasuk.Rows.Add(transaksi.getIdTransaksi(), 
                    transaksi.getPegawai().getIdPegawai(),transaksi.getBarang().getIdBarang(), 
                    transaksi.getBarang().getNama(), transaksi.getTanggal().Date.ToString("dd - MM - yyyy"), 
                    transaksi.getQuantity());
            }
        }

        //
        // Event tab control barang keluar
        //
        private void buttonLogoutLihatBarangKeluar_Click(object sender, EventArgs e)
        {
            this.logout();
        }

        private void isiDataGridLihatBarangKeluar()
        {
            this.dataGridLihatBarangKeluar.Rows.Clear();

            foreach (Transaksi transaksi in this.transaksiDb.getAllBarangKeluar())
            {
                this.dataGridLihatBarangKeluar.Rows.Add(transaksi.getIdTransaksi(),
                    transaksi.getPegawai().getIdPegawai(), transaksi.getBarang().getIdBarang(),
                    transaksi.getBarang().getNama(), transaksi.getTanggal().Date.ToString("dd - MM - yyyy"),
                    transaksi.getQuantity());
            }
        }

        private void logout()
        {
            Session.resetLoggedInUsername();
            new FormLogin().Show();
            this.Hide();
        }
    }
}
