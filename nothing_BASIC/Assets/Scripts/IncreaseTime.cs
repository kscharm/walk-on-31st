using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseTime : MonoBehaviour
{
    public Condition condition;
    public float time;
    
    private void increaseTime()
    {
        if (!condition.satisfied)
        {
            Global.time += time;
            condition.satisfied = true;
        }
    }
}
