/*
 *
 */
using System.Collections.Generic;

public class Sensor: Cell {
    public Sensor(int n_size, int pos, IClockDown c): base(c)
    {
        m_input = new byte[n_size];
        m_position = pos;
    }

    public void add_cell(Cell c)
    {
        Axon n = new Axon();
        n.dst = c;
        n.src = this;
        m_outputs.Add(n);
    }

    public void copy_input(byte[] i)
    {
    }

    private List<Axon> m_outputs;
    byte[] m_input;
    int m_position;
}
