using System;
using System.Windows.Forms;

namespace Project_UAS_Pemrograman_Framework.NET
{
    public partial class FormPegawai : Form
    {
        public FormPegawai()
        {
            InitializeComponent();
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

        private void buttonUpdateBarang_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogoutInsertBarang_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }

        private void buttonLogoutUpdateDanHapusBarang_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }

        private void buttonLogoutInsertBarangMasuk_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }

        private void buttonLogoutUpdateDanHapusBarangMasuk_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }

        private void buttonLogoutInsertBarangKeluar_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }

        private void buttonLogoutUpdateDanHapusBarangKeluar_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }

        private void isiDataGridInsertBarang()
        {
            this.dataGridInsertBarang.Rows.Clear();

            this.dataGridInsertBarang.Rows.Add(1, "Shampo", 50, "Shampo merek Rejoice");
            this.dataGridInsertBarang.Rows.Add(2, "Indomie Goreng Jumbo", 140, "Mie goreng berkualitas");
            this.dataGridInsertBarang.Rows.Add(3, "Beras Merah", 230, "Beras merah impor");
        }

        private void isiDataGridUpdateDanHapusBarang()
        {
            this.dataGridUpdateDanHapusBarang.Rows.Clear();

            this.dataGridUpdateDanHapusBarang.Rows.Add(1, "Shampo", 50, "Shampo merek Rejoice");
            this.dataGridUpdateDanHapusBarang.Rows.Add(2, "Indomie Goreng Jumbo", 140, "Mie goreng berkualitas");
            this.dataGridUpdateDanHapusBarang.Rows.Add(3, "Beras Merah", 230, "Beras merah impor");
        }

        private void isiDataGridInsertBarangMasuk()
        {
            this.dataGridInsertBarangMasuk.Rows.Clear();

            this.dataGridInsertBarangMasuk.Rows.Add(1, 1, 1, "Shampo", "21 Januari 2021", 4);
            this.dataGridInsertBarangMasuk.Rows.Add(1, 1, 3, "Beras Merah", "26 Januari 2021", 6);
            this.dataGridInsertBarangMasuk.Rows.Add(1, 1, 2, "Indomie Goreng", "21 Februari 2021", 12);
        }

        private void isiDataGridUpdateDanHapusBarangMasuk()
        {
            this.dataGridUpdateDanHapusBarangMasuk.Rows.Clear();

            this.dataGridUpdateDanHapusBarangMasuk.Rows.Add(1, 1, 1, "Shampo", "21 Januari 2021", 4);
            this.dataGridUpdateDanHapusBarangMasuk.Rows.Add(1, 1, 3, "Beras Merah", "26 Januari 2021", 6);
            this.dataGridUpdateDanHapusBarangMasuk.Rows.Add(1, 1, 2, "Indomie Goreng", "21 Februari 2021", 12);
        }

        private void isiDataGridInsertBarangKeluar()
        {
            this.dataGridInsertBarangKeluar.Rows.Clear();

            this.dataGridInsertBarangKeluar.Rows.Add(1, 1, 1, "Shampo", "22 Januari 2021", 2);
            this.dataGridInsertBarangKeluar.Rows.Add(1, 1, 3, "Beras Merah", "27 Januari 2021", 4);
            this.dataGridInsertBarangKeluar.Rows.Add(1, 1, 2, "Indomie Goreng", "22 Februari 2021", 8);
        }

        private void isiDataGridUpdateDanHapusBarangKeluar()
        {
            this.dataGridUpdateDanHapusBarangKeluar.Rows.Clear();

            this.dataGridUpdateDanHapusBarangKeluar.Rows.Add(1, 1, 1, "Shampo", "22 Januari 2021", 2);
            this.dataGridUpdateDanHapusBarangKeluar.Rows.Add(1, 1, 3, "Beras Merah", "27 Januari 2021", 4);
            this.dataGridUpdateDanHapusBarangKeluar.Rows.Add(1, 1, 2, "Indomie Goreng", "22 Februari 2021", 8);
        }
    }
}
