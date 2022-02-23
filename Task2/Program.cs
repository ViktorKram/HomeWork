using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        internal string FormatFilePath(string FilePath, string Mask)
        {
            string Disc;
            string Directory;
            string FileName;
            string Extension;

            // Удалить ведущие и хвостовые пробелы
            FilePath = FilePath.Trim();

            try
            {
                // В полном имени файла FilePath найти: 
                // 1) имя диска (не работает, если FilePath - сетевой путь) 
                Disc = Regex.Match(FilePath, @"^([A-Z]{1}):\\").ToString();

                // 2) директорию
                Directory = Regex.Match(FilePath, @"^[A-Z]{1}:\\(.*)\\[^\\]+").ToString();

                // 3) имя файла
                FileName = Regex.Match(FilePath, @"^[A-Z]{1}:\\.*\\([^\\]+)\.[^\.\\]+$").ToString();

                // 4) расширение файла
                Extension = Regex.Match(FilePath, @"^[A-Z]{1}:\\.*\\[^\\]+\.([^\.\\]+)$").ToString();
            }
            catch (Exception)
            {
                return "";
            }

            // Скомпоновать полученные значения (диск, директорию, имя файла и расширение)
            // в строку, как указано в маске Mask

            // Заменить %D на имя диска
            Mask.Replace("%D", Disc);

            // Заменить %P на путь
            Mask.Replace("%P", FilePath);

            // Заменить %N на имя файла
            Mask.Replace("%N", FileName);

            // Заменить %E на расширение
            Mask.Replace("%E", Extension);

            return Mask;
        }
    }
}
