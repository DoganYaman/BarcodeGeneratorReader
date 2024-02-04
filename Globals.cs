using System;

namespace barcode_generator_reader
{
    public static class Globals
    {
        public static bool Repeat()
        {
            bool again = false;
            
            while (true)
            {
                Console.WriteLine("Tekrar deneyin : (1)");
                Console.WriteLine("İptal edin : (2)");

                if (int.TryParse(Console.ReadLine(), out int input) && (input==1 || input==2))
                {
                    if (input == 1)
                    {
                        again = true;
                        break;
                    }
                    else
                    {
                        again = false;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı işlem seçimi!! (1/2) seçin.");
                }
            }

            return again;
        }
    }
}