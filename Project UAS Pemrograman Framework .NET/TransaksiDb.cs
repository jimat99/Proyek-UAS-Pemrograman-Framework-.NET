using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Project_UAS_Pemrograman_Framework.NET
{
    class TransaksiDb
    {
        private Koneksi koneksi;

        public TransaksiDb()
        {
            this.koneksi = new Koneksi();
        }

        public List<Transaksi> getAllBarangMasuk()
        {
            List<Transaksi> listTransaksi = new List<Transaksi>();
            string sql = "SELECT tipe_transaksi.id_tipe_transaksi, tipe_transaksi.nama, tipe_transaksi.keterangan, " +
                "user.id_user, user.username, user.password, user.tipe, " +
                "pegawai.id_pegawai, pegawai.nama, pegawai.alamat, " +
                "pegawai.jenis_kelamin, pegawai.email, pegawai.nomor_telepon, " +
                "pegawai.status_aktif, " +
                "barang.id_barang, barang.nama, barang.stok, " +
                "barang.deskripsi, barang.status_aktif, " +
                "transaksi.id_transaksi, transaksi.tanggal, transaksi.quantity " +
                "FROM ((([transaksi] " +
                "INNER JOIN [tipe_transaksi] " +
                "ON tipe_transaksi.id_tipe_transaksi = transaksi.id_tipe_transaksi) " +
                "INNER JOIN [pegawai] " +
                "ON pegawai.id_pegawai = transaksi.id_pegawai) " +
                "INNER JOIN [barang] " +
                "ON barang.id_barang = transaksi.id_barang) " +
                "INNER JOIN [user] " +
                "ON user.id_user = pegawai.id_user " +
                "WHERE transaksi.id_tipe_transaksi = 1";
            this.koneksi.openConnection();
            OleDbDataReader reader = this.koneksi.executeSelectQuery(sql);

            while (reader.Read())
            {
                TipeTransaksi tipeTransaksi = new TipeTransaksi();
                tipeTransaksi.setIdTipeTransaksi(reader.GetInt32(reader.GetOrdinal("id_tipe_transaksi")));
                tipeTransaksi.setNama(reader.GetString(reader.GetOrdinal("tipe_transaksi.nama")));
                tipeTransaksi.setKeterangan(reader.GetString(reader.GetOrdinal("keterangan")));

                User user = new User();
                user.setIdUser(reader.GetInt32(reader.GetOrdinal("id_user")));
                user.setUsername(reader.GetString(reader.GetOrdinal("username")));
                user.setPassword(reader.GetString(reader.GetOrdinal("password")));
                user.setTipe(reader.GetString(reader.GetOrdinal("tipe")));

                Pegawai pegawai = new Pegawai();
                pegawai.setIdPegawai(reader.GetInt32(reader.GetOrdinal("id_pegawai")));
                pegawai.setUser(user);
                pegawai.setNama(reader.GetString(reader.GetOrdinal("pegawai.nama")));
                pegawai.setAlamat(reader.GetString(reader.GetOrdinal("alamat")));
                pegawai.setJenisKelamin(reader.GetString(reader.GetOrdinal("jenis_kelamin")));
                pegawai.setEmail(reader.GetString(reader.GetOrdinal("email")));
                pegawai.setNomorTelepon(reader.GetString(reader.GetOrdinal("nomor_telepon")));
                pegawai.setStatusAktif(reader.GetString(reader.GetOrdinal("pegawai.status_aktif")));

                Barang barang = new Barang();
                barang.setIdBarang(reader.GetInt32(reader.GetOrdinal("id_barang")));
                barang.setNama(reader.GetString(reader.GetOrdinal("barang.nama")));
                barang.setStok(reader.GetInt32(reader.GetOrdinal("stok")));
                barang.setDeskripsi(reader.GetString(reader.GetOrdinal("deskripsi")));
                barang.setStatusAktif(reader.GetString(reader.GetOrdinal("barang.status_aktif")));

                Transaksi transaksi = new Transaksi();
                transaksi.setIdTransaksi(reader.GetInt32(reader.GetOrdinal("id_transaksi")));
                transaksi.setTipeTransaksi(tipeTransaksi);
                transaksi.setPegawai(pegawai);
                transaksi.setBarang(barang);
                transaksi.setTanggal(reader.GetDateTime(reader.GetOrdinal("tanggal")));
                transaksi.setQuantity(reader.GetInt32(reader.GetOrdinal("quantity")));

                listTransaksi.Add(transaksi);
            }

            this.koneksi.closeConnection();
            return listTransaksi;
        }

        public List<Transaksi> getAllBarangKeluar()
        {
            List<Transaksi> listTransaksi = new List<Transaksi>();
            string sql = "SELECT tipe_transaksi.id_tipe_transaksi, tipe_transaksi.nama, tipe_transaksi.keterangan, " +
                "user.id_user, user.username, user.password, user.tipe, " +
                "pegawai.id_pegawai, pegawai.nama, pegawai.alamat, " +
                "pegawai.jenis_kelamin, pegawai.email, pegawai.nomor_telepon, " +
                "pegawai.status_aktif, " +
                "barang.id_barang, barang.nama, barang.stok, " +
                "barang.deskripsi, barang.status_aktif, " +
                "transaksi.id_transaksi, transaksi.tanggal, transaksi.quantity " +
                "FROM ((([transaksi] " +
                "INNER JOIN [tipe_transaksi] " +
                "ON tipe_transaksi.id_tipe_transaksi = transaksi.id_tipe_transaksi) " +
                "INNER JOIN [pegawai] " +
                "ON pegawai.id_pegawai = transaksi.id_pegawai) " +
                "INNER JOIN [barang] " +
                "ON barang.id_barang = transaksi.id_barang) " +
                "INNER JOIN [user] " +
                "ON user.id_user = pegawai.id_user " +
                "WHERE transaksi.id_tipe_transaksi = 2";
            this.koneksi.openConnection();
            OleDbDataReader reader = this.koneksi.executeSelectQuery(sql);

            while (reader.Read())
            {
                TipeTransaksi tipeTransaksi = new TipeTransaksi();
                tipeTransaksi.setIdTipeTransaksi(reader.GetInt32(reader.GetOrdinal("id_tipe_transaksi")));
                tipeTransaksi.setNama(reader.GetString(reader.GetOrdinal("tipe_transaksi.nama")));
                tipeTransaksi.setKeterangan(reader.GetString(reader.GetOrdinal("keterangan")));

                User user = new User();
                user.setIdUser(reader.GetInt32(reader.GetOrdinal("id_user")));
                user.setUsername(reader.GetString(reader.GetOrdinal("username")));
                user.setPassword(reader.GetString(reader.GetOrdinal("password")));
                user.setTipe(reader.GetString(reader.GetOrdinal("tipe")));

                Pegawai pegawai = new Pegawai();
                pegawai.setIdPegawai(reader.GetInt32(reader.GetOrdinal("id_pegawai")));
                pegawai.setUser(user);
                pegawai.setNama(reader.GetString(reader.GetOrdinal("pegawai.nama")));
                pegawai.setAlamat(reader.GetString(reader.GetOrdinal("alamat")));
                pegawai.setJenisKelamin(reader.GetString(reader.GetOrdinal("jenis_kelamin")));
                pegawai.setEmail(reader.GetString(reader.GetOrdinal("email")));
                pegawai.setNomorTelepon(reader.GetString(reader.GetOrdinal("nomor_telepon")));
                pegawai.setStatusAktif(reader.GetString(reader.GetOrdinal("pegawai.status_aktif")));

                Barang barang = new Barang();
                barang.setIdBarang(reader.GetInt32(reader.GetOrdinal("id_barang")));
                barang.setNama(reader.GetString(reader.GetOrdinal("barang.nama")));
                barang.setStok(reader.GetInt32(reader.GetOrdinal("stok")));
                barang.setDeskripsi(reader.GetString(reader.GetOrdinal("deskripsi")));
                barang.setStatusAktif(reader.GetString(reader.GetOrdinal("barang.status_aktif")));

                Transaksi transaksi = new Transaksi();
                transaksi.setIdTransaksi(reader.GetInt32(reader.GetOrdinal("id_transaksi")));
                transaksi.setTipeTransaksi(tipeTransaksi);
                transaksi.setPegawai(pegawai);
                transaksi.setBarang(barang);
                transaksi.setTanggal(reader.GetDateTime(reader.GetOrdinal("tanggal")));
                transaksi.setQuantity(reader.GetInt32(reader.GetOrdinal("quantity")));

                listTransaksi.Add(transaksi);
            }

            this.koneksi.closeConnection();
            return listTransaksi;
        }

        public void insertBarangMasuk(int idPegawai, int idBarang, 
            string tanggal, int quantity)
        {
            string sql = "INSERT INTO [transaksi](id_tipe_transaksi, id_pegawai, id_barang, tanggal, quantity) " +
                "VALUES (1, " + idPegawai + ", " + idBarang + ", '" +
                tanggal + "', " + quantity + ")";
            this.koneksi.openConnection();
            this.koneksi.executeNonSelectQuery(sql);
            this.koneksi.closeConnection();
        }

        public void insertBarangKeluar(int idPegawai, int idBarang,
            string tanggal, int quantity)
        {
            string sql = "INSERT INTO [transaksi](id_tipe_transaksi, id_pegawai, id_barang, tanggal, quantity) " +
                "VALUES (2, " + idPegawai + ", " + idBarang + ", '" +
                tanggal + "', " + quantity + ")";
            this.koneksi.openConnection();
            this.koneksi.executeNonSelectQuery(sql);
            this.koneksi.closeConnection();
        }

        public void updateTransaksi(int idTransaksi, int idBarang, string tanggal, int quantity)
        {
            string sql = "UPDATE [transaksi] " +
                "SET id_barang = " + idBarang + ", tanggal = '" + tanggal + "', quantity = " + quantity + " " +
                "WHERE id_transaksi = " + idTransaksi;
            this.koneksi.openConnection();
            this.koneksi.executeNonSelectQuery(sql);
            this.koneksi.closeConnection();
        }

        public void hapusTransaksiDenganId(int idTransaksi)
        {
            string sql = "DELETE FROM [transaksi] " +
                "WHERE id_transaksi = " + idTransaksi;
            this.koneksi.openConnection();
            this.koneksi.executeNonSelectQuery(sql);
            this.koneksi.closeConnection();
        }
    }
}
