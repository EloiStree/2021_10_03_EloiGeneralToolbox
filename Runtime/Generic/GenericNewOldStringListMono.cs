using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Eloi
{
    public class GenericNewOldStringListMono : GenericNewOldListMono<string>
    {


        
    }
    public class GenericNewOldListMono<T> : MonoBehaviour
    {
        public GenericNewOldList<T> m_tracked;
        public TEvent m_onCurrent;
        public TEvent m_onAdded;
        public TEvent m_onRemoved;
        


        [System.Serializable]
        public class TEvent : UnityEvent<T[]> { }
        // Start is called before the first frame update
        public void PushAndRefresh(T[] newValue,  bool andNotify)
        {
            m_tracked.RefreshComListInfo(newValue);
            if (andNotify)
                Notify();
        }
        public void PushAndRefreshAndNotify(T[] givenList)
        {

            PushAndRefresh(givenList, true);
        }
        [ContextMenu("Refresh with current")]
        public void RefreshWithCurrent( bool andNotify)
        {
            m_tracked.RefreshComListInfo(m_tracked.m_currentList);
            if (andNotify)
                Notify();
        }


        public void Notify()
        {
            m_onCurrent.Invoke(m_tracked.m_currentList);
            if(m_tracked.m_newList.Length>0)
                m_onAdded.Invoke(m_tracked.m_newList);
            if (m_tracked.m_lostList.Length > 0)
                m_onRemoved.Invoke(m_tracked.m_lostList);
        }

    }


    [System.Serializable]
    public class GenericNewOldList<T>
    {

        public T[] m_currentList= new T[0];
        public T[] m_previousList = new T[0];
        public T[] m_newList = new T[0];
        public T[] m_lostList = new T[0];

        public void RefreshComListInfo(IEnumerable<T> newElement)
        {
            m_previousList = m_currentList.ToArray();
            m_currentList = newElement.Distinct().ToArray();
            m_newList = (m_currentList.ToArray().Except(m_previousList)).ToArray();
            m_lostList = (m_previousList.ToArray().Except(m_currentList)).ToArray();
        }


    }

}
