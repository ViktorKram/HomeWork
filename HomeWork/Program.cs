using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            //Обращаемся к первой записи в логе
            Log.First();

            k = 0;

            // Цикл по записям лога
            while (!Log.EOF())
            {
                //Если текущаю работу выполнил наш пользователь 
                if (Log.Fields("UserName") == User.Name)
                {
                    // Добавим к переменной HoursWorked длительность текущей работы
                    HoursWorked += Log.Fields("Duration");

                    k++;
                }
                //Перейдем к следующей записи лога
                Log.Next();
            }

            HoursWorked = HoursWorked / 60;
            Avg = HoursWorked / k;
        }
    }
}
