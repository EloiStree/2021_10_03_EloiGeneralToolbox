using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayTick : MonoBehaviour
{
    public float m_timeWhenToTick=0.2f;
    public UnityEvent m_tick;

    void Start()
    {
        Invoke("Tick", m_timeWhenToTick);
    }
    
    void Tick()
    {
        m_tick.Invoke();
    }
}
