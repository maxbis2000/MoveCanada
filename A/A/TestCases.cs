using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace A
{
    class TestCases
    {

        // test case structure
        private struct testCase
        {
            public string name;     // test name
            public int[,] matrix;   // tested matrix
            public string output;   // expected output
        };

        private Process p;
        private List<testCase> tests;

        public TestCases(Process aProcess)
        {
            p = aProcess;
            tests = new List<testCase>();

            //
            // SET UP TEST CASES
            //

            // test null - what is the expected output?
            tests.Add(new testCase() { name = "Test null - YES", matrix = null, output = "yes"});

            // test zero - OK
            tests.Add(new testCase() { name = "Test zero - YES", matrix = new int[1, 1] { { 0 } }, output = "yes" } );

            // test 1x1 - OK
            tests.Add(new testCase() { name = "Test 1x1 - YES", matrix = new int[1,1] { {1} }, output = "yes" } );

            // test 2x2 - OK
            tests.Add(new testCase() { name = "Test 2x2 - YES", matrix = new int[2, 2] {   
            {1, 2},
            {2, 1} }, output = "yes" } );
            
            // test 2x2 - NOT OK
            tests.Add(new testCase() { name = "Test 2x2 - NO", matrix = new int[2, 2] {
            {1, 2},
            {2, 3} }, output = "no" } );

            // test nxm - NOT OK
            tests.Add(new testCase() { name = "Test nxm - NO", matrix = new int[2, 3] {
            {1, 3, 3},
            {6, 4, 2} }, output = "no" } );

            // test negative 1x1 - OK
            tests.Add(new testCase() { name = "Test negative 1x1 - YES", matrix = new int[1, 1] { { -1 } }, output = "yes" });

            // test negative 2x2 - YES
            tests.Add(new testCase() { name = "Test negative 2x2 - YES", matrix = new int[2, 2] {
            {1, -1},
            {-1, 1} }, output = "yes" } );

            // test negative 2x2 - NO
            tests.Add(new testCase() { name = "Test negative 2x2 - NO", matrix = new int[2, 2] {
            {1, -2},
            {-2, 3} }, output = "no" } );

            // load / stress / performance tests. 
            // What is the biggest input that B.exe can handle?
            // Will need to add tests for upper bounds
            try
            {
                int[,] m = new int[Int32.MaxValue, Int32.MaxValue];
                for (int i = 0; i < Int32.MaxValue; i++)
                    for (int j = 0; j < Int32.MaxValue; j++)
                        m[i, j] = 1;
                tests.Add(new testCase() { name = "Test max matrix - YES", matrix = m, output = "yes" });
            }
            catch (Exception e) // could be outofmemory exception
            {
                Console.WriteLine(e.Message);
            }
        }

        // Runs all the tests
        // Return:  true - all tests pass
        //          false - some tests fail
        public bool RunTests()
        {
            bool result = true;

            foreach (testCase t in tests)
            {
                Console.WriteLine("------------");
                Console.WriteLine(t.name);

                try
                {
                    // start the process
                    p.Start();
                    string output = p.StandardOutput.ReadLine();
                    output.Trim();
                    p.WaitForExit(); // can set max time to wait here and mark test as failed if limit is reached

                    // check the output
                    if (output.Equals(t.output))
                    {
                        Console.WriteLine("ok"); 
                    }
                    else
                    {
                        result = false;
                        Console.WriteLine("not ok:");

                        // output the matrix
                        if (t.matrix == null)
                        {
                            Console.WriteLine("matrix is NULL");
                        }
                        else
                        {
                            // output matrix
                            for (int i = 0; i < t.matrix.GetLength(0); i++)
                            {
                                for (int j = 0; j < t.matrix.GetLength(1); j++)
                                    Console.Write(t.matrix[i, j] + " ");
                                Console.WriteLine();
                            }
                        }
                        Console.WriteLine("returned: " + output);
                        Console.WriteLine("expected: " + t.output);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("TEST EXCEPTION");
                    Console.WriteLine(e.Message);
                    result = false;
                }
            }

            Console.WriteLine("------------");
            return result;
        }

    }
}
