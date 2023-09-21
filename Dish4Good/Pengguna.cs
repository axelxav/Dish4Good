using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dish4Good
{
    public class Pengguna
    {
        public int Id { get; set; }
        public string UserType { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public void Login() { /* Implementasi login */ }
        public void Registrasi() { /* Implementasi registrasi */ }
    }

    public class Penerima : Pengguna
    {
        public string NamaYayasan { get; set; } = string.Empty;
        public string NamaOwner { get; set; } = string.Empty;
        public string Rekening { get; set; } = string.Empty;
        public int JumlahAnak { get; set; }
        public string AlamatYayasan { get; set; } = string.Empty;
        public string SertifikatYayasan { get; set; } = string.Empty;
        public string NomorHP { get; set; } = string.Empty;

        public List<PermintaanDonasi> DaftarPermintaanDonasi { get; set; }

        public Penerima()
        {
            DaftarPermintaanDonasi = new List<PermintaanDonasi>();
        }

        public void BuatPermintaanDonasi(string namaYayasan, string tipeDonasi, DateTime waktuDiajukan, DateTime waktuDitutup)
        {
            var permintaanDonasi = new PermintaanDonasi(namaYayasan, tipeDonasi, waktuDiajukan, waktuDitutup);
            DaftarPermintaanDonasi.Add(permintaanDonasi);
        }

        public void UpdatePermintaanDonasi(int id, string namaYayasan, string tipeDonasi, DateTime waktuDitutup)
        {
            var permintaanDonasi = DaftarPermintaanDonasi.FirstOrDefault(p => p.Id == id);
            if (permintaanDonasi != null)
            {
                permintaanDonasi.NamaYayasan = namaYayasan;
                permintaanDonasi.TipeDonasi = tipeDonasi;
                permintaanDonasi.WaktuDitutup = waktuDitutup;
            }
        }

        public void HapusPermintaanDonasi(int id)
        {
            var permintaanDonasi = DaftarPermintaanDonasi.FirstOrDefault(p => p.Id == id);
            if (permintaanDonasi != null)
            {
                DaftarPermintaanDonasi.Remove(permintaanDonasi);
            }
        }

        // Metode lainnya
    }

    public class PermintaanDonasi
    {
        public int Id { get; set; }
        public string NamaYayasan { get; set; }
        public string TipeDonasi { get; set; }
        public DateTime WaktuDiajukan { get; set; }
        public DateTime WaktuDitutup { get; set; }

        public PermintaanDonasi(string namaYayasan, string tipeDonasi, DateTime waktuDiajukan, DateTime waktuDitutup)
        {
            Id = GenerateUniqueId(); // Fungsi untuk menghasilkan ID unik
            NamaYayasan = namaYayasan;
            TipeDonasi = tipeDonasi;
            WaktuDiajukan = waktuDiajukan;
            WaktuDitutup = waktuDitutup;
        }

        private int GenerateUniqueId()
        {
            // Implementasi untuk menghasilkan ID unik (misalnya, dengan increment)
            // Anda bisa mengimplementasikan logika ID sesuai dengan kebutuhan Anda.
            // Ini hanya contoh sederhana.
            return new Random().Next(1000, 9999);
        }
    }

    public class Donatur : Pengguna
    {
        public string NamaDonatur { get; set; } = string.Empty;
        public string AlamatDonatur { get; set; } = string.Empty;
        public string NomorHPDonatur { get; set; } = string.Empty;
        public List<DonasiMakanan> DaftarDonasiMakanan { get; set; }
        public List<DonasiUang> DaftarDonasiUang { get; set; }

        public Donatur()
        {
            DaftarDonasiMakanan = new List<DonasiMakanan>();
            DaftarDonasiUang = new List<DonasiUang>();
        }

        public void MemilihDonasiMakanan(int jumlahMakanan, string namaMakanan, string jenisMakanan)
        {
            var donasiMakanan = new DonasiMakanan(jumlahMakanan, namaMakanan, jenisMakanan);
            DaftarDonasiMakanan.Add(donasiMakanan);
        }

        public void MemilihDonasiUang(double nominal, string metodePembayaran)
        {
            var donasiUang = new DonasiUang(nominal, metodePembayaran);
            DaftarDonasiUang.Add(donasiUang);
        }

        public void UpdateDonasiMakanan(int index, int jumlahMakanan, string namaMakanan, string jenisMakanan)
        {
            if (index >= 0 && index < DaftarDonasiMakanan.Count)
            {
                var donasiMakanan = DaftarDonasiMakanan[index];
                donasiMakanan.JumlahMakanan = jumlahMakanan;
                donasiMakanan.NamaMakanan = namaMakanan;
                donasiMakanan.JenisMakanan = jenisMakanan;
            }
        }

        public void UpdateDonasiUang(int index, double nominal, string metodePembayaran)
        {
            if (index >= 0 && index < DaftarDonasiUang.Count)
            {
                var donasiUang = DaftarDonasiUang[index];
                donasiUang.Nominal = nominal;
                donasiUang.MetodePembayaran = metodePembayaran;
            }
        }

        public void HapusDonasiMakanan(int index)
        {
            if (index >= 0 && index < DaftarDonasiMakanan.Count)
            {
                DaftarDonasiMakanan.RemoveAt(index);
            }
        }

        public void HapusDonasiUang(int index)
        {
            if (index >= 0 && index < DaftarDonasiUang.Count)
            {
                DaftarDonasiUang.RemoveAt(index);
            }
        }
    }

    public class DonasiMakanan
    {
        public int JumlahMakanan { get; set; }
        public string NamaMakanan { get; set; }
        public string JenisMakanan { get; set; }

        public DonasiMakanan(int jumlahMakanan, string namaMakanan, string jenisMakanan)
        {
            JumlahMakanan = jumlahMakanan;
            NamaMakanan = namaMakanan;
            JenisMakanan = jenisMakanan;
        }
    }

    public class DonasiUang
    {
        public double Nominal { get; set; }
        public string MetodePembayaran { get; set; }

        public DonasiUang(double nominal, string metodePembayaran)
        {
            Nominal = nominal;
            MetodePembayaran = metodePembayaran;
        }
    }

}
