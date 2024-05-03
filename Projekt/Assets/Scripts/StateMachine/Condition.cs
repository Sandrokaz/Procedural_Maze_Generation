using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition 
{
    private bool m_value;
    private string m_name;

    public Condition(string name)
    {
        m_name = name;
    }

    public bool GetPass()
    {
        return m_value;
    }
    public void SetCondition(bool b)
    {
        m_value = b;
    }

    public string GetName()
    {
        return m_name;
    } 
}
