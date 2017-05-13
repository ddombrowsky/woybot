/*
 *
 */

using System.Collections.Generic;

/**
 *
 * When this cell receives an upcharge, it outputs
 * a specific command string to the output queue.
 */
public class OutputCell: Cell {
    public OutputCell(Queue<string> output, string cmd, IClockDown c): base(c)
    {
        m_output = output;
        m_cmd = cmd;
    }

    public override int upcharge()
    {
        m_output.Enqueue(m_cmd);
        return 0;
    }


    Queue<string> m_output;
    string m_cmd;
}
