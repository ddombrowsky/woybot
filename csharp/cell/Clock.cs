/*
 *
 */

using System.Collections;
using System.Collections.Generic;

public interface IClockDown {
    void addTick(IDecayable d);
}


public class MindClock: IClockDown {
    public MindClock()
    {
        m_excited = new Hashtable();
    }

    public void addTick(IDecayable d){
        if(!m_excited.ContainsKey(d)) {
            m_excited.Add(d, 1);
        }
    }

    public void cycle()
    {
        List<IDecayable> toremove = new List<IDecayable>();

        foreach(DictionaryEntry k in m_excited) {
            IDecayable cell = (IDecayable)k.Key;
            if(cell.decay() <= 0) {
                // remove cells that have decayed to 0
                toremove.Add(cell);
            }
        }

        if(toremove.Count > 0) {
            foreach(Cell c in toremove) {
                m_excited.Remove(c);
            }
        }
    }

    private Hashtable m_excited;
}

