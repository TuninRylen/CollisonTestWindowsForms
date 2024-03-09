/****************************************************************************
**                   SAKARYA ÜNİVERSİTESİ
**                   BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**                   BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**                   NESNEYE DAYALI PROGRAMLAMA DERSİ
**                  
**                   ÖDEV NUMARASI: 1;
**                   ÖĞRENCİ ADI: Uğur CAn ÇELİK;
**                   ÖĞRENCİ NUMARASI: b221210063;
**                   DERS GRUBU: A;
**                   YOUTUBE LİNKİ:https://youtu.be/qxmK7VJpBv0;
****************************************************************************/
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static NDP_Projesi.cisimler;

namespace NDP_Projesi
{
    public class cisimler
    {
        public class nokta2d
        {
            double x;
            double y;

            public nokta2d()
            {
                this.x = 0;
                this.y = 0;
            }

            public nokta2d(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public double X { get => x; set => x = value; }
            public double Y { get => y; set => y = value; }
        }

        public class nokta3d
        {
            double x;
            double y;
            double z;

            public nokta3d()
            {
                this.x = 0;
                this.y = 0;
                this.z = 0;
            }

            public nokta3d(double x, double y, double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public double X { get => x; set => x = value; }
            public double Y { get => y; set => y = value; }
            public double Z { get => z; set => z = value; }

        }

        public class daire
        {
            nokta2d m;
            double r;

            public daire()
            {
                m = new nokta2d();
                r = 0;
            }

            public daire(nokta2d m, double r)
            {
                this.m = m;
                this.r = r;
            }
            public nokta2d M { get => m; set => m = value; }
            public double R { get => r; set => r = value; }
        }

        public class dikdortgen
        {
            nokta2d m;
            double kenarX;
            double kenarY;

            public dikdortgen()
            {
                m = new nokta2d();
                kenarX = 0;
                kenarY = 0;
            }

            public dikdortgen(nokta2d m, double kenarX, double kenarY)
            {
                this.m = m;
                this.kenarX = kenarX;
                this.kenarY = kenarY;
            }

            public nokta2d M { get => m; set => m = value; }
            public double KenarX { get => kenarX; set => kenarX = value; }
            public double KenarY { get => kenarY; set => kenarY = value; }

        }

        public class kure
        {
            nokta3d m;
            double r;

            public kure()
            {
                m = new nokta3d();
                r = 0;
            }
            public kure(nokta3d m, double r)
            {
                this.m = m;
                this.r = r;
            }
            public nokta3d M { get => m; set => m = value; }
            public double R { get => r; set => r = value; }

        }

        public class dPrizması
        {
            nokta3d m;
            double kenarX;
            double kenarY;
            double kenarZ;

            public dPrizması()
            {
                m = new nokta3d();
                kenarX = 0;
                kenarY = 0;
                kenarZ = 0;
            }

            public dPrizması(nokta3d m, double kenarX, double kenarY, double kenarZ)
            {
                this.m = m;
                this.kenarX = kenarX;
                this.kenarY = kenarY;
                this.kenarZ = kenarZ;
            }

            public nokta3d M { get => m; set => m = value; }
            public double KenarX { get => kenarX; set => kenarX = value; }
            public double KenarY { get => kenarY; set => kenarY = value; }
            public double KenarZ { get => kenarZ; set => kenarZ = value; }

        }

        public class silindir
        {
            nokta3d m;
            double r;
            double h;

            public silindir()
            {
                m = new nokta3d();
                r = 0;
                h = 0;
            }

            public silindir(nokta3d m, double r, double h)
            {
                this.m = m;
                this.r = r;
                this.h = h;
            }

            public nokta3d M { get => m; set => m = value; }
            public double R { get => r; set => r = value; }
            public double H { get => h; set => h = value; }
        }

        public class düzlem
        {
            nokta3d düzlemNormalVektörü;
            nokta3d düzlemÜzerindeNokta1;
            nokta3d düzlemÜzerindeNokta2;
            nokta3d düzlemÜzerindeNokta3;

            public düzlem()
            {
                düzlemÜzerindeNokta1 = new nokta3d();
                düzlemÜzerindeNokta2 = new nokta3d();
                düzlemÜzerindeNokta3 = new nokta3d();
                düzlemNormalVektörü = new nokta3d();
            }

            public düzlem(nokta3d dNokta1, nokta3d dNokta2, nokta3d dNokta3)
            {
                this.düzlemÜzerindeNokta1 = dNokta1;
                this.düzlemÜzerindeNokta2 = dNokta2;
                this.düzlemÜzerindeNokta3 = dNokta3;
                
                nokta3d Vektor12 = new nokta3d(dNokta2.X - dNokta1.X, dNokta2.Y - dNokta1.Y, dNokta2.Z - dNokta1.Z);
                nokta3d Vektor13 = new nokta3d(dNokta3.X - dNokta1.X, dNokta3.Y - dNokta1.Y, dNokta3.Z - dNokta1.Z);

                double VektorX = (Vektor12.Y * Vektor13.Z) - (Vektor13.Y * Vektor12.Z); 
                double VektorY = (Vektor13.X * Vektor12.Z) - (Vektor12.X * Vektor13.Z);
                double VektorZ = (Vektor12.X * Vektor13.Y) - (Vektor13.X * Vektor12.Y);
           
                düzlemNormalVektörü = new nokta3d(VektorX, VektorY, VektorZ);
            }

            public nokta3d DüzlemNormalVektörü { get => düzlemNormalVektörü; set => düzlemNormalVektörü = value; }
            public nokta3d DüzlemÜzerindeNokta1 { get => düzlemÜzerindeNokta1; set => düzlemÜzerindeNokta1 = value; }
            public nokta3d DüzlemÜzerindeNokta2 { get => düzlemÜzerindeNokta2; set => düzlemÜzerindeNokta2 = value; }
            public nokta3d DüzlemÜzerindeNokta3 { get => düzlemÜzerindeNokta3; set => düzlemÜzerindeNokta3 = value; }


        }
    }
	
