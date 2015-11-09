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
            System.Console.WriteLine("-----");
            test2();
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
            System.Console.WriteLine("a -> " + a + " (?9)");
            System.Console.WriteLine("b -> " + b + " (?9)");

            // decay (there could be a thread somewhere 
            // running this loop with a delay)
            for(int i=0; i<5; i++) {
                clk.cycle();
            }
            System.Console.WriteLine("a -> " + a + " (?4)");
            System.Console.WriteLine("b -> " + b + " (?4)");

            for(int i=0; i<99; i++) {
                clk.cycle();
            }
            System.Console.WriteLine("a -> " + a + " (?0)");
            System.Console.WriteLine("b -> " + b + " (?0)");

        }

        //
        // test 2:
        // test sensors
        static void test2()
        {
            MindClock clk = new MindClock();
            SensorScan ss = new SensorScan(clk);
            SensorCompare sc = new SensorCompare(clk);
            Cell a = new Cell(clk);
            Cell b = new Cell(clk);
            Cell[] outs = new Cell[5]{
                new Cell(clk), 
                new Cell(clk),
                new Cell(clk),
                new Cell(clk),
                new Cell(clk)
            };

            ss.m_needle = 0xa;
            byte[] data = {0xa,0xa,0xa,0xa,0xa};
            ss.add_cell(a);
            ss.add_cell(b);
            ss.scan_input(data);

            System.Console.WriteLine("a -> " + a + " (?5)");
            System.Console.WriteLine("b -> " + b + " (?5)");

            sc.set_mask(data, outs);
            byte[] cmpdata = {0xa,0xb,0xa,0xa,0xa};
            int[] res = {1, 0, 1, 1, 1};
            sc.compare_input(cmpdata);
            for(int i = 0; i < outs.Length; i++) {
                Cell o = outs[i];
                System.Console.WriteLine("o -> " + o + " (?" + res[i] + ")");
            }

        }
    }
}
