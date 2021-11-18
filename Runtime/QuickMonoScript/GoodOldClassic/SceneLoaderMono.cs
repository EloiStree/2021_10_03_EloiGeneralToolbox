using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderMono : MonoBehaviour
{

    public string m_defaultScene;

    public void LoadDefaultSceneInMono()
    {
        SceneManager.LoadScene(m_defaultScene);
    }
    public void LoadSceneWithIndex(int index)
    {
        LoadSceneWithIndex(index, false);
    }
    public void LoadSceneWithIndex(int index, bool reloadIfCurrent=false)
    {
        if(reloadIfCurrent)
            SceneManager.LoadScene(index);
        else if (!reloadIfCurrent && index != SceneManager.GetActiveScene().buildIndex)
            SceneManager.LoadScene(index);
    }

    public void LoadSceneWithName(string name)
    {
        LoadSceneWithName(name, false);
    }
    public void LoadSceneWithName(string name, bool reloadIfCurrent = false)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (reloadIfCurrent)
            SceneManager.LoadScene(name);
        else if (!reloadIfCurrent && Eloi.E_StringUtility.AreNotEquals(in currentScene, in name,true, true))
            SceneManager.LoadScene(name);
    }
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




}
