using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ödev1
{
    class AlisverisUrunu
    {
        public string Isim { get; set; }
        public int Miktar { get; set; }
        public string Kategori { get; set; }
        public string Notlar { get; set; }

        public AlisverisUrunu(string ısim, int miktar, string kategori, string notlar)
        {
            Isim = ısim;
            Miktar = miktar;
            Kategori = kategori;
            Notlar = notlar;
        }
    }

    class AlisverisListesi
    {
        private Dictionary<string, List<AlisverisUrunu>> alisverisListeleri = new Dictionary<string, List<AlisverisUrunu>>();

        public void AlisverisListesiOlustur(string listeAdi)
        {
            alisverisListeleri[listeAdi] = new List<AlisverisUrunu>();
        }
        
        public void AlisverisListesiGoruntule(string listeAdi)
        {
            if (alisverisListeleri.ContainsKey(listeAdi))
            {
                Console.WriteLine($"Alışveriş Listesi: {listeAdi}");
                foreach(var urun in alisverisListeleri[listeAdi])
                {
                    Console.WriteLine($"Isim: {urun.Isim}, Miktar: {urun.Miktar}, Kategori: {urun.Kategori}, Notlar: {urun.Notlar}");
                }
            }
            else
            {
                Console.WriteLine("Belirtilen isimde bir alışveriş listesi bulunamadı.");
            }
        }
        public void UrunEkle(string listeAdi,string isim,int miktar, string kategori , string notlar)
        {
            if (alisverisListeleri.ContainsKey(listeAdi))
            {
                alisverisListeleri[listeAdi].Add(new AlisverisUrunu(isim, miktar, kategori, notlar));
            }
            else
            {
                Console.WriteLine("Belirtilen isimde bir alışveriş listesi bulunamadı.");
            }
        }
        public void UrunDuzenle(string listeAdi,int urunIndex, string isim, int miktar ,  string kategori , string notlar)
        {
            if (alisverisListeleri.ContainsKey(listeAdi) && urunIndex >= 0 && urunIndex < alisverisListeleri[listeAdi].Count)
            {
                AlisverisUrunu urun = alisverisListeleri[listeAdi][urunIndex];
                urun.Isim = isim;
                urun.Miktar = miktar;
                urun.Kategori = kategori;
                urun.Notlar = notlar;
            }
            else
            {
                Console.WriteLine("Geçersiz liste adı veya ürün index'i.");
            }
        }
        public void UrunSil(string listeAdi,int urunIndex)
        {
            if(alisverisListeleri.ContainsKey(listeAdi) && urunIndex >= 0 && urunIndex < alisverisListeleri[listeAdi].Count)
            {
                alisverisListeleri[listeAdi].RemoveAt(urunIndex);
            }
            else
            {
                Console.WriteLine("Geçersiz liste adı veya ürün index'i.");
            }
        }
        public void KategoriyeAyir(string listeAdi)
        {
            if (alisverisListeleri.ContainsKey(listeAdi))
            {
                var kategorilereAyrilmisListe = new Dictionary<string, List<AlisverisUrunu>>();
                foreach(var urun in alisverisListeleri[listeAdi])
                {
                    string kategori = urun.Kategori;
                    if (!kategorilereAyrilmisListe.ContainsKey(kategori))
                    {
                        kategorilereAyrilmisListe[kategori] = new List<AlisverisUrunu>();
                    }
                    kategorilereAyrilmisListe[kategori].Add(urun);
                }
                Console.WriteLine("Kategorilere Ayrılmış Alışveriş Listesi:");
                foreach(var kategori in kategorilereAyrilmisListe.Keys)
                {
                    Console.WriteLine($"Kategori: {kategori}");
                    foreach(var urun in kategorilereAyrilmisListe[kategori])
                    {
                        Console.WriteLine($"Isim: {urun.Isim}, Miktar: {urun.Miktar}, Notlar: {urun.Notlar}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Belirtilen isimde bir alışveriş listesi bulunamadı.");
            }
        }
    }
     
    internal class Program
    {
        static void Main(string[] args)
        {
            AlisverisListesi alisverisListesi = new AlisverisListesi();

            Console.WriteLine("Alışveriş Listesi Uygulamasına Hoşgeldiniz");
            Console.WriteLine("1. Alışveriş Listesi Oluştur");
            Console.WriteLine("2. Alışveriş Listesi Görüntüle");
            Console.WriteLine("3. Ürün Ekle");
            Console.WriteLine("4. Ürün Düzenle");
            Console.WriteLine("5. Ürün Sil");
            Console.WriteLine("6. Kategorilere Göre Listele");
            Console.WriteLine("7. Çıkış");

            while (true)
            {
                Console.WriteLine("Lütfen Seçiminizi Giriniz:");
                int secim= Convert.ToInt32(Console.ReadLine());

                switch (secim)
                {
                    case 1: 
                        Console.WriteLine("Alışveriş Listesi Adi: ");
                        string listeAdi = Console.ReadLine();
                        alisverisListesi.AlisverisListesiOlustur(listeAdi);
                        Console.WriteLine($"{listeAdi} adlı alışveriş listesi oluşturuldu.");
                        break;
                    case 2: 
                        Console.WriteLine("Grüntülemek istediğiniz alışveriş listesinin adi:");
                        string goruntuleAdi = Console.ReadLine();
                        alisverisListesi.AlisverisListesiGoruntule(goruntuleAdi);
                        break;
                    case 3:
                        Console.WriteLine("Alisveris Listesi Adi:");
                        string ekleListeAdi = Console.ReadLine();
                        Console.WriteLine("Ürün Adi:");
                        string ekleIsim = Console.ReadLine();
                        Console.WriteLine("Miktar:");
                        int ekleMiktar = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Kategori (Gıda, Temizlik, Giyim):");
                        string ekleKategori = Console.ReadLine();
                        Console.WriteLine("Notlar:");
                        string ekleNot = Console.ReadLine();
                        alisverisListesi.UrunEkle(ekleListeAdi, ekleIsim , ekleMiktar, ekleKategori, ekleNot);
                        Console.WriteLine($"{ekleIsim} alışveriş listesine eklendi.");
                        break;
                    case 4:
                        Console.WriteLine("Düzenlemek istediğiniz alışveriş listesi adı:");
                        string duzenleListeAdi = Console.ReadLine();
                        Console.WriteLine("Düzenlemek istediğiniz ürün index'i:");
                        int duzenleIndex = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Yeni isim:");
                        string yeniIsim = Console.ReadLine();
                        Console.WriteLine("Yeni Miktar:");
                        int yeniMiktar = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Yeni Kategori:");
                        string yeniKategori = Console.ReadLine();
                        Console.WriteLine("Yeni Not:");
                        string yeniNot = Console.ReadLine();
                        alisverisListesi.UrunDuzenle(duzenleListeAdi, duzenleIndex, yeniIsim, yeniMiktar, yeniKategori, yeniNot);
                        Console.WriteLine("Ürün başarıyla güncellendi!");
                        break;
                    case 5:
                        Console.WriteLine("Silmek istediğiniz alışveriş listesi adi:");
                        string silListeAdi = Console.ReadLine();
                        Console.WriteLine("Silmek istediğiniz ürün index'i:");
                        int silIndex = Convert.ToInt32(Console.ReadLine());
                        alisverisListesi.UrunSil(silListeAdi, silIndex);
                        Console.WriteLine("Ürün başarıyla silindi!");
                        break;
                    case 6:
                        Console.WriteLine("Kategorilere göre ayırmak istediğiniz alışveriş listesi adı:");
                        string kategoriyeAyrilacakListeAdi = Console.ReadLine();
                        alisverisListesi.KategoriyeAyir(kategoriyeAyrilacakListeAdi);
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Geçersiz Seçenek Lütfen Tekrar Deneyiniz!");
                        break;
                }
            }

            /*alisverisListesi.AlisverisListesiOlustur("Haftalik Alisveris");
            alisverisListesi.UrunEkle("Haftalik Alisveris", "Sut", 2, "Gıda", "Yarim Yagli");
            alisverisListesi.UrunEkle("Haftalik Alisveris", "Sabun", 3, "Temizlik", "Lavanta Kokulu");
            alisverisListesi.AlisverisListesiGoruntule("Haftalik Alisveris");
            alisverisListesi.KategoriyeAyir("Haftalik Alisveris");*/
        }
    }
}
