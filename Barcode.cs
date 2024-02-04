using System;
using System.IO;
using IronBarCode;

namespace barcode_generator_reader
{
    public class Barcode
    {
        public Barcode()
        {
            if(Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }


        private string directoryPath = @"d:\Barcode";
        private string filePath;

        public void GenerateBarcode()
        {
            bool again = false;

            Console.Write("Barkod'a dönüştürülecek metni girin : ");
            string content = Console.ReadLine();

            do
            {
                Console.Write("Kaydedilecek barkod dosyasının adını girin : ");
                string fileName = Console.ReadLine();

                filePath = $@"{directoryPath}\{fileName}.png";

                if (!File.Exists(filePath))
                {
                    try
                    {
                        var barcode = BarcodeWriter.CreateBarcode(content, BarcodeEncoding.Code128);
                        barcode.SaveAsPng(filePath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Barkod dosyası oluşturulurken hata oluştu.");
                        Console.WriteLine("Hata : " + ex.Message);
                    }
                    
                }
                else
                {
                    Console.WriteLine("Bu dosya adı zaten var.");
                    again = Globals.Repeat();
                }

            } while (again);
        }
    
        public void ReadBarcode()
        {
            bool again = false;

            do
            {
                Console.Write("Barkod dosyasının adını girin : ");
                string fileName = Console.ReadLine();

                filePath = $@"{directoryPath}\{fileName}.png";

                if (File.Exists(filePath))
                {
                    try
                    {
                        BarcodeResults resultFromFile = BarcodeReader.Read(filePath);

                        foreach (BarcodeResult barcodeResult in resultFromFile)
                        {
                            Console.WriteLine("Okunan barkod metni : " + barcodeResult);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Barkod dosyası okunmaya çalışılırken hata oluştu.");
                        Console.WriteLine("Hata : " + ex.Message);
                    }
                    
                }
                else
                {
                    Console.WriteLine("Dosya bulunamadı.");
                    again = Globals.Repeat();
                } 

            } while (again);
        }
    }
}