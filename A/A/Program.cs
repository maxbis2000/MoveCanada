using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace A
{
    class A
    {
        static void Main(string[] args)
        {

            //
            // ENVIRONMENT SETUP
            //

            // prepare to run B.exe and get its output
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c ";
            p.StartInfo.Arguments += args[0];
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;


            TestCases tests = new TestCases(p);

            //
            // RUN TESTS
            //
            if (tests.RunTests())
            {
                Console.WriteLine("TESTS PASSED !!!");
            }
            else
            {
                Console.WriteLine("TESTS FAILED !!!"); 
            }

        }
    }
}
