﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpITConditionalLab
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  Income Tax Calculator
             *  A simplified progressive income tax uses the following formula:
             *  -5% tax on the first $20,000 of income
             *  -10% tax is owed on income over $20,000
             *  -20% tax is owed on income over $50,000
             *  -35% tax is owed on income over $75,000
             *  
             * ==>problem is to write a program to calculate income tax owed,
             * ==>that takes the income as a command line argument
             */
            if (args.Length < 1)
            {
                //no arguments were passed in
                Console.WriteLine("Sorry, I didn't get income as an argument in whole dollars.");
            }
            else
            {
                //Console.WriteLine(args[0]);       //for debug
                //parse income from arguments
                //assume income is in whole dollars (integer)
                int income;

                if (!(Int32.TryParse(args[0], out income)))
                {
                    //unable to parse a number from (first) argument
                    Console.WriteLine("Sorry, I didn't get recognizaeble income as an argument.");               }
                else
                {
                    //actual recognized input is now stored in income
                    //write out income to show that it was correctly recognized
                    Console.WriteLine("Income Tax Calculation on {0:c}", income);

                    //create and initialize a variable to hold the owed tax amount
                    double taxOwed = 0;
                    
                    //check whether the income meets each bracket level in turn
                    if (income > 75000)
                    {
                        //base tax on 75000 is 9000 (1000 + 3000 + 5000)
                        //add that to the marginal tax on income over $75000 at 35%
                        taxOwed = 9000 + (double)(income - 75000) * 0.35;
                    } else if (income > 50000)
                    {
                        //base tax on 50000 is 4000 (1000 + 3000)
                        //add that to the marginal tax on income over $50000 at 20%
                        taxOwed = 4000 + (double)(income - 50000) * 0.20;
                    }
                    else if (income > 20000)
                    {
                        //base tax on 20000 is 1000
                        //add that to the marginal tax on income over $20000 at 10%
                        taxOwed = 1000 + (double)(income - 20000) * 0.10;
                    }
                    else
                    {
                        //income is less than $20,000 and taxed at 5%
                        taxOwed = (double)(income) * 0.05;
                    }

                    Console.WriteLine();
                    Console.WriteLine("Tax owed is {0:c}.", taxOwed);
                }
            }

            Console.WriteLine();    //whitespace
            Console.WriteLine();    //whitespace
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            
        }
    }
}