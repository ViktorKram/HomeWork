using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Распределяет указанную сумму согласно выбранной опции и полученным значениям.
        /// Опции: ПРОП (пропорционально), ПЕРВ (в счет первых), ПОСЛ (в счет последних).
        /// </summary>
        /// <param name="option"></param>
        /// <param name="sum"></param>
        /// <param name="values"></param>
        /// <returns>Строка с частями суммы, разделенными ";".</returns>
       public static string DistributeTheSum(string option, double sum, string values)
        {
            if (double.IsNaN(sum))
                throw new ArgumentException("Your sum is NaN.");
            else if (double.IsPositiveInfinity(sum))
                throw new ArgumentException("Your sum is positive infinity.");
            else if (sum <= 0)
                throw new ArgumentException("Your sum is less than or equal to zero.");
            else
            {
                StringBuilder result = new StringBuilder();
                List<string> finalSums = new List<string>();
                double[] valuesArray = values.Split(';').Select(x => double.Parse(x)).ToArray();

                switch (option)
                {
                    // Разработаем сценарий для пропорционального распределения суммы.
                    case "ПРОП":
                        // Определим общую сумму переданных значений.
                        double valuesSum = 0;

                        foreach (double innerValue in valuesArray)
                        {
                            valuesSum += innerValue;
                        }

                        // Определим количество денег, соответствующей 1 единице пропорции.
                        double moneyProportion = sum / valuesSum;

                        // Для каждой, кроме последней пропорции из списка найдем соответствующую сумму и добавим ее в список,
                        // округляя до копеек (сотых).
                        for (int i = 0; i < valuesArray.Length - 1; i++)
                        {
                            finalSums.Add((moneyProportion * valuesArray[i]).ToString("#.##"));
                        }

                        // Определим оставшуюся сумму.  
                        foreach (string pSum in finalSums)
                        {
                            sum -= double.Parse(pSum);
                        }

                        // Добавим остаток как последнюю часть суммы.
                        finalSums.Add(sum.ToString());

                        // Передадим значения из списка в строку на вывод.
                        foreach (string innerSum in finalSums)
                        {
                            result.Append(innerSum + ";");
                        }

                        //Вернем строку, удалив в конце ";". 
                        return result.Remove(result.Length - 1, 1).ToString();

                    // Разработаем сценарий для распределения суммы в счет первых значений. 
                    case "ПЕРВ":
                        //Начнем заполнять результирующую строку максимальными значениями с начала списка.
                        for (int i = 0; i < valuesArray.Length; i++)
                        {
                            // Если кол-во оставшихся денег меньше или равно значению в списке, добавляем остатки и устанавливаем количество денег в ноль.
                            if (sum <= valuesArray[i])
                            {
                                finalSums.Add(sum.ToString());
                                sum = 0;
                            }
                            // Иначе, добавляем значение из списка в результат и вычитаем это значение из общего кол-ва денег.
                            else
                            {
                                finalSums.Add(valuesArray[i].ToString());
                                sum -= valuesArray[i];
                            }
                        }

                        // Передадим значения из списка в строку на вывод.
                        foreach (string innerSum in finalSums)
                        {
                            result.Append(innerSum + ";");
                        }

                        //Вернем строку, удалив в конце ";". 
                        return result.Remove(result.Length - 1, 1).ToString();

                    // Разработаем сценарий для распределения суммы в счет последних значений. 
                    case "ПОСЛ":
                        //Начнем заполнять результирующую строку максимальными значениями с конца списка.
                        for (int i = valuesArray.Length - 1; i >= 0; i--)
                        {
                            // Если кол-во оставшихся денег меньше или равно значению в списке, добавляем остатки и устанавливаем количество денег в ноль.
                            if (sum <= valuesArray[i])
                            {
                                finalSums.Add(sum.ToString());
                                sum = 0;
                            }
                            // Иначе, добавляем значение из списка в результат и вычитаем это значение из общего кол-ва денег.
                            else
                            {
                                finalSums.Add(valuesArray[i].ToString());
                                sum -= valuesArray[i];
                            }
                        }

                        // Синхронизируем суммы из списка со значениями из строки.
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

            throw new ArgumentException("Invalid option.");
        }
    }
}
