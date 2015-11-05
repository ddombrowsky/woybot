/*
 *
 */
using System;

namespace cell
{
    static class MainClass
    {
        static void Main (string[] args)
        {
            test1();
        }

        // test 1:
        // Create two notes, load them, then decay them.
        static void test1()
        {
            MindClock clk = new MindClock();
            Cell a = new Cell(clk);
            Cell b = new Cell(clk);

            System.Console.WriteLine("Starting test...");

            a.connect_output(b);

            // load
            for(int i=0; i<99; i++) {
                a.upcharge();
            }
            System.Console.WriteLine("a -> "+a);
            System.Console.WriteLine("b -> "+b);

            // decay (there could be a thread somewhere 
            // running this loop with a delay)
            for(int i=0; i<5; i++) {
                clk.cycle();
            }
            System.Console.WriteLine("a -> "+a);
            System.Console.WriteLine("b -> "+b);

            for(int i=0; i<99; i++) {
                clk.cycle();
            }
            System.Console.WriteLine("a -> "+a);
            System.Console.WriteLine("b -> "+b);

        }
    }
}
