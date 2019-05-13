using Xunit;
using DotNetCoreKoans.Engine;
using System.Collections.Generic;
using System;

namespace DotNetCoreKoans.Koans
{
    public class AboutBitwiseAndShiftOperator : Koan
    {
        [Step(1)]
        public void BinaryAndOperator()
        {
            //Example
            //1 in binary is 0001
            //3 in binary is 0011
            //4 in binary is 0100
            //With & only taking the same one else take 0,so 1 & 3 it becomes 0001.
            //Takes a 1 for a position only if both have a 1 in that position
            //When 0001 convert to int it becomes 1
            int x = 4 & 4;

            Assert.Equal(4, x);
        }

        [Step(2)]
        public void BinaryOrOperator()
        {
            //Example
            //1 in binary is 0001
            //3 in binary is 0011
            //4 in binary is 0100
            //With | it will take a 1 for a position if either contains 1,so 1 & 3 it becomes 0011.
            //When 0011 convert to int it becomes 3
            int x = 4 | 4;

            Assert.Equal(4, x);
        }

        [Step(3)]
        public void BinaryXOrOperator()
        {
            //Example
            //1 in binary is 0001
            //3 in binary is 0011
            //4 in binary is 0100
            //With ^ it will take 1 when it is 0-1, if it is 1-1 it will take 0,so 1 & 3 it becomes 0010.
            //When 0010 convert to int it becomes 2

            // 0100 ^ 0100 = 0000
            int x = 4 ^ 4;

            Assert.Equal(0, x);
        }

        [Step(4)]
        public void BinaryOnesComplementOperator()
        {
            //Example
            //With ~ it will convert positive number to negative number and add -1 to the number.
            // ~1 become -2
            int x = ~4;

            Assert.Equal(-5, x);
        }

        [Step(5)]
        public void Combination1()
        {
            int x = ~3 & 8;

            // -4 & 8
            // 1011 & 1000 = 1000
            // https://ryanstutorials.net/binary-tutorial/binary-negative-numbers.php
			Assert.Equal(8, x);
        }

        [Step(6)]
        public void Combination2()
        {
            int x = 4 | 4 & 8;
            // 0100 | 0100 & 1000
            // 0100 | 0000
            // 0100
            Assert.Equal(4, x);
        }

        [Step(7)]
        public void Combination3()
        {
            int x = 3 & 4 ^ 4 & ~8;
            //0011 & 0100 ^ 0100 & 0110
            //0010 ^ 0100
            //0100
            Assert.Equal(4, x);
        }

        [Step(8)]
        public void BitwiseLeftShift()
        {
            //Example
            //4 in binary is 0100
            //when we try to 4 << 1
            //it becomes 1000
            //then it will become 8
            int x = 10 << 2;
            //10 = 1010
            //101000 = 40

            Assert.Equal(40, x);
        }

        [Step(9)]
        public void BitwiseRightShift()
        {
            //Example
            //4 in binary is 0100
            //when we try to 4 >> 1
            //it becomes 0010
            //then it will become 2
            int x = 12 >> 2;
            //12 = 1100
            //0011 =
            Assert.Equal(3, x);
        }

        [Step(10)]
        public void Combination4()
        {
            int x = (5 << 2) & 8 ^ 3;
            //(0101 << 2) & 1000 ^ 0011
            //10100 & 1000 ^ 0011
            //1000 ^ 0011
            //0011

            Assert.Equal(3, x);
        }

        [Step(11)]
        public void Combination5()
        {
            int x = (5 >> 2) & (~8) ^ 8;
            // (0101 >> 2) & -9 ^ 1000;
            // (0001) & -9 ^ 1000;
            // (0001) & 11110110 ^ 1000;
            // (calculate (0001) & 11110110 first) = 0001;
            // 0001 ^ 1000;
            // 1001;
            // 9

            Assert.Equal(9, x);
        }

        [Step(12)]
        public void Combination6()
        {
            int x = (8 << 2) & (~5) & 8 | 10 | (5 >> 1);
            //(1000 << 2) & (-6) & 1000 | 1010 | (0101 >> 1);
            //(100000) & (-6) & 1000 | 1010 | (0010)
            //100000 & 11111001 & 1000 | 1010 | 0010
            //100000 & 1000 | 1010 | 0010
            //1000 | 1010 | 0010
            //1010 | 0010
            //1010
            //10

            Assert.Equal(10, x);
        }

        [Step(13)]
        public void AdditionWithoutPlusOrMinusOperator()
        {
            //Solve this problem without using + or -
            //This is a complicated problem. If you don't
            //know how to solve it, try to Google it.
            int a = 15;
            int b = 4;

            //Here goes your implementation to set value to FILL_ME_IN
            // 15 = 1111; 4 = 0100; 19 = 10011;
            //  1111
            //  0100 +
            // 10011

            // int sum = (a ^ b); // add all 1 columns at the same time
            // int carry = (a & b) << 1; // all columns with 1 carry 1 to the left.
            // int x = sum + carry; add the carried over 1's to the original sum.

            // without the + operator https://stackoverflow.com/a/21092508/9382032
            int Add(int num1, int num2)
            {
                // while there are numbers to carry
                while(num2 != 0)
                {
                    int carry = num1 & num2; //columns with 1's == columns with carries
                    // https://www.bbc.com/bitesize/guides/zjfgjxs/revision/2 -- notes on adding binaries
                    num1 = num1 ^ num2; // add all the columns at the same time
                    num2 = carry << 1; // shift all the carried 1's one column to the left + repeat algorithm
                }
                //when no carries are left all columns are added correctly
                return num1;
            }
            int x = Add(a, b);
            Assert.Equal(x, 19);
        }
    }
}
