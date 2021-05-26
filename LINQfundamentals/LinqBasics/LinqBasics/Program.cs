using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LinqBasics
{
    class Program
    {
        static void Main(string[] args)
        { //list the files in descending order using c#
            string path = @"C:\windows";
            ShowLargeFilesWithoutLinq(path);
            ShowLargeFilesWithLinq(path);
        }
        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file; // or new DirectoryInfo(path).GetFiles().OrderByDescending(f=>f.Length).Take(5);
            foreach (var file in query.Take(5))//just take 5 items
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }
        }
        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());

            for(int i=0; i<5; i++)
            {
                FileInfo file = files[i];
                //Console.WriteLine($"{file.Name, -20} : {file.Length, 10:N0}");
            }
        }
    }
    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            //throw new NotImplementedException();
            return y.Length.CompareTo(x.Length);
        }
    }
}
