using System;
using System.IO;

namespace Ex7
{
    public class WriteTextToFile : IWriteText
    {
        public void WriteText(string text)
        {
            string folderPath;
            string fileName;
            do
            {
                Console.Write("Enter full path of a folder: ");
                folderPath = Console.ReadLine();
            } while (string.IsNullOrEmpty(folderPath));
            if (new DirectoryInfo(folderPath).Exists == false) Directory.CreateDirectory(folderPath);
            do
            {
                Console.Write("Enter file name (including extension): ");
                fileName = Console.ReadLine();
            } while (string.IsNullOrEmpty(fileName));

            var filePath = folderPath + "\\" + fileName;
            File.WriteAllText(filePath, text);
            FileInfo f = new FileInfo(filePath);
            var fullPath = f.FullName;
            Console.WriteLine($"Text has been written to {fullPath}");
            Console.WriteLine();
        }
    }
}