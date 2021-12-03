using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;//подключаем пространство имен

namespace dz20
{
    class Program
    {

        static int[,] garden;
        static int a;
        static int b;





        static void Main(string[] args)
        {
            Console.WriteLine("Введите ширину поля ");       //исходные данные
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите длину поля");
            b = Convert.ToInt32(Console.ReadLine());
            garden = new int[a, b];                      //Создаем поле 

            Thread Gardener1 = new Thread(gardener1);//для первого садовника
            Thread Gardener2 = new Thread(gardener2);// для второго садовника

            Gardener1.Start();//Запускаем первый поток
            Gardener2.Start();//Запускаем второй поток

            Gardener1.Join();
            Gardener2.Join();

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(garden[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void gardener1()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (garden[i, j] == 0)
                        garden[i, j] = 1;
                    Thread.Sleep(1);
                }

            }

        }
        static void gardener2()
        {
            for (int i = a - 1; i >= 0; i--)//проход в обратном порядке
            {
                for (int j = b - 1; j >= 0; j--)
                {
                    if (garden[j,i] == 0)
                        garden[j,i] = 2;
                    Thread.Sleep(1);

                }

            }

        }


    }
}
