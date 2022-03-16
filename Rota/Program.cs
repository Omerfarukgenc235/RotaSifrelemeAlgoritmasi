using System;
using System.Collections.Generic;

namespace Rota
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alfabe = { 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I', 'İ', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z' };

            string metin;
            Console.WriteLine("Lütfen bir metin giriniz");
            metin = Console.ReadLine();
            metin = metin.ToUpper();
            char[] karakterler = metin.ToCharArray();
            int n = 4;
            //Console.WriteLine("Lütfen bir n değeri giriniz");
            //n = Convert.ToInt16(Console.ReadLine());
            List<char> dogrukarakterler = new List<char>();
            foreach (var y in karakterler)
            {
                foreach (var x in alfabe)
                {
                    if (x == y)
                    {
                        dogrukarakterler.Add(x);
                    }
                }
            }
            int dogrukaraktersayisi = dogrukarakterler.Count;

            if (dogrukaraktersayisi % n != 0)
            {
                for (int i = 0; i < (n - (dogrukaraktersayisi % n)); i++)
                {
                    dogrukarakterler.Add('A');
                }
            }
            dogrukaraktersayisi = dogrukarakterler.Count;

            int satiruzunlugu = dogrukaraktersayisi / n;

            char[,] matrix = new char[n, satiruzunlugu];
            int deger = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < satiruzunlugu; j++)
                {
                    matrix[i, j] = dogrukarakterler[deger];
                    deger = deger + 1;
                }

            }
            Console.WriteLine("Dizi görünümü");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < satiruzunlugu; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine("");
            }
            int kontrol = dogrukarakterler.Count;
            List<char> kontroledilecek = new List<char>();
            int kontrol2 = kontroledilecek.Count;
            int deneme = 0;
            int asagiicin = 0;
            int yukariicin = 0;
            int yekseni = n;
            int saginuzunlugu = n;
            int kontrolamaclison = satiruzunlugu - 1;
            while (kontrol != kontrol2)
            {
                //yukarı

                while (yekseni > deneme && kontrol != kontrol2)
                {
                    kontroledilecek.Add(matrix[yekseni - 1, deneme]);
                    yekseni--;
                }
                deneme++;
                kontrol2 = kontroledilecek.Count;

                //saga
                while (deneme <= kontrolamaclison && kontrol != kontrol2)
                {
                    kontroledilecek.Add(matrix[yekseni, deneme]);
                    deneme++;
                }
                kontrolamaclison--;
                yekseni++;       
                asagiicin++;
                deneme--;
                //asagi
                kontrol2 = kontroledilecek.Count;

                while (yekseni <saginuzunlugu && kontrol != kontrol2)
                {                  
                    kontroledilecek.Add(matrix[yekseni, deneme]);
                    yekseni++;
                }
                saginuzunlugu--;
                deneme--;
                yekseni--;
                kontrol2 = kontroledilecek.Count;

                //sola
                while (deneme>=asagiicin && kontrol != kontrol2)
                {
                    kontroledilecek.Add(matrix[yekseni, deneme]);
                    deneme--;
                }
                deneme++;
                yekseni--;
                kontrol2 = kontroledilecek.Count;
                //yukari
                while (yekseni>yukariicin && kontrol != kontrol2)
                {
                    kontroledilecek.Add(matrix[yekseni, deneme]);
                    yekseni--;
                }
                yukariicin++;
                yekseni = yukariicin;
                kontrol2 = kontroledilecek.Count;
            }
            Console.WriteLine("");
            Console.Write("Rota algoritmasına göre şifrelenmiş hali = ");
            foreach(var x in kontroledilecek)
            {
                Console.Write(x);
            }
            Console.WriteLine();
            int sifrelenmissayinindegeri = kontroledilecek.Count;
            Console.WriteLine("Şifrelenmiş metinin toplam harf sayisi = " +sifrelenmissayinindegeri);
            int altadogruolandeger = sifrelenmissayinindegeri / n;
            char[,] matrix2 = new char[n, altadogruolandeger];
            Console.WriteLine("x degeri = " + altadogruolandeger);
            Console.WriteLine("y degeri = " + n);
            int deneme2 = 0;
            int asagiicin2 = 0;
            int yukariicin2 = 0;
            int yekseni2 = n;
            int saginuzunlugu2 = n;
            int kontrolamaclison2 = altadogruolandeger - 1;
            int dizidegeri = 0;          
            int kontrol4 = dizidegeri;
            while (sifrelenmissayinindegeri != kontrol4)
            {
                while (yekseni2 > deneme2 && sifrelenmissayinindegeri != kontrol4)
                {
                    matrix2[yekseni2 - 1, deneme2] = kontroledilecek[dizidegeri];
                    dizidegeri++;
                    yekseni2--;
                }
                deneme2++;
                kontrol4 = dizidegeri;
                //saga
                while (deneme2 <= kontrolamaclison2 && sifrelenmissayinindegeri != kontrol4)
                {
                    matrix2[yekseni2, deneme2] = kontroledilecek[dizidegeri];
                    dizidegeri++;
                    deneme2++;
                }
                kontrolamaclison2--;
                yekseni2++;
                asagiicin2++;
                deneme2--;
                //asagi
                kontrol4 = dizidegeri;
                while (yekseni2 < saginuzunlugu2 && sifrelenmissayinindegeri != kontrol4)
                {
                    matrix2[yekseni2, deneme2] = kontroledilecek[dizidegeri];
                    dizidegeri++;
                    yekseni2++;
                }
                saginuzunlugu2--;
                deneme2--;
                yekseni2--;
                kontrol4 = dizidegeri;

                //sola
                while (deneme2 >= asagiicin2 && sifrelenmissayinindegeri != kontrol4)
                {
                    matrix2[yekseni2, deneme2] = kontroledilecek[dizidegeri];
                    dizidegeri++;
                    deneme2--;
                }
                deneme2++;
                yekseni2--;
                kontrol4 = dizidegeri;
                //yukari
                while (yekseni2 > yukariicin2 && sifrelenmissayinindegeri != kontrol4)
                {
                    matrix2[yekseni2, deneme2] = kontroledilecek[dizidegeri];
                    dizidegeri++;
                    yekseni2--;
                }
                yukariicin2++;
                yekseni2 = yukariicin2;
                kontrol4 = dizidegeri;

            }
            Console.WriteLine();
            Console.Write("Şifrenin çözülmüş hali = ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < altadogruolandeger; j++)
                {
                    Console.Write(matrix2[i, j]);
                }
            }
        }
    }
}