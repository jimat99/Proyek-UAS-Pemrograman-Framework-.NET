using System.Collections.Generic;
using System.Data.OleDb;

namespace Project_UAS_Pemrograman_Framework.NET
{
    class BarangDb
    {
        private Koneksi koneksi;

        public BarangDb()
        {
            this.koneksi = new Koneksi();
        }

        public List<Barang> getAllBarangAktif()
        {
            List<Barang> listBarang = new List<Barang>();
            string sql = "SELECT id_barang, nama, stok, deskripsi, status_aktif FROM [barang] " +
                "WHERE status_aktif = 'Aktif'";
            this.koneksi.openConnection();
            OleDbDataReader reader = this.koneksi.executeSelectQuery(sql);

            while (reader.Read())
            {
                Barang barang = new Barang();
                barang.setIdBarang(reader.GetInt32(reader.GetOrdinal("id_barang")));
                barang.setNama(reader.GetString(reader.GetOrdinal("nama")));
                barang.setStok(reader.GetInt32(reader.GetOrdinal("stok")));
                barang.setDeskripsi(reader.GetString(reader.GetOrdinal("deskripsi")));
                barang.setStatusAktif(reader.GetString(reader.GetOrdinal("status_aktif")));

                listBarang.Add(barang);
            }

            this.koneksi.closeConnection();
            return listBarang;
        }

        public bool temukanBarangDenganId(int idBarang)
        {
            string sql = "SELECT id_barang FROM [barang] " +
                "WHERE id_barang = " + idBarang;
            this.koneksi.openConnection();
            OleDbDataReader reader = this.koneksi.executeSelectQuery(sql);

            if (reader.HasRows)
            {
                this.koneksi.closeConnection();
                return true;
            }
            else
            {
                this.koneksi.closeConnection();
                return false;
            }
        }

        public void insertBarang(string nama, int stok, string deskripsi)
        {
            string sql = "INSERT INTO [barang](nama, stok, deskripsi, status_aktif) " +
                "VALUES ('" + nama + "', " + stok + ", '" + deskripsi + "', 'Aktif')";
            this.koneksi.openConnection();
            this.koneksi.executeNonSelectQuery(sql);
            this.koneksi.closeConnection();
        }

        public void updateBarang(int idBarang, string nama, int stok, string deskripsi)
        {
            string sql = "UPDATE [barang] " +
                "SET nama = '" + nama + "', stok = " + stok + ", deskripsi = '" + deskripsi + "' " +
                "WHERE id_barang = " + idBarang;
            this.koneksi.openConnection();
            this.koneksi.executeNonSelectQuery(sql);
            this.koneksi.closeConnection();
        }

        public void hapusBarangDenganId(int idBarang)
        {
            string sql = "UPDATE [barang] " +
                "SET status_aktif = 'Tidak aktif' " +
                "WHERE id_barang = " + idBarang;
            this.koneksi.openConnection();
            this.koneksi.executeNonSelectQuery(sql);
            this.koneksi.closeConnection();
        }

        public void tambahkanStok(int idBarang, int quantity)
        {
            string sql = "UPDATE [barang] " +
                "SET stok = stok + " + quantity + " " +
                "WHERE id_barang = " + idBarang;
            this.koneksi.openConnection();
            this.koneksi.executeNonSelectQuery(sql);
            this.koneksi.closeConnection();
        }

        public void kurangiStok(int idBarang, int quantity)
        {
            string sql = "UPDATE [barang] " +
                "SET stok = stok - " + quantity + " " +
                "WHERE id_barang = " + idBarang;
            this.koneksi.openConnection();
            this.koneksi.executeNonSelectQuery(sql);
            this.koneksi.closeConnection();
        }
    }
}
