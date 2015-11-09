
/*
 * Represents a Cell.
 *
 * A cell has multiple input axons and one
 * output axon.
 */

public interface IDecayable {
    int decay();
}

public interface IChargeable {
    int upcharge();
}

public class Cell: IDecayable, IChargeable {
    public Cell(IClockDown c)
    {
        m_charge = 0;
        m_counter = c;
        m_output = new Axon();
        m_output.src = this;
    }
    public int decay()
    {
        if(m_charge > 0) {
            m_charge--;
        }
        return m_charge;
    }
    public int upcharge()
    {
        m_charge++;
        if(m_charge >= 10) {
            discharge();
        } else {
            m_counter.addTick(this);
        }

        return m_charge;
    }

    public void discharge()
    {
        if(m_output != null) {
            m_output.fire();
        }
        m_charge = 0;
    }

    public void connect_output(Cell c)
    {
        m_output.dst = c;
    }

    public override string ToString()
    {
        return string.Format("{0,9:X}: c:{1}", GetHashCode(), m_charge);
    }

    private Axon m_output;
    private int m_charge;
    private IClockDown m_counter; 
}