    public class carpismalar
    {
        static public string NoktaVsDikdortgen(cisimler.nokta2d nokta, cisimler.dikdortgen dikdortgen)
        {
            if (Math.Abs(nokta.X - dikdortgen.M.X) - dikdortgen.KenarX / 2.0 <= 0 && Math.Abs(nokta.Y - dikdortgen.M.Y) - dikdortgen.KenarY / 2.0 <= 0)
            {
                return "Çarpışma Vardır";
            }
            else
            {
                return "Çarpışma Yoktur";
            }
        }

        static public string NoktaVsDaire(cisimler.nokta2d nokta, cisimler.daire daire)
        {
            if (Math.Sqrt(Math.Pow((nokta.X - daire.M.X), 2) + Math.Pow((nokta.Y - daire.M.Y), 2)) > daire.R)
            {
                return "Çarpışma Yoktur";
            }
            else
            {
                return "Çarpışma Vardır";
            }
        }

        static public string DikdortgenVsDikdortgen(cisimler.dikdortgen dikdortgen1, cisimler.dikdortgen dikdortgen2)
        {
            if (Math.Abs(dikdortgen1.M.X - dikdortgen2.M.X) <= (dikdortgen1.KenarX + dikdortgen2.KenarX) / 2 && Math.Abs(dikdortgen1.M.Y - dikdortgen2.M.Y) <= (dikdortgen1.KenarY + dikdortgen2.KenarY) / 2)
            {
                return "Çarpışma Vardır";
            }
            else
            {
                return "Çarpışma Yoktur";
            }
        }

        //DaireVsDikdortgen kısmını Anlat
        static public string DaireVsDikdortgen(cisimler.daire daire, cisimler.dikdortgen dikdortgen)
        {
            bool test1 = DikdörtgenİleÇemberÇarpışıyorMu(daire, dikdortgen);    //Test Yapılır

            //testten gelen değer true ise çarpışma vardır, false ise çarpışma vardır
            if (test1)
            {
                return "Çarpışma Vardır";
            }
            else
            {
                return "Çarpışma Yoktur";
            }
        }

        static public string DaireVsDaire(cisimler.daire daire1, cisimler.daire daire2)
        {
            if (Math.Sqrt(Math.Pow((daire1.M.X - daire2.M.X), 2) + Math.Pow((daire1.M.Y - daire2.M.Y), 2)) > daire1.R + daire2.R)
            {
                return "Çarpışma Yoktur";
            }
            else
            {
                return "Çarpışma Vardır";
            }
        }

        static public string NoktaVsKure(cisimler.nokta3d nokta, cisimler.kure kure)
        {
            double MerkezlerArasıUzunluk = Math.Sqrt(Math.Pow((nokta.X - kure.M.X), 2) + Math.Pow((nokta.Y - kure.M.Y), 2) + Math.Pow((nokta.Z - kure.M.Z), 2));    //Nokta ile çember arasındaki mesafe hesaplanır

            if (MerkezlerArasıUzunluk > kure.R)
            {
                return "Çarpışma Yoktur";
            }
            else
            {
                return "Çarpışma Vardır";
            }
        }

        static public string NoktaVsDPrizma(cisimler.nokta3d nokta, cisimler.dPrizması dPrizma)
        {
            if (Math.Abs(nokta.X - dPrizma.M.X) - dPrizma.KenarX / 2.0 <= 0 && Math.Abs(nokta.Y - dPrizma.M.Y) - dPrizma.KenarY / 2.0 <= 0 && Math.Abs(nokta.Z - dPrizma.M.Z) - dPrizma.KenarZ / 2.0 <= 0)
            {
                return "Çarpışma Vardır";
            }
            else
            {
                return "Çarpışma Yoktur";
            }
        }

        static public string KureVsKure(cisimler.kure kure1, cisimler.kure kure2)
        {
            double merkezlerArasıUzunluk = Math.Sqrt(Math.Pow((kure1.M.X - kure2.M.X), 2) + Math.Pow((kure1.M.Y - kure2.M.Y), 2) + Math.Pow((kure1.M.Z - kure2.M.Z), 2));     //Küreşlerin merkezleri arasındaki mesafe hesaplanır

            //merkezlerArasıUzunluk Kure1R + Kure2R den büyük ise çarpışma yoktur
            if (merkezlerArasıUzunluk > kure1.R + kure2.R)
            {
                return "Çarpışma Yoktur";
            }
            else
            {
                return "Çarpışma Vardır";
            }
        }

        static public string DPrizmaVsDPrizma(cisimler.dPrizması dPrizma1, cisimler.dPrizması dPrizma2)
        {
            if (Math.Abs(dPrizma1.M.X - dPrizma2.M.X) <= (dPrizma1.KenarX + dPrizma2.KenarX) / 2 && Math.Abs(dPrizma1.M.Y - dPrizma2.M.Y) <= (dPrizma1.KenarY + dPrizma2.KenarY) / 2 && Math.Abs(dPrizma1.M.Z - dPrizma2.M.Z) <= (dPrizma1.KenarZ + dPrizma2.KenarZ) / 2)
            {
                return "Çarpışma Vardır";
            }
            else
            {
                return "Çarpışma Yoktur";
            }
        }

