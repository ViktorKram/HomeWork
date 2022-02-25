using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int k; // Количество выполненных заданий
            float HoursWorked = default; // Количество отработанных часов 
            float Avg = default; // Среднее затраченное время на одну задачу

            // Обращаемся к первой записи в логе
            Log.First();

            // Устанавливаем начальное количество выполненных заданий
            k = 0;

            // Цикл по записям лога
            while (!Log.EOF())
            {
                // Если текущую работу выполнил наш пользователь 
                if (Log.Fields("UserName") == User.Name)
                {
                    // Добавим к переменной HoursWorked длительность текущей работы
                    HoursWorked += Log.Fields("Duration");
                    k++;
                }

                // Перейдем к следующей записи лога
                Log.Next();
            }

            // Переведем общую длительность работ из минут в часы 
            HoursWorked /= 60;

            // Вычислим среднюю длительность работ (кол-во затраченных часов / кол-во выполненных заданий)
            Avg = HoursWorked / k;

            // Зададим свойства отчета 
            Report.Fields("UserField1") = User.Name;
            Report.Fields("UserField2") = HoursWorked.ToString() + Avg.ToString() + " ч./работу";
            Report.Fields("Title") = "Отчет по отработанному времени";
            Report.Fields("ViewScale") = "80%";
            Report.Fields("LeftMargin") = "2см";
            Report.Fields("RightMargin") = "1см";
            Report.Fields("TopMargin") = "1см";
            Report.Fields("BottomMargin") = "1см";
        }        
    }
}



