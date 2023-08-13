using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{

    public class DicoFloatChangeObserversMono
    {
        public DicoFloatChangeObserver m_observerDico = new DicoFloatChangeObserver();
        public void StartObserving( string id, float startValue, float changeDeathZone = 0.08f) {
            m_observerDico.StartObserving(id, startValue, changeDeathZone);  
        }
        public bool IsExisting(in string id)
        {
            return m_observerDico.IsExisting(id);
        }
        public void Set(in string id,  float newValue, out bool changed)
        {
            m_observerDico.Set(id, newValue, out changed);
        }

    }


    public class DicoFloatChangeObserver
    {
        public Dictionary<string, FloatChangeObserver> m_register = new Dictionary<string, FloatChangeObserver>();

        public void StartObserving( string id, float startValue, float changeDeathZone = 0.08f)
        {
            if (!m_register.ContainsKey(id))
            {
                m_register.Add(id, new FloatChangeObserver(startValue,changeDeathZone));    
            }
        }
        public bool IsExisting(in string id)
        {
            return m_register.ContainsKey(id);
        }
        public void Set(in string id, float newValue, out bool changed)
        {
            if (!m_register.ContainsKey(id))
            {
                m_register.Add(id, new FloatChangeObserver(newValue));
                changed = false;
                return;
            }
            m_register[id].SetValue(newValue, out changed);
        }

    }


    [System.Serializable]
    public class FloatChangeObserver
    {

        public float m_currentValue;
        public float m_minDeathZone = 0.06f;

        public FloatChangeObserver(float currentValue)
        {
            m_currentValue = currentValue;
        }

        public FloatChangeObserver(float currentValue, float minDeathZone)
        {
            m_currentValue = currentValue;
            m_minDeathZone = minDeathZone;
        }

        public void SetValue(float newValue, out bool changeDetected)
        {

            changeDetected = Mathf.Abs(m_currentValue - newValue) >= m_minDeathZone;
            if (changeDetected)
                m_currentValue = newValue;
        }
    }
}
