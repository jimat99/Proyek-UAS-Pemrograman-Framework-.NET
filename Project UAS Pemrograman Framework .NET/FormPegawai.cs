using System;
using System.Windows.Forms;

namespace Project_UAS_Pemrograman_Framework.NET
{
    public partial class FormPegawai : Form
    {
        private PegawaiDb pegawaiDb;
        private BarangDb barangDb;
        private TransaksiDb transaksiDb;

        public FormPegawai()
        {
            InitializeComponent();
            this.pegawaiDb = new PegawaiDb();
            this.barangDb = new BarangDb();
            this.transaksiDb = new TransaksiDb();
            this.isiDataGridInsertBarang();
            this.isiDataGridUpdateDanHapusBarang();
            this.isiDataGridInsertBarangMasuk();
            this.isiDataGridUpdateDanHapusBarangMasuk();
            this.isiDataGridInsertBarangKeluar();
            this.isiDataGridUpdateDanHapusBarangKeluar();
        }

        private void FormPegawai_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //
        // Event tab control insert barang
        //
        private void buttonInsertBarang_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textNamaInsertBarang.Text) &&
                !String.IsNullOrEmpty(this.textDeskripsiInsertBarang.Text))
            {
                DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin untuk insert data?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (konfirmasi == DialogResult.Yes)
                {
                    string nama = this.textNamaInsertBarang.Text;
                    int stok = Convert.ToInt32(this.numericStokInsertBarang.Text);
                    string deskripsi = this.textDeskripsiInsertBarang.Text;

                    this.barangDb.insertBarang(nama, stok, deskripsi);
                    this.isiDataGridInsertBarang();
                    this.isiDataGridUpdateDanHapusBarang();
                    MessageBox.Show("Insert barang berhasil!", "Insert Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Masukkan semua kolom isian!", "Insert Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonLogoutInsertBarang_Click(object sender, EventArgs e)
        {
            this.logout();
        }

        private void isiDataGridInsertBarang()
        {
            this.dataGridInsertBarang.Rows.Clear();

            foreach (Barang barang in this.barangDb.getAllBarangAktif())
            {
                this.dataGridInsertBarang.Rows.Add(barang.getIdBarang(), barang.getNama(), 
                    barang.getStok(), barang.getDeskripsi());
            }
        }

        //
        // Event tab control update dan hapus barang
        //
        private void buttonUpdateBarang_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textIdBarangUpdateDanHapus.Text) &&
                !String.IsNullOrEmpty(this.textNamaUpdateDanHapusBarang.Text) &&
                !String.IsNullOrEmpty(this.textDeskripsiUpdateDanHapusBarang.Text))
            {
                DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin untuk mengupdate data?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (konfirmasi == DialogResult.Yes)
                {
                    int idBarang = Convert.ToInt32(this.textIdBarangUpdateDanHapus.Text);
                    string nama = this.textNamaUpdateDanHapusBarang.Text;
                    int stok = Convert.ToInt32(this.numericStokUpdateDanHapusBarang.Text);
                    string deskripsi = this.textDeskripsiUpdateDanHapusBarang.Text;

                    this.barangDb.updateBarang(idBarang, nama, stok, deskripsi);
                    this.isiDataGridUpdateDanHapusBarang();
                    this.isiDataGridInsertBarang();
                    MessageBox.Show("Update barang berhasil!", "Update Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Masukkan semua kolom isian!", "Update Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonHapusBarang_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textIdBarangUpdateDanHapus.Text))
            {
                DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin untuk menghapus barang?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (konfirmasi == DialogResult.Yes)
                {
                    int idBarang = Convert.ToInt32(this.textIdBarangUpdateDanHapus.Text);
                    this.barangDb.hapusBarangDenganId(idBarang);
                    this.isiDataGridUpdateDanHapusBarang();
                    this.isiDataGridInsertBarang();
                }
            }
            else
            {
                MessageBox.Show("Masukkan ID barang yang ingin dihapus!", "Hapus Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonLogoutUpdateDanHapusBarang_Click(object sender, EventArgs e)
        {
            this.logout();
        }

        private void dataGridUpdateDanHapusBarang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.textIdBarangUpdateDanHapus.Text = Convert.ToString(
                    this.dataGridUpdateDanHapusBarang[0, e.RowIndex].Value);
                this.textNamaUpdateDanHapusBarang.Text = Convert.ToString(
                    this.dataGridUpdateDanHapusBarang[1, e.RowIndex].Value);
                this.numericStokUpdateDanHapusBarang.Text = Convert.ToString(
                    this.dataGridUpdateDanHapusBarang[2, e.RowIndex].Value);
                this.textDeskripsiUpdateDanHapusBarang.Text = Convert.ToString(
                    this.dataGridUpdateDanHapusBarang[3, e.RowIndex].Value);
            }
        }

        private void isiDataGridUpdateDanHapusBarang()
        {
            this.dataGridUpdateDanHapusBarang.Rows.Clear();

            foreach (Barang barang in this.barangDb.getAllBarangAktif())
            {
                this.dataGridUpdateDanHapusBarang.Rows.Add(barang.getIdBarang(), barang.getNama(),
                    barang.getStok(), barang.getDeskripsi());
            }
        }

        //
        // Event tab control insert barang masuk
        //
        private void buttonInsertBarangMasuk_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textIdBarangInsertBarangMasuk.Text) &&
                Convert.ToInt32(numericQuantityInsertBarangMasuk.Text) > 0)
            {
                DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin untuk insert data?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (konfirmasi == DialogResult.Yes)
                {
                    string username = Session.getLoggedInUsername();
                    int idPegawai = this.pegawaiDb.getIdPegawaiDenganUsername(username);
                    int idBarang = Convert.ToInt32(this.textIdBarangInsertBarangMasuk.Text);
                    string tanggal = dateTimePickerInsertBarangMasuk.Value.Date.ToString("dd/MM/yyyy");
                    int quantity = Convert.ToInt32(this.numericQuantityInsertBarangMasuk.Text);

                    if (this.barangDb.temukanBarangDenganId(idBarang))
                    {
                        this.transaksiDb.insertBarangMasuk(idPegawai, idBarang, tanggal, quantity);
                        this.barangDb.tambahkanStok(idBarang, quantity);
                        this.isiDataGridInsertBarangMasuk();
                        this.isiDataGridUpdateDanHapusBarangMasuk();
                        this.isiDataGridInsertBarang();
                        this.isiDataGridUpdateDanHapusBarang();
                        MessageBox.Show("Insert barang masuk berhasil!", "Insert Berhasil",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Barang dengan ID " + idBarang + " tidak ditemukan!", "Insert Gagal",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Masukkan semua kolom isian!", "Insert Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonLogoutInsertBarangMasuk_Click(object sender, EventArgs e)
        {
            this.logout();
        }

        private void isiDataGridInsertBarangMasuk()
        {
            this.dataGridInsertBarangMasuk.Rows.Clear();
            
            foreach (Transaksi transaksi in this.transaksiDb.getAllBarangMasuk())
            {
                this.dataGridInsertBarangMasuk.Rows.Add(transaksi.getIdTransaksi(),
                    transaksi.getPegawai().getIdPegawai(), transaksi.getBarang().getIdBarang(),
                    transaksi.getBarang().getNama(), transaksi.getTanggal().Date.ToString("dd - MM - yyyy"),
                    transaksi.getQuantity());
            }
        }

        //
        // Event tab control update dan hapus barang masuk
        //
        private void buttonUpdateBarangMasuk_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textIdTransaksiUpdateDanHapusBarangMasuk.Text) &&
                !String.IsNullOrEmpty(this.textIdBarangUpdateDanHapusBarangMasuk.Text) &&
                Convert.ToInt32(this.numericQuantityUpdateDanHapusBarangMasuk.Text) > 0)
            {
                DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin untuk mengupdate data?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (konfirmasi == DialogResult.Yes)
                {
                    int idTransaksi = Convert.ToInt32(this.textIdTransaksiUpdateDanHapusBarangMasuk.Text);
                    int idBarang = Convert.ToInt32(this.textIdBarangUpdateDanHapusBarangMasuk.Text);
                    string tanggal = dateTimePickerUpdateDanHapusBarangMasuk.Value.Date.ToString("dd/MM/yyyy");
                    int quantity = Convert.ToInt32(this.numericQuantityUpdateDanHapusBarangMasuk.Text);

                    this.transaksiDb.updateTransaksi(idTransaksi, idBarang, tanggal, quantity);
                    this.isiDataGridUpdateDanHapusBarangMasuk();
                    this.isiDataGridInsertBarangMasuk();
                    MessageBox.Show("Update barang masuk berhasil!", "Update Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Masukkan semua kolom isian!", "Update Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonHapusBarangMasuk_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textIdTransaksiUpdateDanHapusBarangMasuk.Text))
            {
                DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin untuk menghapus barang masuk?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (konfirmasi == DialogResult.Yes)
                {
                    int idTransaksi = Convert.ToInt32(this.textIdTransaksiUpdateDanHapusBarangMasuk.Text);
                    this.transaksiDb.hapusTransaksiDenganId(idTransaksi);
                    this.isiDataGridUpdateDanHapusBarangMasuk();
                    this.isiDataGridInsertBarangMasuk();
                }
            }
            else
            {
                MessageBox.Show("Masukkan ID transaksi yang ingin dihapus!", "Hapus Gagal",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonLogoutUpdateDanHapusBarangMasuk_Click(object sender, EventArgs e)
        {
            this.logout();
        }

        private void dataGridUpdateDanHapusBarangMasuk_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.textIdTransaksiUpdateDanHapusBarangMasuk.Text = Convert.ToString(
                    this.dataGridUpdateDanHapusBarangMasuk[0, e.RowIndex].Value);
                this.textIdBarangUpdateDanHapusBarangMasuk.Text = Convert.ToString(
                    this.dataGridUpdateDanHapusBarangMasuk[2, e.RowIndex].Value);
                this.dateTimePickerUpdateDanHapusBarangMasuk.Text = Convert.ToString(
                    this.dataGridUpdateDanHapusBarangMasuk[4, e.RowIndex].Value);
                this.numericQuantityUpdateDanHapusBarangMasuk.Text = Convert.ToString(
                    this.dataGridUpdateDanHapusBarangMasuk[5, e.RowIndex].Value);
            }
        }

        private void isiDataGridUpdateDanHapusBarangMasuk()
        {
            this.dataGridUpdateDanHapusBarangMasuk.Rows.Clear();

            foreach (Transaksi transaksi in this.transaksiDb.getAllBarangMasuk())
            {
                this.dataGridUpdateDanHapusBarangMasuk.Rows.Add(transaksi.getIdTransaksi(),
                    transaksi.getPegawai().getIdPegawai(), transaksi.getBarang().getIdBarang(),
                    transaksi.getBarang().getNama(), transaksi.getTanggal().Date.ToString("dd - MM - yyyy"),
                    transaksi.getQuantity());
            }
        }

        //
        // Event tab control insert barang keluar
        //
        private void buttonInsertBarangKeluar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textIdBarangInsertBarangKeluar.Text) &&
                Convert.ToInt32(numericQuantityInsertBarangKeluar.Text) > 0)
            {
                DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin untuk insert data?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (konfirmasi == DialogResult.Yes)
                {
                    string username = Session.getLoggedInUsername();
                    int idPegawai = this.pegawaiDb.getIdPegawaiDenganUsername(username);
                    int idBarang = Convert.ToInt32(this.textIdBarangInsertBarangKeluar.Text);
                    string tanggal = dateTimePickerInsertBarangKeluar.Value.Date.ToString("dd/MM/yyyy");
                    int quantity = Convert.ToInt32(this.numericQuantityInsertBarangKeluar.Text);

                    if (this.barangDb.temukanBarangDenganId(idBarang))
                    {
                        this.transaksiDb.insertBarangKeluar(idPegawai, idBarang, tanggal, quantity);
                        this.barangDb.kurangiStok(idBarang, quantity);
                        this.isiDataGridInsertBarangKeluar();
                        this.isiDataGridUpdateDanHapusBarangKeluar();
                        this.isiDataGridInsertBarang();
                        this.isiDataGridUpdateDanHapusBarang();
                        MessageBox.Show("Insert barang keluar berhasil!", "Insert Berhasil",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Barang dengan ID " + idBarang + " tidak ditemukan!", "Insert Gagal",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Masukkan semua kolom isian!", "Insert Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonLogoutInsertBarangKeluar_Click(object sender, EventArgs e)
        {
            this.logout();
        }

        private void isiDataGridInsertBarangKeluar()
        {
            this.dataGridInsertBarangKeluar.Rows.Clear();

            foreach (Transaksi transaksi in this.transaksiDb.getAllBarangKeluar())
            {
                this.dataGridInsertBarangKeluar.Rows.Add(transaksi.getIdTransaksi(),
                    transaksi.getPegawai().getIdPegawai(), transaksi.getBarang().getIdBarang(),
                    transaksi.getBarang().getNama(), transaksi.getTanggal().Date.ToString("dd - MM - yyyy"),
                    transaksi.getQuantity());
            }
        }

        //
        // Event tab control update dan hapus barang keluar
        //
        private void buttonUpdateBarangKeluar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textIdTransaksiUpdateDanHapusBarangKeluar.Text) &&
                !String.IsNullOrEmpty(this.textIdBarangUpdateDanHapusBarangKeluar.Text) &&
                Convert.ToInt32(this.numericQuantityUpdateDanHapusBarangKeluar.Text) > 0)
            {
                DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin untuk mengupdate data?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (konfirmasi == DialogResult.Yes)
                {
                    int idTransaksi = Convert.ToInt32(this.textIdTransaksiUpdateDanHapusBarangKeluar.Text);
                    int idBarang = Convert.ToInt32(this.textIdBarangUpdateDanHapusBarangKeluar.Text);
                    string tanggal = dateTimePickerUpdateDanHapusBarangKeluar.Value.Date.ToString("dd/MM/yyyy");
                    int quantity = Convert.ToInt32(this.numericQuantityUpdateDanHapusBarangKeluar.Text);

                    this.transaksiDb.updateTransaksi(idTransaksi, idBarang, tanggal, quantity);
                    this.isiDataGridUpdateDanHapusBarangKeluar();
                    this.isiDataGridInsertBarangKeluar();
                    MessageBox.Show("Update barang masuk berhasil!", "Update Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Masukkan semua kolom isian!", "Update Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonHapusBarangKeluar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.textIdTransaksiUpdateDanHapusBarangKeluar.Text))
            {
                DialogResult konfirmasi = MessageBox.Show("Apakah Anda yakin untuk menghapus barang keluar?",
                    "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (konfirmasi == DialogResult.Yes)
                {
                    int idTransaksi = Convert.ToInt32(this.textIdTransaksiUpdateDanHapusBarangKeluar.Text);
                    this.transaksiDb.hapusTransaksiDenganId(idTransaksi);
                    this.isiDataGridUpdateDanHapusBarangKeluar();
                    this.isiDataGridInsertBarangKeluar();
                }
            }
            else
            {
                MessageBox.Show("Masukkan ID transaksi yang ingin dihapus!", "Hapus Gagal",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonLogoutUpdateDanHapusBarangKeluar_Click(object sender, EventArgs e)
        {
            this.logout();
        }

        private void dataGridUpdateDanHapusBarangKeluar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.textIdTransaksiUpdateDanHapusBarangKeluar.Text = Convert.ToString(
                    this.dataGridUpdateDanHapusBarangKeluar[0, e.RowIndex].Value);
                this.textIdBarangUpdateDanHapusBarangKeluar.Text = Convert.ToString(
                    this.dataGridUpdateDanHapusBarangKeluar[2, e.RowIndex].Value);
                this.dateTimePickerUpdateDanHapusBarangKeluar.Text = Convert.ToString(
                    this.dataGridUpdateDanHapusBarangKeluar[4, e.RowIndex].Value);
                this.numericQuantityUpdateDanHapusBarangKeluar.Text = Convert.ToString(
                    this.dataGridUpdateDanHapusBarangKeluar[5, e.RowIndex].Value);
            }
        }

        private void isiDataGridUpdateDanHapusBarangKeluar()
        {
            this.dataGridUpdateDanHapusBarangKeluar.Rows.Clear();

            foreach (Transaksi transaksi in this.transaksiDb.getAllBarangKeluar())
            {
                this.dataGridUpdateDanHapusBarangKeluar.Rows.Add(transaksi.getIdTransaksi(),
                    transaksi.getPegawai().getIdPegawai(), transaksi.getBarang().getIdBarang(),
                    transaksi.getBarang().getNama(), transaksi.getTanggal().Date.ToString("dd - MM - yyyy"),
                    transaksi.getQuantity());
            }
        }

        //
        // Event umum
        //
        private void logout()
        {
            Session.resetLoggedInUsername();
            new FormLogin().Show();
            this.Hide();
        }
    }
}
