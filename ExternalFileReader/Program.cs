using System;
using System.IO;

namespace ExternalFileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Directory.CreateDirectory("C:\\Assignment");
                var path = "C:\\Assignment\\newrecords.txt";
                var oldpath = "C:\\Assignment\\records.txt";

                File.Create(path);
                File.WriteAllText(path, ""); //Since the append is in loop these will clear all text on the file when ever run

                foreach (var line in File.ReadAllLines(oldpath))
                {
                    var dMark = line.Split("-")[1];

                    var markUp = new MarkUpgrader();
                    var newMark = markUp.Upgrade(int.Parse(dMark));
                    var newlineContent = line.Split("-")[1] + " - " + newMark;

                    File.AppendAllLines(path, new string[] { line }); // Adding data to new created textfile
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
