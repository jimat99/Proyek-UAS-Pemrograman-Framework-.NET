
namespace Project_UAS_Pemrograman_Framework.NET
{
    class Pegawai
    {
        private int idPegawai;
        private User user;
        private string nama;
        private string alamat;
        private string jenisKelamin;
        private string email;
        private string nomorTelepon;
        private string statusAktif;

        // Setter
        public void setIdPegawai(int idPegawai)
        {
            this.idPegawai = idPegawai;
        }

        public void setUser(User user)
        {
            this.user = user;
        }

        public void setNama(string nama)
        {
            this.nama = nama;
        }

        public void setAlamat(string alamat)
        {
            this.alamat = alamat;
        }

        public void setJenisKelamin(string jenisKelamin)
        {
            this.jenisKelamin = jenisKelamin;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void setNomorTelepon(string nomorTelepon)
        {
            this.nomorTelepon = nomorTelepon;
        }

        public void setStatusAktif(string statusAKtif)
        {
            this.statusAktif = statusAKtif;
        }

        // Getter
        public int getIdPegawai()
        {
            return this.idPegawai;
        }

        public User getUser()
        {
            return this.user;
        }

        public string getNama()
        {
            return this.nama;
        }

        public string getAlamat()
        {
            return this.alamat;
        }

        public string getJenisKelamin()
        {
            return this.jenisKelamin;
        }

        public string getEmail()
        {
            return this.email;
        }

        public string getNomorTelepon()
        {
            return this.nomorTelepon;
        }

        public string getStatusAktif()
        {
            return this.statusAktif;
        }
    }
}
