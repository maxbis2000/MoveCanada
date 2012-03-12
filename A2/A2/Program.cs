using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace A2
{
    class Program
    {
        // test case content
        private struct testCase
        {
            public List<string> matrix;
            public string output;
        };

        static void Main(string[] args)
        {

            //
            // CREATE TEST CASE
            //

            testCase test = new testCase();
            test.matrix = new List<string>();
            test.output = "";
            
            try
            {
                // Rread from a file.
                using (StreamReader sr = new StreamReader("test.txt"))
                {
                    String line;
                    // Read the matrix line by line
                    while (((line = sr.ReadLine()) != null) &&
                        (!line.ToLower().Contains("yes")) &&
                        (!line.ToLower().Contains("no")))
                    {
                        test.matrix.Add(line);
                    }

                    // Read expected output
                    if (line.ToLower().Contains("yes") ||
                        line.ToLower().Contains("no"))
                    {
                        test.output = line.Trim().ToLower();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }


            // check that the test was setup correctly
            if (String.IsNullOrEmpty(test.output) ||
                (test.matrix.Count == 0))
            {
                Console.WriteLine("Test was not setup correctly");
                Environment.Exit(-1);
            }


            //
            // RUN THE TEST
            //

            // prepare to run B.exe and get its output
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c ";
            p.StartInfo.Arguments += args[0];
            //p.StartInfo.Arguments += "B.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            
            // start the process
            p.Start();
            string output = p.StandardOutput.ReadLine();
            output.Trim();
            p.WaitForExit(); // can set max time to wait here and mark test as failed if limit is reached

            // check the output
            if (output.Equals(test.output))
            {
                Console.WriteLine("ok"); 
            }
            else
            {
                Console.WriteLine("not ok:");

                // output the matrix
                foreach (string s in test.matrix)
                    Console.WriteLine(s);

                Console.WriteLine("returned: " + output);
                Console.WriteLine("expected: " + test.output);
            }           
        
        }
    }
}
