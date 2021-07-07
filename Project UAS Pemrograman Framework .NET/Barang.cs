
namespace Project_UAS_Pemrograman_Framework.NET
{
    class Barang
    {
        private int idBarang;
        private string nama;
        private int stok;
        private string deskripsi;
        private string statusAktif;

        // Setter
        public void setIdBarang(int idBarang)
        {
            this.idBarang = idBarang;
        }

        public void setNama(string nama)
        {
            this.nama = nama;
        }

        public void setStok(int stok)
        {
            this.stok = stok;
        }

        public void setDeskripsi(string deskripsi)
        {
            this.deskripsi = deskripsi;
        }

        public void setStatusAktif(string statusAktif)
        {
            this.statusAktif = statusAktif;
        }

        // Getter
        public int getIdBarang()
        {
            return this.idBarang;
        }

        public string getNama()
        {
            return this.nama;
        }

        public int getStok()
        {
            return this.stok;
        }

        public string getDeskripsi()
        {
            return this.deskripsi;
        }

        public string getStatusAktif()
        {
            return this.statusAktif;
        }
    }
}
