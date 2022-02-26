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

        static string DistributeTheAmount(string option, double sum, string proportions)
        {
            if (double.IsNaN(sum))
                throw new ArgumentException("Your sum is NaN.");
            else if (double.IsPositiveInfinity(sum))
                throw new ArgumentException("Your sum is positive infinity.");
            else if (sum < 0)
                throw new ArgumentException("Your sum is less than zero.");
            else
            {
                StringBuilder result = new StringBuilder();
                List<string> finalSums = new List<string>();
                double[] propArray = proportions.Split(';').Select(x => double.Parse(x)).ToArray();

                switch (option)
                {
                    // Разработаем сценарий для пропорционального распределения суммы.
                    case "ПРОП":
                        // Определим общую сумму значений из списка пропорций.
                        double proportionSum = 0;

                        foreach (double prop in propArray)
                        {
                            proportionSum += prop;
                        }

                        // Определим количество денег, соответствующей 1 единице пропорций.
                        double moneyProportion = sum / proportionSum;

                        // Для каждой, кроме последней пропорции из списка найдем соответствующую сумму и добавим ее в список,
                        // округляя до копеек (сотых).
                        for (int i = 0; i < propArray.Length - 1; i++)
                        {
                            finalSums.Add((moneyProportion * propArray[i]).ToString("#.##"));
                        }

                        // Определим оставшуюся сумму.  
                        foreach (string pSum in finalSums)
                        {
                            sum -= double.Parse(pSum);
                        }

                        // Добавим остаток как последнее значение списка.
                        finalSums.Add(sum.ToString());

                        // Передадим значения из списка в строку на вывод.
                        foreach (string lSum in finalSums)
                        {
                            result.Append(lSum + ";");
                        }

                        //Вернем строку, удалив в конце ";". 
                        return result.Remove(result.Length - 1, 1).ToString();

                    case "ПЕРВ":
                        //Начнем заполнять результирующую строку максимальными значениями с начала списка.
                        for (int i = 0; i < propArray.Length; i++)
                        {
                            // Если кол-во оставшихся денег меньше или равно значению в списке, добавляем остатки и устанавливаем количество денег в ноль.
                            if (sum <= propArray[i])
                            {
                                finalSums.Add(sum.ToString());
                                sum = 0;
                            }
                            // Иначе, добавляем значение из списка в результат и вычитаем это значение из общего кол-ва денег.
                            else
                            {
                                finalSums.Add(propArray[i].ToString());
                                sum -= propArray[i];
                            }
                        }

                        // Передадим значения из списка в строку на вывод.
                        foreach (string lSum in finalSums)
                        {
                            result.Append(lSum + ";");
                        }

                        //Вернем строку, удалив в конце ";". 
                        return result.Remove(result.Length - 1, 1).ToString();

                    case "ПОСЛ":
                        //Начнем заполнять результирующую строку максимальными значениями с конца списка.
                        for (int i = propArray.Length - 1; i >= 0; i--)
                        {
                            // Если кол-во оставшихся денег меньше или равно значению в списке, добавляем остатки и устанавливаем количество денег в ноль.
                            if (sum <= propArray[i])
                            {
                                finalSums.Add(sum.ToString());
                                sum = 0;
                            }
                            // Иначе, добавляем значение из списка в результат и вычитаем это значение из общего кол-ва денег.
                            else
                            {
                                finalSums.Add(propArray[i].ToString());
                                sum -= propArray[i];
                            }
                        }

                        finalSums.Reverse();

                        // Передадим значения из списка в строку на вывод.
                        foreach (string lSum in finalSums)
                        {
                            result.Append(lSum + ";");
                        }

                        //Вернем строку, удалив в конце ";". 
                        return result.Remove(result.Length - 1, 1).ToString();
                }
            }

            return "Invalid option. Please, try again.";
        }
    }
}