        static public string NoktaVsSilindir(cisimler.nokta3d nokta, cisimler.silindir silindir)
        {
            if (Math.Sqrt(Math.Pow((nokta.X - silindir.M.X), 2) + Math.Pow((nokta.Z - silindir.M.Z), 2)) > silindir.R)
            {
                return "Çarpışma Yoktur";
            }
            else
            {
                if (Math.Abs(nokta.Y - silindir.M.Y) > silindir.H/ 2)
                {
                    return "Çarpışma Yoktur";
                }
                else
                {
                    return "Çarpışma Vardır";
                }
            }
        }

        //DuzlemVsDprizma Anlat
        static public string DuzlemVsDPrizma(cisimler.düzlem düzlem, cisimler.dPrizması dPrizma)
        {

            double normalX = düzlem.DüzlemNormalVektörü.X;
            double normalY = düzlem.DüzlemNormalVektörü.Y;
            double normalZ = düzlem.DüzlemNormalVektörü.Z;

            nokta3d düzlemNokta = new nokta3d(düzlem.DüzlemÜzerindeNokta1.X, düzlem.DüzlemÜzerindeNokta1.Y, düzlem.DüzlemÜzerindeNokta1.Z);
            nokta3d prizmaNokta = new nokta3d(dPrizma.M.X, dPrizma.M.Y, dPrizma.M.Z);

            double Parametrik_t = (normalX * (düzlemNokta.X - prizmaNokta.X) + normalY * (düzlemNokta.Y - prizmaNokta.Y) + normalZ * (düzlemNokta.Z - prizmaNokta.Z)) / (Math.Pow(normalX, 2) + Math.Pow(normalY, 2) + Math.Pow(normalZ, 2));

            //Düzlem üzerindeki en yakın noktanın kordinatları
            nokta3d DüzlemÜzerindekiEnYakınNokta = new nokta3d(normalX * Parametrik_t + prizmaNokta.X, normalY * Parametrik_t + prizmaNokta.Y, normalZ * Parametrik_t + prizmaNokta.Z);

            //nokta D prizma testleri yapılır
            bool test1 = Math.Abs(DüzlemÜzerindekiEnYakınNokta.X - dPrizma.M.X) - dPrizma.KenarX / 2.0 <= 0;
            bool test2 = Math.Abs(DüzlemÜzerindekiEnYakınNokta.Y - dPrizma.M.Y) - dPrizma.KenarY / 2.0 <= 0;
            bool test3 = Math.Abs(DüzlemÜzerindekiEnYakınNokta.Z - dPrizma.M.Z) - dPrizma.KenarZ / 2.0 <= 0;

            //Çarpışma var mı yok mu bakılır
            if (test1 && test2 && test3)
            {
                return "Çarpışma Vardır";
            }
            else
            {
                return "Çarpışma Yoktur";
            }
        }

        static public string DuzlemVsSilindir(cisimler.düzlem düzlem, cisimler.silindir silindir)
        {
            double Parametrik_t = (düzlem.DüzlemNormalVektörü.X * (düzlem.DüzlemÜzerindeNokta1.X - silindir.M.X) + düzlem.DüzlemNormalVektörü.Y * (düzlem.DüzlemÜzerindeNokta1.Y - silindir.M.Y) + düzlem.DüzlemNormalVektörü.Z * (düzlem.DüzlemÜzerindeNokta1.Z - silindir.M.Z)) / (Math.Pow(düzlem.DüzlemNormalVektörü.X, 2) + Math.Pow(düzlem.DüzlemNormalVektörü.Y, 2) + Math.Pow(düzlem.DüzlemNormalVektörü.Z, 2));

            //Düzlem üzerindeki en yakın noktanın kordinatları
            nokta3d DüzlemÜzerindekiEnYakınNokta = new nokta3d(düzlem.DüzlemNormalVektörü.X * Parametrik_t + silindir.M.X, düzlem.DüzlemNormalVektörü.Y * Parametrik_t + silindir.M.Y, düzlem.DüzlemNormalVektörü.Z * Parametrik_t + silindir.M.Z);


            if (Math.Sqrt(Math.Pow((DüzlemÜzerindekiEnYakınNokta.X - silindir.M.X), 2) + Math.Pow((DüzlemÜzerindekiEnYakınNokta.Z - silindir.M.Z), 2)) > silindir.R)
            {
                return "Çarpışma Yoktur";
            }
            else
            {
                if (Math.Abs(DüzlemÜzerindekiEnYakınNokta.Y - silindir.M.Y) > silindir.H / 2)
                {
                    return "Çarpışma Yoktur";
                }
                else
                {
                    return "Çarpışma Vardır";
                }
            }
        }

        //DuzlemVsKure Anlat
        static public string DuzlemVsKure(cisimler.düzlem düzlem, cisimler.kure kure)
        {
            double merkezlerArasıUzaklık = Math.Abs(düzlem.DüzlemNormalVektörü.X * (kure.M.X - düzlem.DüzlemÜzerindeNokta1.X) + düzlem.DüzlemNormalVektörü.Y * (kure.M.Y - düzlem.DüzlemÜzerindeNokta1.Y) + düzlem.DüzlemNormalVektörü.Z * (kure.M.Z - düzlem.DüzlemÜzerindeNokta1.Z)) / Math.Sqrt(Math.Pow(düzlem.DüzlemNormalVektörü.X, 2) + Math.Pow(düzlem.DüzlemNormalVektörü.Y, 2) + Math.Pow(düzlem.DüzlemNormalVektörü.Z, 2));

            //merkezler arası mesafe kureR den büyük ise çarpışma yoktur.
            if (merkezlerArasıUzaklık > kure.R)
            {
                return "Çarpışma Yoktur";
            }
            else
            {
                return "Çarpışma Vardır";
            }
        }

