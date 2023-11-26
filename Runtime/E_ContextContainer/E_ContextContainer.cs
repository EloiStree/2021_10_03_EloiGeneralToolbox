using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Eloi
{

    [System.Serializable]
    public abstract class ContextContainerGeneric<T>
    {
        [SerializeField] private T m_value;
        public T Value
        {
            get { return m_value; }
            set { m_value = value; }
        }
        public ContextContainerGeneric() { }
        public ContextContainerGeneric(T value) { m_value = value; }
        public T GetValue() { return m_value; }
        public void GetValue(out T value) { value = m_value; }
        public void SetValue(T value) { m_value = value; }
    }






    [System.Serializable]
    public abstract class ContextContainerToImplementGeneric<T>
    {

        public ContextContainerToImplementGeneric() { }
        public ContextContainerToImplementGeneric(T value) { SetValue(value); }
        public T Value
        {
            get { return GetValue(); }
            set { SetValue(value); }
        }
        public void GetValue(out T value) { value = GetValue(); }
        public abstract T GetValue();
        public abstract void SetValue(T value);
    }











    [System.Serializable]
    public class Context
    {
        public class Time
        {
            [System.Serializable]
            public class SecondAsInt : ContextContainerToImplementGeneric<int>
            { public int m_seconds; public override int GetValue() => m_seconds; public override void SetValue(int value) => m_seconds = value; }
            [System.Serializable]
            public class SecondAsFloat : ContextContainerToImplementGeneric<float>
            { public float m_seconds; public SecondAsFloat() { } public SecondAsFloat(float value) : base(value) { } public override float GetValue() => m_seconds; public override void SetValue(float value) => m_seconds = value;  }
            [System.Serializable]
            public class SecondAsDouble : ContextContainerToImplementGeneric<double>
            { public double m_seconds; public override double GetValue() => m_seconds; public override void SetValue(double value) => m_seconds = value; }
            [System.Serializable]
            public class MinuteAsInt : ContextContainerToImplementGeneric<int>
            { public int m_minutes; public override int GetValue() => m_minutes; public override void SetValue(int value) => m_minutes = value; }
            [System.Serializable]
            public class HourAsInt : ContextContainerToImplementGeneric<int>
            { public int m_hours; public override int GetValue() => m_hours; public override void SetValue(int value) => m_hours = value; }
            [System.Serializable]
            public class DayAsInt : ContextContainerToImplementGeneric<int>
            { public int m_days; public override int GetValue() => m_days; public override void SetValue(int value) => m_days = value; }
            [System.Serializable]
            public class MonthAsInt : ContextContainerToImplementGeneric<int>
            { public int m_months; public override int GetValue() => m_months; public override void SetValue(int value) => m_months = value; }

            [System.Serializable]
            public class yearAsInt : ContextContainerToImplementGeneric<int>
            { public int m_years; public override int GetValue() => m_years; public override void SetValue(int value) => m_years = value; }
        }
    }

}
