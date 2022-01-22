using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] depo = new string[30][];
            for (int i = 0; i < 30; i++)
            {
                depo[i] = new string[7];
            }
            bool[] depo2 = new bool[30];
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    depo[i][j] = "";
                }
            }
            amenu(depo, depo2);
        }

        public static void amenu(string[][] depo, bool[] depo2)
        {
        menu:
            Console.WriteLine("----İşlemler---");
            Console.WriteLine("1-Çalışan Ekle");
            Console.WriteLine("2-Çalışan Sil");
            Console.WriteLine("3-Çalışanları Listele");
            Console.WriteLine("4-Çalışan Bilgilerini Düzenle");
            Console.WriteLine("5-Çalışan Bordro");
            Console.WriteLine("6-Çıkış");
            int yapilacak = 0;
            yapilacak = Convert.ToInt32(Console.ReadLine());
            switch(yapilacak)
            {
                case 1:
                    eleman_ekle(depo, depo2);
                    break;
                case 2:
                    eleman_sil(depo, depo2);
                    break;
                case 3:
                    elemanlari_listele(depo, depo2);
                    break;
                case 4:
                    elemanbilgi_duzenle(depo, depo2);
                    break;
                case 5:
                    bordro(depo, depo2);
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Lütfen Geçerli Bİr İşlem Numarası Giriniz");
                    goto menu;
            }

        }

        public static void eleman_ekle(string[][] depo, bool[] depo2)
        {
            ekledevam:
            int ind = Array.IndexOf(depo2, false);
            if(ind != -1)
            {
                Console.WriteLine("Yeni eleman bilgilerini giriniz..");
                Console.WriteLine("Eleman İsmi Giriniz");
                depo[ind][0] = Console.ReadLine();
                Console.WriteLine("Eleman id Giriniz");
                depo[ind][1] = Console.ReadLine();
                Console.WriteLine("Eleman Telefon numarası giriniz");
                depo[ind][2] = Console.ReadLine();
                Console.WriteLine("İşe başlama tarihi giriniz (Yıl)");
                depo[ind][3] = Console.ReadLine();
                Console.WriteLine("Medeni durum (evli - bekar)");
                depo[ind][4] = Console.ReadLine();
                if(depo[ind][4]== "evli")
                {
                    Console.WriteLine("Eşiniz Çalışıyor mu? (e-h)");
                    depo[ind][5] = Console.ReadLine();
                    Console.WriteLine("Çocuğunuz var mı ? (e-h)");
                    depo[ind][6] = Console.ReadLine();
                }
               
                depo2[ind] = true;
                Console.Clear();
                Console.WriteLine("Eleman Eklendi");

                cevapla:
                Console.WriteLine("Bir eleman daha eklemek ister misiniz H-E");
                string cevap = Console.ReadLine();
                if (cevap == "e" || cevap == "E")
                    goto ekledevam;
                else if (cevap == "h" || cevap == "H")
                {
                    amenu(depo, depo2);
                }
                else
                    Console.WriteLine("E (evet) veya H (hayır) olarak cavaplayınız...");
                goto cevapla;
            }
        }

        public static void eleman_sil(string[][] depo, bool[] depo2)
        {
            for (int i = 0; i < 30; i++)//mevcut elemanları ekrana yazdırdık
            {
                if (depo2[i] == true)
                {
                    Console.WriteLine("İsim : " + depo[i][0]);
                    Console.WriteLine("Numara : " + depo[i][1]);
                    Console.WriteLine("Çalışan Tel No : " + depo[i][2]);
                }
            }
            Console.WriteLine();

        tekrar:
            Console.WriteLine("Silmek istedğiniz elemanın id sini giriniz ");
            string silinecek = Console.ReadLine();
            int silinecekindex = -1;
            for (int i = 0; i < 30; i++)
            {
                if(depo[i][1].Equals(silinecek))//equals eşit olup olmadıklarını kontrol eder.
                {
                    Console.WriteLine("Eleman Silindi");
                    silinecekindex = i;
                }
            }
            if (silinecekindex == -1)
            {
                Console.WriteLine(" Böyle Bir Kayıt bulunamadı");
                goto tekrar;
            }
            if (silinecekindex != -1)
            {
                depo2[silinecekindex] = false;

            }
            amenu(depo, depo2);
        }


        public static void elemanlari_listele(string[][] depo, bool[] depo2)
        {
            Console.Clear();//yazıları temizle
            for (int i = 0; i < 30; i++)
            {
                if (depo2[i] == true)
                {
                    Console.WriteLine("İsim : " + depo[i][0]);
                    Console.WriteLine("Numara : " + depo[i][1]);
                    Console.WriteLine("Çalışan Tel No : " + depo[i][2]);
                }
            }
            amenu(depo, depo2);
        }

        public static void elemanbilgi_duzenle(string[][] depo, bool[] depo2)
        {
            guncelle:
            Console.WriteLine("Güncellemek istediğiniz elemanın id sini giriniz");
            string id = Console.ReadLine();
            int gunindex = 0;
            for (int i = 0; i < 30; i++)
            {
                if(depo[i][1].Contains(id))// contains verilen string de arama yapar
                {
                    Console.WriteLine("Aranan id deki eleman Bulundu..");
                    gunindex = i;
                }
            }
            if (gunindex!=-1)
            {
                Console.WriteLine("Güncellenecek İsim:{0} ", depo[gunindex][0]);
                Console.WriteLine("Aranan indeks " + gunindex);
                Console.WriteLine("Yeni id ");
                depo[gunindex][1] = Console.ReadLine();
                Console.WriteLine("İsim giriniz ");
                depo[gunindex][0] = Console.ReadLine();
                Console.WriteLine("Telefon numarası giriniz");
                depo[gunindex][2] = Console.ReadLine();
                Console.WriteLine(id + " id li eleman başarıyla güncellendi");
            }
            cevapla:
            Console.WriteLine("Bir eleman daha güncellemek ister misiniz H-E");
            string cevap = Console.ReadLine();
            if (cevap == "e" || cevap == "E")
                goto guncelle;
            else if (cevap == "h" || cevap == "H")
            {
                amenu(depo, depo2);
            }
            else
                Console.WriteLine("E (evet) veya H (hayır) olarak cavaplayınız...");
            goto cevapla;
        }

        public static void bordro(string[][] depo, bool[] depo2)
        {
            double maas = 3250;
            Console.Clear();//yazıları temizle
            for (int i = 0; i < 30; i++)
            {
                if (depo2[i] == true)
                {
                    Console.WriteLine("İsim : " + depo[i][0]);
                    Console.WriteLine("Numara : " + depo[i][1]);
                    Console.WriteLine("Çalışan Tel No : " + depo[i][2]);
                    string baslamayil = depo[i][3];
                    double calismayili = 2021 - Convert.ToDouble(baslamayil);
                    if (depo[i][4] == "bekar")
                        maas += maas*(calismayili*0.03);
                    else
                    {
                        if (depo[i][5] == "h" && depo[i][6] == "h")
                            maas += maas * (calismayili * 0.05);
                        else if (depo[i][5] == "h" && depo[i][6] == "e")
                            maas += maas * (calismayili * 0.06);
                        else if(depo[i][5] == "e" && depo[i][6] == "h")
                            maas += maas * (calismayili * 0.07);
                        else if(depo[i][5] == "e" && depo[i][6] == "e")
                            maas += maas * (calismayili * 0.09);
                    }
                    Console.WriteLine("Maaş : " + maas);
                }
            }
            amenu(depo, depo2);
        }
    }
}