        //Silindir Vs Silindir Anlat
        static public string SilindirVsSilindir(cisimler.silindir silindir1, cisimler.silindir silindir2)
        {
            if (Math.Sqrt(Math.Pow(silindir1.M.X - silindir2.M.X, 2) + Math.Pow(silindir1.M.Z - silindir2.M.Z, 2)) > silindir1.R + silindir2.R)
            {
                return "Çarpışma Yoktur";
            }
            else
            {
                //silindirlerin merkezleri arası mesafe ortalama h dan büyük ise çarpışma yoktur
                if (Math.Abs(silindir1.M.Y - silindir2.M.Y) - (silindir1.H + silindir2.H) / 2.0 > 0)
                {
                    return "Çarpışma Yoktur";
                }
                else
                {
                    return "Çarpışma Vardır";
                }
            }
        }
        
        //Silindir vs kure anlat
        static public string SilindirVsKure(cisimler.silindir silindir, cisimler.kure kure)
        {

            cisimler.daire testDaire1 = new cisimler.daire(new nokta2d(kure.M.X, kure.M.Y), kure.R);
            cisimler.dikdortgen testDikdortgen1 = new cisimler.dikdortgen(new nokta2d(silindir.M.X, silindir.M.Y), silindir.R * 2, silindir.H);

            cisimler.daire testDaire2 = new cisimler.daire(new nokta2d(kure.M.Y, kure.M.Z), kure.R);
            cisimler.dikdortgen testDikdortgen2 = new cisimler.dikdortgen(new nokta2d(silindir.M.Y, silindir.M.Z), silindir.H, silindir.R * 2);

            bool test1 = Math.Sqrt(Math.Pow(silindir.M.X - kure.M.X, 2) + Math.Pow(silindir.M.Z - kure.M.Z, 2)) <= silindir.R + kure.R;    //Çember Çember çarpışma testi, bool cinsinde
            bool test2 = DikdörtgenİleÇemberÇarpışıyorMu(testDaire1,testDikdortgen1);
            bool test3 = DikdörtgenİleÇemberÇarpışıyorMu(testDaire2,testDikdortgen2);

            //test sonucu
            if (test1 && test2 && test3)
            {
                return "Çarpışma Vardır";
            }
            else
            {
                return "Çarpışma Yoktur";
            }
        }

        public static string KureVsDPrizma(cisimler.kure kure, cisimler.dPrizması dPrizma)
        {

            cisimler.daire testDaire1 = new cisimler.daire(new nokta2d(kure.M.X, kure.M.Y), kure.R);
            cisimler.dikdortgen testDikdortgen1 = new cisimler.dikdortgen(new nokta2d(dPrizma.M.X, dPrizma.M.Y), dPrizma.KenarX, dPrizma.KenarY);

            cisimler.daire testDaire2 = new cisimler.daire(new nokta2d(kure.M.X, kure.M.Z), kure.R);
            cisimler.dikdortgen testDikdortgen2 = new cisimler.dikdortgen(new nokta2d(dPrizma.M.X, dPrizma.M.Z), dPrizma.KenarX, dPrizma.KenarZ);

            cisimler.daire testDaire3 = new cisimler.daire(new nokta2d(kure.M.Y, kure.M.Z), kure.R);
            cisimler.dikdortgen testDikdortgen3 = new cisimler.dikdortgen(new nokta2d(dPrizma.M.Y, dPrizma.M.Z), dPrizma.KenarY, dPrizma.KenarZ);

            //Testler yapıldı
            bool test1 = DikdörtgenİleÇemberÇarpışıyorMu(testDaire1,testDikdortgen1);
            bool test2 = DikdörtgenİleÇemberÇarpışıyorMu(testDaire2,testDikdortgen2);
            bool test3 = DikdörtgenİleÇemberÇarpışıyorMu(testDaire3,testDikdortgen3);

            //Sonuç
            if (test1 && test2 && test3)
            {
                return "Çarpışma Vardır";
            }
            else
            {
                return "Çarpışma Yoktur";
            }
        }

