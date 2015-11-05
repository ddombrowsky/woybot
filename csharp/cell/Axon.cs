/*
 *
 * Axon, directed connector between two cells.
 */

public class Axon {
    public Axon()
    {
    }

    public Cell src {
        get;
        set;
    }

    public Cell dst {
        get;
        set;
    }

    public void fire()
    {
        if(dst != null) {
            dst.upcharge();
        }
    }
}
