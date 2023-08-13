using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLogMono : MonoBehaviour
{
    public void Log(string text)
    {
        Debug.Log(text);
    }
    public void Log(string [] text)
    {
        for (int i = 0; i < text.Length; i++)
            Debug.Log(text[i]);
    }

    public void LogWarning(string text)
    {
        Debug.LogWarning(text);
    }
    public void LogError(string text)
    {
        Debug.LogError(text);
    }

    public void Break()
    {
        Debug.Break();
    }
}