        //Dİkdörtgen İle Çember Çarpışmasını Anlat
        static bool DikdörtgenİleÇemberÇarpışıyorMu(cisimler.daire daire, cisimler.dikdortgen dikdortgen)
        {
            bool CarpısmaVarMı = false;

            //Buradaki if else yapısı raporda bahsedilen çember merkezinin dikdörtgene göre konumu ile alakalıdır
            if (Math.Abs(daire.M.X - dikdortgen.M.X) - dikdortgen.KenarX / 2 > 0 && Math.Abs(daire.M.Y - dikdortgen.M.Y) - dikdortgen.KenarY / 2 > 0) //Çemberin merkezi dikdörtgenin köşe kısımlarında kalıyor ise dikdörtgenin köşe noktaları tabanlı bir çarpışma denetimi yapılır
            {
                double[] DikdörtgenKöşe1 = { dikdortgen.M.X - dikdortgen.KenarX / 2, dikdortgen.M.Y - dikdortgen.KenarY / 2 };    //Dikdörtgenin köşe noktaları oluşturulur
                double[] DikdörtgenKöşe2 = { dikdortgen.M.X + dikdortgen.KenarX / 2, dikdortgen.M.Y - dikdortgen.KenarY / 2 };
                double[] DikdörtgenKöşe3 = { dikdortgen.M.X - dikdortgen.KenarX / 2, dikdortgen.M.Y + dikdortgen.KenarY / 2 };
                double[] DikdörtgenKöşe4 = { dikdortgen.M.X + dikdortgen.KenarX / 2, dikdortgen.M.Y + dikdortgen.KenarY / 2 };

                double Kose1_Merkez_Arası_Mesafe = Math.Sqrt(Math.Pow((daire.M.X - DikdörtgenKöşe1[0]), 2) + Math.Pow((daire.M.Y - DikdörtgenKöşe1[1]), 2));    //Bu noktaların çember merkezi ile aralarındaki mesafe hesaplanır
                double Kose2_Merkez_Arası_Mesafe = Math.Sqrt(Math.Pow((daire.M.X - DikdörtgenKöşe2[0]), 2) + Math.Pow((daire.M.Y - DikdörtgenKöşe2[1]), 2));
                double Kose3_Merkez_Arası_Mesafe = Math.Sqrt(Math.Pow((daire.M.X - DikdörtgenKöşe3[0]), 2) + Math.Pow((daire.M.Y - DikdörtgenKöşe3[1]), 2));
                double Kose4_Merkez_Arası_Mesafe = Math.Sqrt(Math.Pow((daire.M.X - DikdörtgenKöşe4[0]), 2) + Math.Pow((daire.M.Y - DikdörtgenKöşe4[1]), 2));

                //Hesaplamalar sonucu eğer bir tanesi dahi çember yarıçapında küçük ise çarpışma kesindir ve true değeri döndürülü.
                if (Kose1_Merkez_Arası_Mesafe > daire.R && Kose2_Merkez_Arası_Mesafe > daire.R && Kose3_Merkez_Arası_Mesafe > daire.R && Kose4_Merkez_Arası_Mesafe > daire.R)
                {
                    CarpısmaVarMı = false;
                }
                else if (Kose1_Merkez_Arası_Mesafe <= daire.R || Kose2_Merkez_Arası_Mesafe <= daire.R || Kose3_Merkez_Arası_Mesafe <= daire.R || Kose4_Merkez_Arası_Mesafe <= daire.R)
                {
                    CarpısmaVarMı = true;
                }

            }
            else if (Math.Abs(daire.M.X - dikdortgen.M.X) - dikdortgen.KenarX / 2 <= 0 && Math.Abs(daire.M.Y - dikdortgen.M.Y) - dikdortgen.KenarY / 2 > 0)   //Çember merkezinin dikdörtgenin yukarısında veya aşağısında olma durumu
            {
                //Çember ile dikdörtgenin yükseklik belirten kordinatlarının farkının mutlak değeri Dikdörtgenin yüksekliğinin yarısı + Çember yarıçapından büyük ise çarpışma yoktur, değil ise çarpışma vardır true döner
                if (Math.Abs(daire.M.Y - dikdortgen.M.Y) - dikdortgen.KenarY / 2 - daire.R > 0)
                {
                    CarpısmaVarMı = false;
                }
                else
                {
                    CarpısmaVarMı = true;
                }
            }
            else if (Math.Abs(daire.M.X - dikdortgen.M.X) - dikdortgen.KenarX / 2 > 0 && Math.Abs(daire.M.Y - dikdortgen.M.Y) - dikdortgen.KenarY / 2 <= 0)    //Çemberin merkezinin dikdörtgenin sağında veya solunda olma durumu
            {
                //Çember ile dikdörtgenin en belirten kordinatlarının farkının mutlak değeri Dikdörtgenin eninin yarısı + Çember yarıçapından büyük ise çarpışma yoktur, değil ise çarpışma vardır true döner
                if (Math.Abs(daire.M.X - dikdortgen.M.X) - dikdortgen.KenarX / 2 - daire.R > 0)
                {
                    CarpısmaVarMı = false;
                }
                else
                {
                    CarpısmaVarMı = true;
                }
            }
            else if (Math.Abs(daire.M.X - dikdortgen.M.X) - dikdortgen.KenarX / 2 <= 0 && Math.Abs(daire.M.Y - dikdortgen.M.Y) - dikdortgen.KenarY / 2 <= 0)  //Çemberin merkezinin dikdörtgenin içerisinde olduğu durum
            {
                //Çarpışma kesindir
                CarpısmaVarMı = true;
            }

            return CarpısmaVarMı;
        }

    }

    public class FormFonksiyonları
    {
        
        //Form Tasarımını AnlatHahaha

        //Eksen Fonksiyonlarını Anlat
        public static void EksenleriCiz2D(Graphics g)
        {
            Brush MyBrushGray = new SolidBrush(Color.Gray);

            Point xBaşlangıc = new(0, 400);
            Point xBitis = new(800, 400);

            Point yBaşlangıc = new(400, 0);
            Point yBitis = new(400, 800);

            Pen penKalın = new Pen(MyBrushGray, 3);

            //eksenler
            g.DrawLine(penKalın, xBaşlangıc, xBitis);
            g.DrawLine(penKalın, yBaşlangıc, yBitis);
        }

        public static void GridleriCiz2D(Graphics g)
        {
            Brush MyBrushGray = new SolidBrush(Color.Gray);
            Pen penInce = new Pen(MyBrushGray, 1);

            for (int i = 0; i <= 800; i += 20)
            {
                g.DrawLine(penInce, i, 0, i, 800);
                g.DrawLine(penInce, 0, i, 800, i);
            }

        }

        public static void EksenleriCiz3D(Graphics g)
        {
            Brush MyBrushBlue = new SolidBrush(Color.Blue);
            Brush MyBrushRed = new SolidBrush(Color.Red);
            Brush MyBrushGreen = new SolidBrush(Color.Green);
            Brush MyBrushGray = new SolidBrush(Color.Gray);

            Pen penMavi = new Pen(MyBrushBlue, 3);
            Pen penKırmızı = new Pen(MyBrushRed, 3);
            Pen penYesil = new Pen(MyBrushGreen, 3);
            Pen penInce = new Pen(MyBrushGray, 1);


            Point merkez = new(400, 400);

            Point zBitis = new(0, 600);

            Point xBitis = new(800, 600);

            Point yBitis = new(400, 0);


            Font drawFont = new Font("Arial", 11);

            //eksenler
            g.DrawLine(penMavi, merkez, yBitis);
            g.DrawString("Y", drawFont, MyBrushBlue, 405, 10);

            g.DrawLine(penKırmızı, merkez, xBitis);
            g.DrawString("X", drawFont, MyBrushRed, 780, 600);

            g.DrawLine(penYesil, merkez, zBitis);
            g.DrawString("Z", drawFont, MyBrushGreen, 10, 600);
        }

