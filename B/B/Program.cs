using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("Bout.txt"))
                {
                    String line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    if ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line.ToLower());
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
