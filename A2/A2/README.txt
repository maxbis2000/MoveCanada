Move Canada
Software Test Engineer 
Homework Assignment 
February 2012

Solution A2

Author:	Pavel Shabalin
Date:	10 March 2012

WHAT IS IT?
----------------------
Program (A) that tests another program (B) designed to accept
a N by M grid of numbers and determines if all the rows and all the 
columns sum up to the same value.

This solution executes a single test that it reads from a test.txt file.

CONTENTS:
----------------------
Program.cs - main programs
B.exe - dummy program from Solution A that reads Bout.txt and outputs it to the console
test.txt - test sample. contains tested matrix and expected output.
			matrix is set by integers divided by space
			output is a single word "yes" or "no"
			no empty lines allowed
Bout.txt - output for the B.exe
			contains a single word - "yes" or "no"

BUILD:
----------------------
Compile A2 project. Put A2.exe, B.exe and test.txt Bout.txt to the same directory.

test.txt has a matrix followed by an expected output (yes/no)

RUN: 
----------------------
edit test.txt
edit Bout.txt

Run >A.exe B.exe

A.exe reads the test from test.txt and compares the result to the B.exe output.

OUTPUT: 
----------------------
Test results

COMMENTS:
----------------------

See README.txt for Solution A