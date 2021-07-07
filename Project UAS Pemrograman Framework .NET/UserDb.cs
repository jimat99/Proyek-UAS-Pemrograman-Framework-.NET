using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Project_UAS_Pemrograman_Framework.NET
{
    class UserDb
    {
        private Koneksi koneksi;

        public UserDb()
        {
            this.koneksi = new Koneksi();
        }

        public List<User> getAllUser()
        {
            List<User> listUser = new List<User>();
            string sql = "SELECT id_user, username, password, tipe FROM [user]";
            this.koneksi.openConnection();
            OleDbDataReader reader = this.koneksi.executeSelectQuery(sql);

            while (reader.Read())
            {
                User user = new User();
                user.setIdUser(reader.GetInt32(reader.GetOrdinal("id_user")));
                user.setUsername(reader.GetString(reader.GetOrdinal("username")));
                user.setPassword(reader.GetString(reader.GetOrdinal("password")));
                user.setTipe(reader.GetString(reader.GetOrdinal("tipe")));
                listUser.Add(user);
            }

            this.koneksi.closeConnection();
            return listUser;
        }

        public void insertUser(string username, string password, string tipe)
        {
            string sql = "INSERT INTO [user](username, [password], tipe) " + 
                "VALUES ('" + username + "', '" + password + "', '" + tipe + "')";
            this.koneksi.openConnection();
            this.koneksi.executeNonSelectQuery(sql);
            this.koneksi.closeConnection();
        }

        public int getIdUserDenganUsername(string username)
        {
            string sql = "SELECT id_user FROM [user] " +
                "WHERE username = '" + username + "'";
            this.koneksi.openConnection();
            int idUser = Convert.ToInt32(this.koneksi.executeScalarSelectQuery(sql));
            this.koneksi.closeConnection();
            return idUser;
        }

        public string getTipeDenganUsername(string username)
        {
            string sql = "SELECT tipe FROM [user] " +
                "WHERE username = '" + username + "'";
            this.koneksi.openConnection();
            string tipe = Convert.ToString(this.koneksi.executeScalarSelectQuery(sql));
            this.koneksi.closeConnection();
            return tipe;
        }

        public bool isUserPegawaiAktif(string username)
        {
            string sql = "SELECT pegawai.status_aktif FROM [user] " +
                "INNER JOIN pegawai ON user.id_user = pegawai.id_user " +
                "WHERE user.username = '" + username + "'";
            this.koneksi.openConnection();
            string statusAktif = Convert.ToString(this.koneksi.executeScalarSelectQuery(sql));
            if (statusAktif == "Aktif")
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

        public bool isDataLoginValid(string username, string password)
        {
            string sql = "SELECT id_user FROM [user] " +
                "WHERE StrComp(username, '" + username + "', 0) = 0 " +
                "AND StrComp(password, '" + password + "', 0) = 0";
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
    }
}
