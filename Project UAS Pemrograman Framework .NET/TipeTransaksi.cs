using System;

namespace Project_UAS_Pemrograman_Framework.NET
{
    class TipeTransaksi
    {
        private int idTipeTransaksi;
        private string nama;
        private string keterangan;

        // Setter
        public void setIdTipeTransaksi(int idTipeTransaksi)
        {
            this.idTipeTransaksi = idTipeTransaksi;
        }

        public void setNama(string nama)
        {
            this.nama = nama;
        }

        public void setKeterangan(string keterangan)
        {
            this.keterangan = keterangan;
        }

        // Getter
        public int getIdTipeTransaksi()
        {
            return this.idTipeTransaksi;
        }

        public string getNama()
        {
            return this.nama;
        }

        public string getKeterangan()
        {
            return this.keterangan;
        }
    }
}
