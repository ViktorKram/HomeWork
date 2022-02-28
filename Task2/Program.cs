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
            string disc;
            string directory;
            string fileName;
            string extension;
            string result;

            // Удалить ведущие и хвостовые пробелы.
            FilePath = FilePath.Trim();

            try
            {
                // В полном имени файла FilePath найти: 
                // 1) имя диска (не работает, если FilePath - сетевой путь).
                disc = Regex.Match(FilePath, @"^([A-Z]{1}):\\").ToString();

                // 2) директорию.
                directory = Regex.Match(FilePath, @"^[A-Z]{1}:\\(.*)\\[^\\]+").ToString();

                // 3) имя файла.
                fileName = Regex.Match(FilePath, @"^[A-Z]{1}:\\.*\\([^\\]+)\.[^\.\\]+$").ToString();

                // 4) расширение файла.
                extension = Regex.Match(FilePath, @"^[A-Z]{1}:\\.*\\[^\\]+\.([^\.\\]+)$").ToString();
            }
            catch (Exception)
            {
                return "";
            }

            // Скомпоновать полученные значения (диск, директорию, имя файла и расширение)
            // в строку, как указано в маске Mask.
            result = Mask;

            // Заменить %D на имя диска.
            result = result.Replace("%D", disc);

            // Заменить %P на путь.
            result = result.Replace("%P", FilePath);

            // Заменить %N на имя файла.
            result = result.Replace("%N", fileName);

            // Заменить %E на расширение.
            result = result.Replace("%E", extension);

            return result;
        }
    }
}
