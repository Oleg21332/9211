using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace _9211
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.InitLogger();
            Logger.Log.Info("Запуск программы.");
            try
            {
                int M1 = 0; int M2 = 0; int M3A = 0; int M3B = 0;
                Console.WriteLine("Введите длину цепочки: ");
                int N = Convert.ToInt32(Console.ReadLine());
                if (N > 2)
                {
                    Console.WriteLine("Длина цепочки равна " + N);
                }
                else
                {  
                    Console.WriteLine("Длина цепочки не может быть меньше 3х");
                }
             
                Logger.Log.Info($"Prog: Получена длина цепочки, она есть {N}");
                Console.WriteLine("Введите последовательность чисел, разделяя их клавишей Enter: ");
                for (int i = 0; i < N; i++)
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    Logger.Log.Info($"Prog: Получен элемент последовательности, он есть {input}");
                    if ((input % 3 == 0) & (input > M3A))
                    {
                        if (M3A > M3B) { M3B = M3A; M3A = input; }
                    }
                    else
                    {
                        if (input > M3B) { M3B = input; }
                    }
                }
                Console.WriteLine("Введите контрольное число: ");
                int control = Convert.ToInt32(Console.ReadLine());
                Logger.Log.Info($"Prog: Получено контрольное число, оно есть {control}");
                int result;
                if ((M1 + M2) < (M3A + M3B)) { result = M3A + M3B; }
                else { result = M1 + M2; }
                Console.WriteLine($"Вычисленное контрольное значение: {result}");
                if (control == result) { Console.WriteLine("Контроль пройден"); Logger.Log.Info("Prog: Контроль пройден"); }
                else { Console.WriteLine("Контроль не пройден"); Logger.Log.Info("Prog: Контроль не пройден"); }
                Console.ReadKey();
            }
            catch
            {
                Logger.Log.Info("Программа аварийно завершилась.");
            }
            finally
            {
                Logger.Log.Info("Конец программы.");
            }
        }
    }
}
namespace _9211
{

    public static class Logger
    {
        private static ILog log = LogManager.GetLogger("LOGGER");


        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}