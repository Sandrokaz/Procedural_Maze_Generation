using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition
{
    private MyState from;
    private MyState to;

    private  Condition condition;
    private bool passOn;
    

    public Transition(MyState _from, MyState to, Condition condition, bool passOn)
    {
        from = _from;
        this.to = to;
        this.condition = condition;
        this.passOn = passOn;
    }

    public bool GetPass()
    {
        if (!passOn)
        {
            if (condition.GetPass())
            {
                return false;
            }
            return true;
        }
        else
        {
            if (condition.GetPass())
            {
                return true;
            }
            return false;
        }
    }

    public MyState GetFrom()
    {
        return from;
    }

    public MyState GetTo()
    {
        return to;
    }

    
}
