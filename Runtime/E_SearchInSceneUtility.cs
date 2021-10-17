using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eloi {
public class E_SearchInSceneUtility : MonoBehaviour
{


    public static void TryToFetchWithInScene<T>(ref T toFill) where T : UnityEngine.Object
    {
        T[] languages = Resources.FindObjectsOfTypeAll<T>();
        if (languages.Length > 0)
            toFill = languages[0];
    }
    public static void TryToFetchWithInScene<T>(ref T[] toFill) where T : UnityEngine.Object
    {
        toFill = Resources.FindObjectsOfTypeAll<T>();
    }
    public static void TryToFetchWithActiveInScene<T>(ref T toFill) where T : UnityEngine.Object
    {

        toFill = GameObject.FindObjectOfType<T>();
    }
    public static void TryToFetchWithActiveInScene<T>(ref T[] toFill) where T : UnityEngine.Object
    {
        toFill = GameObject.FindObjectsOfType<T>();
    }
}
}
