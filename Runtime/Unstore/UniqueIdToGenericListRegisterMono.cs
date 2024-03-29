using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UniqueIdToGenericListRegisterMono<T> : MonoBehaviour
{

    public GroupOfUniqueIdToListObject<T> m_groupOfIdToListObject;
    public bool m_ignoreCase = true;
    public void Clear()
    {
        m_groupOfIdToListObject.Clear();
    }

    public void AddToList(string id, T value) {
        AddToList(id , new T[] { value} );
    }
    public void AddToList(string com, params T[] givenObject)
    {
        m_groupOfIdToListObject.Get(com, m_ignoreCase, out bool found, out UniqueIdToListOfObject<T> link);
        if (found)
            link.m_linkedObject.AddRange(givenObject);
        else m_groupOfIdToListObject.m_registeredIdToList.Add(new UniqueIdToListOfObject<T>(com, givenObject));

    }
    public void AddToList(string com, IEnumerable<T> givenObject)
    {
        m_groupOfIdToListObject.Get(com, m_ignoreCase, out bool found, out UniqueIdToListOfObject<T> link);
        if (found)
            link.m_linkedObject.AddRange(givenObject);
        else m_groupOfIdToListObject.m_registeredIdToList.Add(new UniqueIdToListOfObject<T>(com, givenObject));

    }
    public void Get(string lookingFor, bool ignoreCase, out bool found, out UniqueIdToListOfObject<T> link)
    {

        m_groupOfIdToListObject.Get(lookingFor, ignoreCase, out found, out link);
    }
}



[System.Serializable]
public class GroupOfUniqueIdToListObject<T>
{
    public List<UniqueIdToListOfObject<T>> m_registeredIdToList = new List<UniqueIdToListOfObject<T>>();

    public void Get(string lookingFor, bool ignoreCase, out bool found, out UniqueIdToListOfObject<T> link)
    {

        for (int i = 0; i < m_registeredIdToList.Count; i++)
        {
            if (Eloi.E_StringUtility.AreEquals(m_registeredIdToList[i].m_uniqueId, lookingFor, ignoreCase, true))
            {
                found = true;
                link = m_registeredIdToList[i];
                return;
            }
        }
        found = false;
        link = null;
    }

    public void Clear()
    {
        m_registeredIdToList.Clear();
    }
}
[System.Serializable]
public class UniqueIdToListOfObject<T>
{


    public string m_uniqueId = "";
    public List<T> m_linkedObject = new List<T>();

    public UniqueIdToListOfObject()
    {
    }

    public UniqueIdToListOfObject(string comId, IEnumerable<T> linkedObject)
    {
        m_uniqueId = comId;
        m_linkedObject.AddRange(linkedObject);
    }
    public UniqueIdToListOfObject(string comId, params T[] linkedObject)
    {
        m_uniqueId = comId;
        m_linkedObject.AddRange(linkedObject);
    }
}