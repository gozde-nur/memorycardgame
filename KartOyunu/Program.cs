using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Collections;
using System.Timers;

namespace KartOyunu
{
    class Program
    {
        static int secim2;
        static int adımSayac = 0;
        static int secim1;


        static void Main(string[] args)
        {
            int count = 0;

            Dictionary<int, string> cardList = new Dictionary<int, string>();
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            
            string[] letters = new string[]
            {
             "A", "H", "D", "G", "C", "B", "E", "F",
             "A", "B", "C", "D", "E", "F", "G", "H"
            };

            Random rnd = new Random();
            var lettersArray = letters.OrderBy(a => rnd.Next()).ToList();
            for (int i = 0; i < numbers.Length; i++)
            {
                cardList.Add(numbers[i], lettersArray[i]);
            }

            string[] numbersArray = Array.ConvertAll(numbers, s => s.ToString());


            KartlarBasla();


           

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Thread.Sleep(10);
           

            while (true)
            {
               

                Console.Write("Lütfen 1. Kartı seçiniz : ");
                try
                {
                    secim1 = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Lütfen integer bir sayi giriniz : ");
                    continue;
                }
               
                if (secim1 > 0 && secim1 <= 16)
                {
                    SecimDonguIlk();
                    while(true)
                    {
                        Console.Write("Lütfen 2. Kartı seçiniz : ");
                        //secim2 = Convert.ToInt32(Console.ReadLine());
                        try
                        
                            {
                            secim2 = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Lütfen integer bir sayi giriniz : ");
                            continue;
                        }

                        if (secim2 > 0 && secim2 <= 16)
                        {

                            if (secim2 == secim1)
                                Console.WriteLine("Lütfen farklı bir sayıyı giriniz : ");

                            Console.Clear();
                            Console.WriteLine("seçiminiz:\n ");
                            adımSayac++;
                            SecimDonguIlk();

                            Console.WriteLine("\n\n-----------------------\n\n");

                            if (cardList[secim1] == cardList[secim2])
                            {
                                numbersArray[secim1 - 1] = cardList[secim1];
                                numbersArray[secim2 - 1] = cardList[secim2];
                                count++;

                            }
                            if (count == 8)
                            {
                                stopwatch.Stop();
                                Console.WriteLine("OYUN BİTTİ !!");
                                Console.WriteLine("Toplam Süre : " + stopwatch.Elapsed);
                                Console.WriteLine("Toplam Adım : " + adımSayac);
                                break;

                            }

                        }
                        else
                        {
                            Console.WriteLine("Lütfen 1-16 arası sayi giriniz : ");
                            continue;
                        }
                        break;
                    } 
                        

                }
                else
                {
                    Console.WriteLine("Lütfen 1-16 arası sayi giriniz : ");
                    continue;
                }


               


                KartlarBasla();

            }


            
            void KartlarBasla()
            {
                for (int i = 0; i < 16; i++)
                {

                    if (i == 4)
                        Console.Write("|\n");
                    else if (i == 8)
                        Console.Write("|\n");
                    else if (i == 12)
                        Console.Write("|\n");


                    if (i < 4)
                        Console.Write("| {0,2} ", string.Join("", numbersArray[i]));
                    else if (i >= 4 && i < 8)
                        Console.Write("| {0,2} ", string.Join("", numbersArray[i]));
                    else if (i >= 8 && i < 12)
                        Console.Write("| {0,2} ", string.Join("", numbersArray[i]));
                    else if (i >= 12 && i <= 15)
                        Console.Write("| {0,2} ", string.Join("", numbersArray[i]));

                    if (i == 15)
                        Console.Write("|\n");

                }
            }


            void SecimDonguIlk()
            {
                for (int i = 1; i < 17; i++)
                {

                    if (i == 5)
                        Console.Write("|\n");
                    else if (i == 9)
                        Console.Write("|\n");
                    else if (i == 13)
                        Console.Write("|\n");

                 

                    if (i < 5)
                    {
                        if (i == secim1)
                        {
                            Console.Write("| " + cardList[secim1] + "  ");
                           
                            continue;
                        }
                        if (i == secim2)
                        {
                            Console.Write("| " + cardList[secim2] + "  ");
                            continue;
                        }
                        Console.Write("| {0,2} ", string.Join("", numbersArray[i - 1]));
                    }
                    else if (i >= 5 && i < 9)
                    {
                        if (i == secim1)
                        {
                            Console.Write("| " + cardList[secim1] + "  ");
                            continue;
                        }
                        if (i == secim2)
                        {
                            Console.Write("| " + cardList[secim2] + "  ");
                            continue;
                        }
                        Console.Write("| {0,2} ", string.Join("", numbersArray[i - 1]));
                    }
                    else if (i >= 9 && i < 13)
                    {
                        if (i == secim1)
                        {
                            Console.Write("| " + cardList[secim1] + "  ");
                            continue;
                        }
                        if (i == secim2)
                        {
                            Console.Write("| " + cardList[secim2] + "  ");
                            continue;
                        }
                        Console.Write("| {0,2} ", string.Join("", numbersArray[i - 1]));

                    }
                    else if (i >= 13 && i <= 16)
                    {
                        if (i == secim1)
                        {
                            Console.Write("| " + cardList[secim1] + "  ");
                            continue;
                        }
                        if (i == secim2)
                        {
                            Console.Write("| " + cardList[secim2] + "  ");
                            continue;
                        }
                        Console.Write("| {0,2} ", string.Join("", numbersArray[i - 1]));

                    }

                       if (i == 16)
                      Console.Write("|\n");


                }
                

            }


        }


    }
}


