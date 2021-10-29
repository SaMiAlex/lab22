using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab22
{
    class Program
    {
        static int N;
        static int[,] t;
        static void Main(string[] args)
        {
            Console.WriteLine("Введите сторону квадрата");
            N = Convert.ToInt32(Console.ReadLine());
            t = new int[N, N];
            Random random = new Random();
            #region//Формирование массива
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    t[i, j] = random.Next(10);
                    Console.Write("{0} ", t[i, j]);
                }
                Console.WriteLine();
            }
            #endregion

            Action action = new Action(calcSum);
            Action<Task> actiontask = new Action<Task>(calcMax);
            Task task1 = new Task(action);
            Task task2 = task1.ContinueWith(actiontask);
            task1.Start();            
            Console.ReadKey();
        }
        static void calcSum()
        {
            int s = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    s += t[i, j];
                    Thread.Sleep(10);
                }
            }
            Console.WriteLine($"Сумма чисел массива равна {s}");
        }
        static void calcMax(Task task)
        {
            int s = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (t[i, j]>s)
                    {
                        s = t[i, j];
                        Thread.Sleep(10);
                    }                    
                }
            }
            Console.WriteLine($"Максимальное число массива равно {s}");
        }
    }
}
