using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Написать функцию OR(p,q) = p OR q 
             * 
             * Ниже представлена таблица сложения логических значений OR, где 0 - это ложь, а 1 - правда. 
             * Так как для реализации операции логического сложения нам необходимо три функции,
             * первая из которых представляет результат, а две остальные - аргументы, то общее выражение будет иметь подобный вид.
            P Q

            0 0(L x y.y)(L x y.y)(L x y.y) => p p q
            0 1(L x y.y)(L x y.y)(L x y.x) => p p q
            1 0(L x y.x)(L x y.x)(L x y.y) => p p q
            1 1(L x y.x)(L x y.x)(L x y.x) => p p q

             * И на языке L функция OR будет иметь следующий вид:
            OR = L p q. p p q;
            */
        }
    }
}
