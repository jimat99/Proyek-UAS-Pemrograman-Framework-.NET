using System;

namespace Project_UAS_Pemrograman_Framework.NET
{
    class Transaksi
    {
        private int idTransaksi;
        private TipeTransaksi tipeTransaksi;
        private Pegawai pegawai;
        private Barang barang;
        private DateTime tanggal;
        private int quantity;

        // Setter
        public void setIdTransaksi(int idTransaksi)
        {
            this.idTransaksi = idTransaksi;
        }

        public void setTipeTransaksi(TipeTransaksi tipeTransaksi)
        {
            this.tipeTransaksi = tipeTransaksi;
        }

        public void setPegawai(Pegawai pegawai)
        {
            this.pegawai = pegawai;
        }

        public void setBarang(Barang barang)
        {
            this.barang = barang;
        }

        public void setTanggal(DateTime tanggal)
        {
            this.tanggal = tanggal;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        // Getter
        public int getIdTransaksi()
        {
            return this.idTransaksi;
        }

        public TipeTransaksi getTipeTransaksi()
        {
            return this.tipeTransaksi;
        }

        public Pegawai getPegawai()
        {
            return this.pegawai;
        }

        public Barang getBarang()
        {
            return this.barang;
        }

        public DateTime getTanggal()
        {
            return this.tanggal;
        }

        public int getQuantity()
        {
            return this.quantity;
        }
    }
}
