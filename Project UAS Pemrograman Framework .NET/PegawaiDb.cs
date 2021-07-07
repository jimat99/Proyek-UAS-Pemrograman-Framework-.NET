using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Project_UAS_Pemrograman_Framework.NET
{
    class PegawaiDb
    {
        private Koneksi koneksi;

        public PegawaiDb()
        {
            this.koneksi = new Koneksi();
        }

        public List<Pegawai> getAllPegawai()
        {
            List<Pegawai> listPegawai = new List<Pegawai>();
            string sql = "SELECT user.id_user, user.username, user.password, user.tipe, " +
                "pegawai.id_pegawai, pegawai.nama, pegawai.alamat, " +
                "pegawai.jenis_kelamin, pegawai.email, pegawai.nomor_telepon, " +
                "pegawai.status_aktif " +
                "FROM [pegawai] " +
                "INNER JOIN [user] " +
                "ON pegawai.id_user = user.id_user";
            this.koneksi.openConnection();
            OleDbDataReader reader = this.koneksi.executeSelectQuery(sql);

            while (reader.Read())
            {
                User user = new User();
                user.setIdUser(reader.GetInt32(reader.GetOrdinal("id_user")));
                user.setUsername(reader.GetString(reader.GetOrdinal("username")));
                user.setPassword(reader.GetString(reader.GetOrdinal("password")));
                user.setTipe(reader.GetString(reader.GetOrdinal("tipe")));

                Pegawai pegawai = new Pegawai();
                pegawai.setIdPegawai(reader.GetInt32(reader.GetOrdinal("id_pegawai")));
                pegawai.setUser(user);
                pegawai.setNama(reader.GetString(reader.GetOrdinal("nama")));
                pegawai.setAlamat(reader.GetString(reader.GetOrdinal("alamat")));
                pegawai.setJenisKelamin(reader.GetString(reader.GetOrdinal("jenis_kelamin")));
                pegawai.setEmail(reader.GetString(reader.GetOrdinal("email")));
                pegawai.setNomorTelepon(reader.GetString(reader.GetOrdinal("nomor_telepon")));
                pegawai.setStatusAktif(reader.GetString(reader.GetOrdinal("status_aktif")));

                listPegawai.Add(pegawai);
            }

            this.koneksi.closeConnection();
            return listPegawai;
        }

        public void insertPegawai(int idUser, string nama, string alamat, string jenisKelamin, string email, 
            string nomorTelepon, string statusAktif)
        {
            string sql = "INSERT INTO [pegawai](id_user, nama, alamat, jenis_kelamin, email, " + 
                "nomor_telepon, status_aktif) " + 
                "VALUES (" + idUser + ", '" + nama + "', '" + alamat + "', '" + jenisKelamin + "', '" + 
                email + "', '" + nomorTelepon + "', '" + statusAktif + "')";
            this.koneksi.openConnection();
            this.koneksi.executeNonSelectQuery(sql);
            this.koneksi.closeConnection();
        }

        public void updatePegawai(int idPegawai, string nama, string alamat, string jenisKelamin, string email,
            string nomorTelepon, string statusAktif)
        {
            string sql = "UPDATE [pegawai] " + 
                "SET nama = '" + nama + "', alamat = '" + alamat + "', " +
                "jenis_kelamin = '" + jenisKelamin + "', email = '" + email + "', " +
                "nomor_telepon = '" + nomorTelepon + "', status_aktif = '" + statusAktif + "' " +
                "WHERE id_pegawai = " + idPegawai;
            this.koneksi.openConnection();
            this.koneksi.executeNonSelectQuery(sql);
            this.koneksi.closeConnection();
        }

        public int getIdPegawaiDenganUsername(string username)
        {
            string sql = "SELECT pegawai.id_pegawai " +
                "FROM [pegawai] " +
                "INNER JOIN [user] " +
                "ON pegawai.id_user = user.id_user " +
                "WHERE StrComp(user.username, '" + username + "', 0) = 0";
            this.koneksi.openConnection();
            int idPegawai = Convert.ToInt32(this.koneksi.executeScalarSelectQuery(sql));
            this.koneksi.closeConnection();
            return idPegawai;
        }
    }
}
