Move Canada
Software Test Engineer 
Homework Assignment 
February 2012

Solution A

Author:	Pavel Shabalin
Date:	10 March 2012

WHAT IS IT?
----------------------
Program (A) that tests another program (B) designed to accept
a N by M grid of numbers and determines if all the rows and all the 
columns sum up to the same value.

This solution has a number of tests that it runs to test functionality
of program B.

CONTENTS:
----------------------
Program.cs - main programs
TestCases.cs - all test cases
A.exe - executable file for the project
B.exe - dummy program that reads Bout.txt and outputs it to the console
Bout.txt - output for the B.exe
			contains a single word - "yes" or "no"

BUILD:
----------------------
Compile A and B projects. Put A.exe, B.exe and Bout.txt to the same directory.


RUN: 
----------------------
edit Bout.txt

Run >A.exe B.exe

A.exe runs all the tests and compares the result to the B.exe output

OUTPUT: 
----------------------
Test results


COMMENTS:
----------------------

In order to make A.exe fully functional I would need to know how the data is supplied to
B.exe. Then it is possible to pass the same matrix to A.exe and B.exe and compare
expected results.

Couple more tests could be added:

1. Check if B.exe handles the passing values
	a. if values are int
	b. if values are in range

2. Check if the matrix of the maximum size is processed correctly


