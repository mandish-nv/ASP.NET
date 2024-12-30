using System;
using System.IO; //file handling

//in c#, input output is done by using strean. Stream is a
//sequence of byte. To write on a file StreamWriter class is used
//to read from a file StreamReader class is used

namespace CSIT
{
    class FileHandlingDemo
    {
        public void writeFile()
        {
            //take any string input from user and write to a file
            StreamWriter sw = new StreamWriter("C:\\Users\\Dell\\source\\repos\\CSIT\\CSIT\\a.txt"); //file path
            Console.WriteLine("Enter line of text");
            string data = Console.ReadLine();
            sw.WriteLine(data);
            sw.Flush(); //Clear all temporary buffer
            sw.Close();
        }
        //reading from file
        public void readFile()
        {
            StreamReader sr = new StreamReader("C:\\Users\\Dell\\source\\repos\\CSIT\\CSIT\\a.txt");
            string ans;
            while ((ans = sr.ReadLine()) != null)
            {
                Console.Write (ans);
            }
            sr.Close();

        }
    }
}
