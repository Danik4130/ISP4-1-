using System;
using System.IO;
using System.Management; 
using System.Text;

namespace ISP4
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowSystemInfo();

            Console.WriteLine("Нажмите клавишу для продолжения");
            Console.ReadLine();
        }
        public static void ShowSystemInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сведения о системе:");
            Console.ResetColor();
            Console.WriteLine("\tОперационная система:  {0}", Environment.OSVersion);
            Console.WriteLine("\tИмя пользователя: {0}", Environment.UserName);
            Console.WriteLine("\tНазвание ПК по биосу:  {0}", Environment.MachineName);
            Console.WriteLine("\tВремя с первой загрузки ПК (сек):  {0}", Environment.TickCount/1000);
            Console.WriteLine("\tИмя сетевого домена:  {0}", Environment.UserDomainName);
            Console.WriteLine();
            //Проц
            //Вариаблы берутся из реестра
            //Или же отсюда https://ru.wikipedia.org/wiki/%D0%9F%D0%B5%D1%80%D0%B5%D0%BC%D0%B5%D0%BD%D0%BD%D0%B0%D1%8F_%D1%81%D1%80%D0%B5%D0%B4%D1%8B
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сведения о Процессоре:");
            Console.ResetColor();
            Console.WriteLine("\tМодель процессора:  {0}", Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"));
            Console.WriteLine("\tРазрядность процессора:  {0}", Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"));
            Console.WriteLine("\tНомер модели процессора:  {0}", Environment.GetEnvironmentVariable("PROCESSOR_LEVEL"));
            Console.WriteLine("\tЧисло процессоров:  {0}", Environment.ProcessorCount);
            Console.WriteLine();

            //Диски
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сведения о хранилищах:");
            Console.ResetColor();
            foreach (DriveInfo dI in DriveInfo.GetDrives())
            {
                Console.Write(
                    "\t Диск: {0}\n\t" + 
                    " Формат диска: {1}\n\t " + 
                    "Размер диска (ГБ): {2}\n\t Доступное свободное место (ГБ): {3}\n" 
                    
                    , dI.Name, dI.DriveFormat, (double) dI.TotalSize / 1024 / 1024 / 1024, (double) dI.AvailableFreeSpace / 1024 / 1024 / 1024);
                Console.WriteLine();
            }
        }

    
    }
}