        public static void GridleriCiz3D(Graphics g)
        {

            Brush MyBrushGray = new SolidBrush(Color.Gray);
            Pen penInce = new Pen(MyBrushGray, 1);

            List<Point> yNoktaları = new List<Point>();
            List<Point> yzNoktalarıParalel = new List<Point>();
            List<Point> yxNoktalarıParalel = new List<Point>();

            List<Point> xNoktaları = new List<Point>();
            List<Point> xyNoktalarıParalel = new List<Point>();
            List<Point> xzNoktalarıParalel = new List<Point>();

            List<Point> zNoktaları = new List<Point>();
            List<Point> zyNoktalarıParalel = new List<Point>();
            List<Point> zxNoktalarıParalel = new List<Point>();


            for (int i = 0; i < 380; i += 44)
            {
                int index = i / 44;

                yNoktaları.Add(new Point(400, 400 - i));
                yzNoktalarıParalel.Add(new Point(0, 600 - i));
                yxNoktalarıParalel.Add(new Point(800, 600 - i));

                g.DrawLine(penInce, yNoktaları[index], yzNoktalarıParalel[index]);
                g.DrawLine(penInce, yNoktaları[index], yxNoktalarıParalel[index]);
            }

            for (int i = 0; i < 190; i += 20)
            {
                int index = i / 20;

                zNoktaları.Add(new Point(400 - 2 * i, 400 + i));
                zxNoktalarıParalel.Add(new Point(800 - 2 * i, 600 + i));
                zyNoktalarıParalel.Add(new Point(400 - 2 * i, i));

                g.DrawLine(penInce, zNoktaları[index], zxNoktalarıParalel[index]);
                g.DrawLine(penInce, zNoktaları[index], zyNoktalarıParalel[index]);
            }

            for (int i = 0; i < 190; i += 20)
            {
                int index = i / 20;
                xNoktaları.Add(new Point(400 + 2 * i, 400 + i));
                xyNoktalarıParalel.Add(new Point(400 + 2 * i, i));
                xzNoktalarıParalel.Add(new Point(2 * i, 600 + i));

                g.DrawLine(penInce, xNoktaları[index], xyNoktalarıParalel[index]);
                g.DrawLine(penInce, xNoktaları[index], xzNoktalarıParalel[index]);
            }
        }

        //Donusum Fonksiyonlarını Anlat
        public static cisimler.nokta2d Nokta3dTo2d(cisimler.nokta3d nokta3d)
        {

            cisimler.nokta2d nokta2D;
            cisimler.nokta2d noktaX;
            cisimler.nokta2d noktaZX;


            noktaX = new cisimler.nokta2d(400 + nokta3d.X * 2 / Math.Sqrt(5), 400 + nokta3d.X / Math.Sqrt(5));
            noktaZX = new cisimler.nokta2d(noktaX.X - nokta3d.Z * 2 / Math.Sqrt(5), noktaX.Y + nokta3d.Z / Math.Sqrt(5));
            nokta2D = new cisimler.nokta2d(noktaZX.X, noktaZX.Y - nokta3d.Y);


            return nokta2D;
        }

        public static cisimler.dikdortgen DikdortgenDonustur(cisimler.dikdortgen dıkdortgen)
        {
            cisimler.dikdortgen dikdortgenDonusmus = new cisimler.dikdortgen();

            dikdortgenDonusmus.M.X = dıkdortgen.M.X * 20;
            dikdortgenDonusmus.M.Y = -dıkdortgen.M.Y * 20;
            dikdortgenDonusmus.KenarX = dıkdortgen.KenarX * 20;
            dikdortgenDonusmus.KenarY = dıkdortgen.KenarY * 20;

            return dikdortgenDonusmus;
        }

        public static cisimler.daire DaireDonustur(cisimler.daire daire)
        {
            cisimler.daire daireDonusmus = new cisimler.daire();

            daireDonusmus.M.X = daire.M.X * 20;
            daireDonusmus.M.Y = -daire.M.Y * 20;
            daireDonusmus.R = daire.R * 20;

            return daireDonusmus;
        }

        public static cisimler.dPrizması DPrizmasıDonustur(cisimler.dPrizması dPrizması)
        {
            cisimler.dPrizması dPrizmasıDonusmus = new cisimler.dPrizması();

            dPrizmasıDonusmus.M.X = dPrizması.M.X * 22;
            dPrizmasıDonusmus.M.Y = dPrizması.M.Y * 22;
            dPrizmasıDonusmus.M.Z = dPrizması.M.Z * 22;
            dPrizmasıDonusmus.KenarX = dPrizması.KenarX * 22;
            dPrizmasıDonusmus.KenarY = dPrizması.KenarY * 22;
            dPrizmasıDonusmus.KenarZ = dPrizması.KenarZ * 22;

            return dPrizmasıDonusmus;
        }

        public static cisimler.kure KureDonustur(cisimler.kure kure)
        {
            cisimler.kure kureDonusmus = new cisimler.kure();

            kureDonusmus.M.X = kure.M.X * 22;
            kureDonusmus.M.Y = kure.M.Y * 22;
            kureDonusmus.M.Z = kure.M.Z * 22;
            kureDonusmus.R = kure.R * 22;

            return kureDonusmus;
        }

