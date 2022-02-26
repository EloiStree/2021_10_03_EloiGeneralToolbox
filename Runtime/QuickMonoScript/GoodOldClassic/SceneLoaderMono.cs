using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderMono : MonoBehaviour
{

    public string m_defaultScene;
    public bool m_reloadEventIfCurrent=true;
    public LoadSceneMode m_loadingMode= LoadSceneMode.Single;

    public void LoadDefaultSceneInMono()
    {
        SceneManager.LoadScene(m_defaultScene);
    }
    public void LoadSceneWithIndex(int index)
    {
        LoadSceneWithIndex(index, m_reloadEventIfCurrent);
    }
    public void LoadSceneWithIndex(int index, bool reloadIfCurrent)
    {
        Eloi.E_CodeTag.DirtyCode.Info("I realized that GetCurrent scene is bugging when in don't destroy... To correct later");
        if (reloadIfCurrent)
            SceneManager.LoadScene(index, m_loadingMode);
        else if (!reloadIfCurrent && index != SceneManager.GetActiveScene().buildIndex)
            SceneManager.LoadScene(index, m_loadingMode);
    }

    public void LoadSceneWithName(string name)
    {
        LoadSceneWithName(name, m_reloadEventIfCurrent);
    }
    public void LoadSceneWithName(string name, bool reloadIfCurrent )
    {
        Eloi.E_CodeTag.DirtyCode.Info("I realized that GetCurrent scene is bugging when in don't destroy... To correct later");
        string currentScene = SceneManager.GetActiveScene().name;
        if (reloadIfCurrent)
            SceneManager.LoadScene(name, m_loadingMode);
        else if (!reloadIfCurrent && Eloi.E_StringUtility.AreNotEquals(in currentScene, in name,true, true))
            SceneManager.LoadScene(name, m_loadingMode);
    }
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




}
