using System;

namespace barcode_generator_reader
{
    class Program
    {
        static void Main(string[] args)
        {
            Barcode barcode = new Barcode();
            
            Console.WriteLine("***** Barkod Uygulaması *****");

            while (true)
            {
                Console.WriteLine("1- Yeni Barkod oluşturun");
                Console.WriteLine("2- Var olan barkodu okuyun");
                Console.WriteLine("3- Çıkış");

                if (int.TryParse(Console.ReadLine(), out int input) && (input>=1 && input<=3))
                {
                    if (input==1)
                    {
                        barcode.GenerateBarcode();
                    }
                    else if(input==2)
                    {
                        barcode.ReadBarcode();
                    }
                    else
                    {
                        Console.WriteLine("Sistemden çıkış yapıldı.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı işlem seçimi. (1-3) arasında bir değer girin.");

                    if(!Globals.Repeat())
                    {
                        Console.WriteLine("İşlem iptal edildi.");
                        break;
                    }
                }
            }
        }
    }
}