        public static cisimler.silindir SilindirDonustur(cisimler.silindir silindir)
        {
            cisimler.silindir silindirDonusmus = new cisimler.silindir();

            silindirDonusmus.M.X = silindir.M.X * 22;
            silindirDonusmus.M.Y = silindir.M.Y * 22;
            silindirDonusmus.M.Z = silindir.M.Z * 22;
            silindirDonusmus.R = silindir.R * 22;
            silindirDonusmus.H = silindir.H * 22;

            return silindirDonusmus;
        }

        public static cisimler.düzlem DuzlemDonustur(cisimler.düzlem duzlem)
        {
            cisimler.düzlem duzlemDonusmus = new cisimler.düzlem();

            duzlemDonusmus.DüzlemÜzerindeNokta1.X = duzlem.DüzlemÜzerindeNokta1.X * 44;
            duzlemDonusmus.DüzlemÜzerindeNokta1.Y = duzlem.DüzlemÜzerindeNokta1.Y * 44;
            duzlemDonusmus.DüzlemÜzerindeNokta1.Z = duzlem.DüzlemÜzerindeNokta1.Z * 44;

            duzlemDonusmus.DüzlemÜzerindeNokta2.X = duzlem.DüzlemÜzerindeNokta2.X * 44;
            duzlemDonusmus.DüzlemÜzerindeNokta2.Y = duzlem.DüzlemÜzerindeNokta2.Y * 44;
            duzlemDonusmus.DüzlemÜzerindeNokta2.Z = duzlem.DüzlemÜzerindeNokta2.Z * 44;

            duzlemDonusmus.DüzlemÜzerindeNokta3.X = duzlem.DüzlemÜzerindeNokta3.X * 44;
            duzlemDonusmus.DüzlemÜzerindeNokta3.Y = duzlem.DüzlemÜzerindeNokta3.Y * 44;
            duzlemDonusmus.DüzlemÜzerindeNokta3.Z = duzlem.DüzlemÜzerindeNokta3.Z * 44;

            return duzlemDonusmus;
        }


        //Çizdirme Fonksiyonlarını Anlat
        public static void DaireCiz(cisimler.daire daire, Graphics graphics, Brush MyBrush)
        {
            Pen MyBlackPen = new Pen(Color.Black, 2);

            PointF merkez = new PointF((float)((daire.M.X) + 400 - daire.R), (float)((daire.M.Y) + 400 - daire.R));
            RectangleF rectangle = new RectangleF(merkez.X, merkez.Y, (float)daire.R * 2, (float)daire.R * 2);

            graphics.FillEllipse(MyBrush, rectangle);
            graphics.DrawEllipse(MyBlackPen, rectangle);
        }

        public static void DikdortgenCiz(cisimler.dikdortgen dikdortgen, Graphics graphics, Brush MyBrush)
        {
            Pen MyBlackPen = new Pen(Color.Black, 2);

            PointF merkez = new PointF((float)((dikdortgen.M.X) + 400 - dikdortgen.KenarX / 2),(float)((dikdortgen.M.Y) + 400 - dikdortgen.KenarY / 2));
            RectangleF rectangle = new RectangleF(merkez.X, merkez.Y, (float)dikdortgen.KenarX, (float)dikdortgen.KenarY);

            graphics.FillRectangle(MyBrush,rectangle);
            graphics.DrawRectangle(MyBlackPen, merkez.X, merkez.Y, (float)dikdortgen.KenarX, (float)dikdortgen.KenarY);
        }

        public static void DPrizmaCiz(cisimler.dPrizması dPrizması, Graphics graphics, Brush MyBrush)
        {
            Pen MyBlackPen = new Pen(Color.Black, 2);

            nokta3d M3D = new(dPrizması.M.X, dPrizması.M.Y, dPrizması.M.Z);

            nokta2d M2d = Nokta3dTo2d(M3D);

            PointF M2D = new PointF(((float)M2d.X),((float)M2d.Y));

            PointF M1 = new PointF(M2D.X, M2D.Y - ((float)dPrizması.KenarY / 2));
            PointF M2 = new PointF(M2D.X - ((float)(dPrizması.KenarZ / Math.Sqrt(5))), M2D.Y + ((float)(dPrizması.KenarZ / (Math.Sqrt(5) * 2))));
            PointF M3 = new PointF(M2D.X + ((float)(dPrizması.KenarX / Math.Sqrt(5))), M2D.Y + ((float)(dPrizması.KenarX / (Math.Sqrt(5) * 2))));


            PointF A12 = new PointF(M1.X + ((float)(dPrizması.KenarZ / Math.Sqrt(5))), M1.Y - ((float)(dPrizması.KenarZ / (2 * Math.Sqrt(5)))));
            PointF A34 = new PointF(M1.X - ((float)(dPrizması.KenarZ / Math.Sqrt(5))), M1.Y + ((float)(dPrizması.KenarZ / (2 * Math.Sqrt(5)))));
            PointF A56 = new PointF(M2.X, M2.Y + ((float)(dPrizması.KenarY / 2)));
            PointF A67 = new PointF(M3.X, M3.Y + ((float)(dPrizması.KenarY / 2)));

            PointF A1 = new PointF(A12.X - ((float)(dPrizması.KenarX / Math.Sqrt(5))), A12.Y - ((float)(dPrizması.KenarX / (Math.Sqrt(5) * 2))));
            PointF A2 = new PointF(A12.X + ((float)(dPrizması.KenarX / Math.Sqrt(5))), A12.Y + ((float)(dPrizması.KenarX / (Math.Sqrt(5) * 2))));
            PointF A3 = new PointF(A34.X + ((float)(dPrizması.KenarX / Math.Sqrt(5))), A34.Y + ((float)(dPrizması.KenarX / (Math.Sqrt(5) * 2))));
            PointF A4 = new PointF(A34.X - ((float)(dPrizması.KenarX / Math.Sqrt(5))), A34.Y - ((float)(dPrizması.KenarX / (Math.Sqrt(5) * 2))));
            PointF A5 = new PointF(A56.X - ((float)(dPrizması.KenarX / Math.Sqrt(5))), A56.Y - ((float)(dPrizması.KenarX / (Math.Sqrt(5) * 2))));
            PointF A6 = new PointF(A56.X + ((float)(dPrizması.KenarX / Math.Sqrt(5))), A56.Y + ((float)(dPrizması.KenarX / (Math.Sqrt(5) * 2))));
            PointF A7 = new PointF(A67.X + ((float)(dPrizması.KenarZ / Math.Sqrt(5))), A67.Y - ((float)(dPrizması.KenarZ / (Math.Sqrt(5) * 2))));

            PointF[] UstYuzey = new[] { A1, A2, A3, A4 };
            PointF[] YanYuzey1 = new[] { A3, A4, A5, A6 };
            PointF[] YanYuzey2 = new[] { A2, A3, A6, A7 };


            graphics.FillPolygon(MyBrush, UstYuzey);
            graphics.DrawPolygon(MyBlackPen, UstYuzey);

            graphics.FillPolygon(MyBrush, YanYuzey1);
            graphics.DrawPolygon(MyBlackPen, YanYuzey1);

            graphics.FillPolygon(MyBrush, YanYuzey2);
            graphics.DrawPolygon(MyBlackPen, YanYuzey2);
        }

