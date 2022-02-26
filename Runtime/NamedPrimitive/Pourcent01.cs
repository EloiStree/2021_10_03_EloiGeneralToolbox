using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public interface IPercent01Get
    {
        public void GetPercent(out float PercentValueFromZeroToOne);
        public float GetPercent();
    }
    public interface IPercent01Set
    {
        public void SetPercent(in float PercentValueFromZeroToOne);
    }
    [System.Serializable]
    public class Percent01 : IPercent01Get, IPercent01Set
    {
        [Range(0, 1)]
        [SerializeField] float m_percentValue;

        public Percent01(in float percentValue)
        {
           SetPercent(in  percentValue);
        }

        public void GetPercent(out float PercentValueFromZeroToOne)
        {
            PercentValueFromZeroToOne = m_percentValue;
        }
        public float GetPercent()
        {
            return m_percentValue;
        }

        public void SetPercent(in float PercentValueFromZeroToOne)
        {
            if (PercentValueFromZeroToOne < 0)
                m_percentValue = 0;
            else if (PercentValueFromZeroToOne > 1)
                m_percentValue = 1;
            else
                m_percentValue = PercentValueFromZeroToOne;
        }


    }
}
