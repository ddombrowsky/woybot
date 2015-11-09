/*
 *
 */
using System.Collections.Generic;

public class Sensor: Cell {
    public Sensor(IClockDown c): base(c)
    {
        m_outputs = new List<Axon>();
    }

    public void add_cell(Cell c)
    {
        Axon n = new Axon();
        n.dst = c;
        n.src = this;
        m_outputs.Add(n);
    }

    public void fire_all()
    {
        foreach(Axon a in m_outputs) {
            a.fire();
        }
    }

    protected List<Axon> m_outputs;
}

/**
 *
 * Take sensory input and compare to a set of data of the
 * same size.  For the bytes that match, fire the
 * corresponding output.
 */
public class SensorCompare: Sensor {
    public SensorCompare(IClockDown c): base(c)
    {
    }

    public void compare_input(byte[] input)
    {
        int i;
        for(i = 0; i < input.Length; i++) {
            if(input[i] == m_mask[i]) {
                m_outputs[i].fire();
            }
        }
    }

    public void set_mask(byte[] i, Cell[] outs)
    {
        m_mask = i;
        m_outputs.Clear();
        foreach(Cell c in outs) {
            add_cell(c);
        }
    }

    byte[] m_mask;
}

/**
 *
 * Scan a set of sensory input looking for a specific byte,
 * and fire all outputs every time that byte is found.
 */
public class SensorScan: Sensor {
    public SensorScan(IClockDown c): base(c)
    {
    }

    public byte m_needle { set; get; }

    public void scan_input(byte[] input)
    {
        foreach(byte b in input) {
            if(b == m_needle) {
                fire_all();
            }
        }
    }
}
