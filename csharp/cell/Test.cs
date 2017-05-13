/*
 *
 */
using System;
using System.Collections.Generic;

namespace cell
{
    static class MainClass
    {
        static void Main (string[] args)
        {
            test1();
            System.Console.WriteLine("-----");
            test2();
            System.Console.WriteLine("-----");
            test3();
            System.Console.WriteLine("-----");
            test4();
        }

        static void paxon(Axon a)
        {
            dumper(a.dst);
        }
        static void dumper(Sensor s)
        {
            s.foreach_out(paxon);
        }

        static void dumper(Cell c, int level = 0)
        {
            if(c == null) {
                return;
            }
            for(int i = 0; i < level; i++) {
                System.Console.Write(" ");
            }
            System.Console.WriteLine(">"+c);
            c.out_proc(paxon);
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

        //
        // test 3:
        // test outputs
        static void test3()
        {
            MindClock clk = new MindClock();
            Cell a = new Cell(clk);
            Queue<string> q = new Queue<string>();
            OutputCell c = new OutputCell(q, "hello world", clk);

            a.connect_output(c);

            for(int i = 0; i < 11; i++) {
                a.upcharge();
            }
            System.Console.WriteLine("a -> " + a + " (?1)");
            System.Console.WriteLine("q -> " + q.Dequeue());

        }

        //
        // test 4:
        // some random connections
        static void test4()
        {
            const int ncells = 1024;
            Random rnd = new Random();

            MindClock clk = new MindClock();
            SensorScan ss = new SensorScan(clk);

            Cell[] c = new Cell[ncells];

            for(int i = 0; i < ncells; i++) {
                c[i] = new Cell(clk);
            }

            for(int i = 0; i < ncells; i++) {
                c[i].connect_output(c[rnd.Next(ncells)]);
            }

            ss.add_cell(c[rnd.Next(ncells)]);

            dumper(ss);
        }
    }
}