        public static void SilindirCiz(cisimler.silindir silindir, Graphics graphics, Brush MyBrush)
        {
            Pen MyBlackPen = new Pen(Color.Black, 2);

            nokta3d M3D = new(silindir.M.X, silindir.M.Y, silindir.M.Z);
            nokta2d M2d = Nokta3dTo2d(M3D);

            PointF Cember1 = new((float)(M2d.X - silindir.R), (float)(M2d.Y - (silindir.R + silindir.H) / 2));//okey
            PointF Cember2 = new((float)(M2d.X - silindir.R), (float)(M2d.Y + (silindir.H - silindir.R) / 2));//
            PointF Dikdortgen = new((float)(M2d.X - silindir.R), (float)(M2d.Y - (silindir.H / 2)));


            graphics.FillEllipse(MyBrush, Cember1.X, Cember1.Y, (float)silindir.R * 2, (float)silindir.R);
            graphics.FillEllipse(MyBrush, Cember2.X, Cember2.Y, (float)silindir.R * 2, (float)silindir.R);
            graphics.FillRectangle(MyBrush, Dikdortgen.X, Dikdortgen.Y, (float)silindir.R * 2, (float)silindir.H);

            graphics.DrawEllipse(MyBlackPen, Cember1.X, Cember1.Y, (float)silindir.R * 2, (float)silindir.R);
            graphics.DrawLine(MyBlackPen, Dikdortgen.X, Dikdortgen.Y, Cember2.X, ((float)(Cember2.Y + silindir.R / 2)));
            graphics.DrawLine(MyBlackPen, (float)(Dikdortgen.X + silindir.R * 2), Dikdortgen.Y, (float)(Cember2.X + silindir.R * 2), ((float)(Cember2.Y + silindir.R / 2)));
            graphics.DrawArc(MyBlackPen, Cember2.X, Cember2.Y, (float)silindir.R * 2, (float)silindir.R, 180, -180);
        }

        public static void KureCiz(cisimler.kure kure, Graphics graphics, Brush MyBrush)
        {
            Pen MyBlackPen = new Pen(Color.Black, 2);

            nokta3d M3D = new(kure.M.X, kure.M.Y, kure.M.Z);
            nokta2d M2d = Nokta3dTo2d(M3D);

            PointF Cember = new((float)(M2d.X - kure.R), (float)(M2d.Y - kure.R));
            PointF Yay = new((float)(M2d.X - kure.R), (float)(M2d.Y - (kure.R / 2)));

            graphics.FillEllipse(MyBrush, Cember.X, Cember.Y, (float)kure.R * 2, (float)kure.R * 2);
            graphics.DrawEllipse(MyBlackPen, Cember.X, Cember.Y, (float)kure.R * 2, (float)kure.R * 2);
            graphics.DrawArc(MyBlackPen, Yay.X, Yay.Y, (float)kure.R * 2, (float)kure.R, 180, -180);
        }

        public static void DuzlemCiz(cisimler.düzlem duzlem, Graphics graphics, Brush MyBrush)
        {
            Pen MyBlackPen = new Pen(Color.Black, 2);

            nokta2d nNokta1 = Nokta3dTo2d(duzlem.DüzlemÜzerindeNokta1);
            nokta2d nNokta2 = Nokta3dTo2d(duzlem.DüzlemÜzerindeNokta2);
            nokta2d nNokta3 = Nokta3dTo2d(duzlem.DüzlemÜzerindeNokta3);
            nokta2d nNokta4 = new nokta2d(nNokta1.X + nNokta3.X - nNokta2.X, nNokta1.Y + nNokta3.Y - nNokta2.Y);

            PointF nNokta1F = new(((float)nNokta1.X), ((float)nNokta1.Y));
            PointF nNokta2F = new(((float)nNokta2.X), ((float)nNokta2.Y));
            PointF nNokta3F = new(((float)nNokta3.X), ((float)nNokta3.Y));
            PointF nNokta4F = new(((float)nNokta4.X), ((float)nNokta4.Y));

            PointF[] DuzlemNoktalar = new PointF[4] { nNokta1F, nNokta2F, nNokta3F, nNokta4F };

            graphics.FillPolygon(MyBrush, DuzlemNoktalar);
            graphics.DrawPolygon(MyBlackPen, DuzlemNoktalar);

        }

    }

}
