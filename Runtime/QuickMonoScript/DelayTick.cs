using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayTick : MonoBehaviour
{
    public bool m_onAwake;
    public bool m_onStart=true;
    public bool m_onEnable;
    public float m_timeWhenToTick=0.2f;
    public UnityEvent m_tick;

    void Awake()
    {
        if (m_onAwake)
            Invoke("Tick", m_timeWhenToTick);
    }
    void Start()
    {
        if (m_onStart)
            Invoke("Tick", m_timeWhenToTick);
    }
    void OnEnable()
    {
        if (m_onEnable)
            Invoke("Tick", m_timeWhenToTick);
    }

    void Tick()
    {
        m_tick.Invoke();
    }
}
