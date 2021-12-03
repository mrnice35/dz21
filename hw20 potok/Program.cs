using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace hw20_potok
{
    class Program
    {
        static int[,] pole;
        static int a;
        static int b;

        static void Main()
        {
            Console.WriteLine("Введите ширину поля");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите высоту поля");
            b = Convert.ToInt32(Console.ReadLine());

            pole = new int[a, b];

            Thread sadov1 = new Thread(sad1);//Создаем экземпляр класса для первого садовника
            Thread sadov2 = new Thread(sad2);//Создаем экземпляр класса для второго садовника

            sadov1.Start();//Запускаем первый поток
            sadov2.Start();//Запускаем второй поток

            sadov1.Join();
            sadov2.Join();

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(pole[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
            Console.ReadKey();
        }

        private static void sad1()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (pole[i, j] == 0)
                        pole[i, j] = 1;

                    Thread.Sleep(1);
                }
            }
        }

        private static void sad2()
        {
            for (int i = a - 1; i > 0; i--)
            {
                for (int j = b - 1; j > 0; j--)
                {
                    if (pole[j, i] == 0)
                        pole[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}

