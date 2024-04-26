using System.Collections.Generic;
using UnityEngine;

namespace Eloi
{
    public class ArrayHolderMono_GenericArray<T>: MonoBehaviour
    {
        public List<T> m_array = new List<T>();


        public void AppendStartToArray(T value) { m_array.Insert(0, value); }
        public void AppendEndToArray(T value) { m_array.Add(value); }



        public void SetArray(IEnumerable<T> array)
        {
            Clear();
            m_array.AddRange(array);
        }
        public void SetArray(params T[] array)
        {
            Clear();
            m_array.AddRange(array);
        }
        public void AppendEndArray(IEnumerable<T> array)
        {
            m_array.AddRange( array);
        }
        public void AppendEndArray(params T[] array)
        {
            m_array.AddRange(array);
        }
        public void Clear() {
            m_array.Clear();
        }

    }
}
