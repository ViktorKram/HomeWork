using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        static string DistributeTheAmount(string option, double moneyAmount, string sumList)
        {
            StringBuilder result = new StringBuilder();
            double[] sumsFromList = sumList.Split(';').Select(x => double.Parse(x)).ToArray();
            
            switch (option)
            {
                case "ПРОП":
                    // Определим общую сумму значений из списка сумм.
                    double sumListTotal = 0;

                    foreach (double s in sumsFromList)
                    {
                        sumListTotal += s;
                    }

                    // Найдем количество денег, соответствующей 1 единице пропорции.
                    double singleCount = moneyAmount / sumListTotal;

                    // Для каждой, кроме последней, суммы из списка найдем пропорциональное выражение и добавим его в результирующую строку.
                    for (int i = 0; i < sumsFromList.Length - 1; i++)
                    {
                        result.Append((singleCount * sumsFromList[i]).ToString("#.##") + ";");

                    }

                    // Округлим остаток от суммы. 
                    double remains = sumsFromList[sumsFromList.Length]
                    // Добавим округленное последнее значение в конец результирующей строки. 
                    result.Append()

                    // Вернем результат в виде строки с удаленным последним символом ";".
                    return result.Remove(result.Length - 1, 1).ToString();

                case "ПЕРВ":
                    //Начнем заполнять результирующую строку максимальными значениями с начала списка.
                    for (int i = 0; i < sumsFromList.Length; i++)
                    {
                        // Если кол-во оставшихся денег меньше или равно значению в списке, добавляем остатки и устанавливаем количество денег в ноль.
                        if (moneyAmount <= sumsFromList[i])
                        {
                            result.Append(moneyAmount.ToString("#.##") + ";");
                            moneyAmount = 0;
                        }
                        // Иначе, добавляем значение из списка в результат и вычитаем это значение из общего кол-ва денег.
                        else
                        {
                            result.Append(sumsFromList[i].ToString("#.##") + ";");
                            moneyAmount -= sumsFromList[i];
                        }
                    }
                    // Вернем результат в виде строки с удаленным последним символом ";".
                    return result.Remove(result.Length - 1, 1).ToString();

                case "ПОСЛ":
                    //Начнем заполнять результирующую строку максимальными значениями с конца списка.
                    for (int i = sumsFromList.Length - 1; i >= 0; i--)
                    {
                        // Если кол-во оставшихся денег меньше или равно значению в списке, добавляем остатки и устанавливаем количество денег в ноль.
                        if (moneyAmount <= sumsFromList[i])
                        {
                            result.Append(moneyAmount.ToString("#.##") + ';');
                            moneyAmount = 0;
                        }
                        // Иначе, добавляем значение из списка в результат и вычитаем это значение из общего кол-ва денег.
                        else
                        {
                            result.Append(sumsFromList[i].ToString("#.##") + ";");
                            moneyAmount -= sumsFromList[i];
                        }
                    }
                    // Вернем результат в виде строки с удаленным последним символом ";".
                    return result.Remove(result.Length - 1, 1).ToString();
            }

            return "";
        }
    }
}
