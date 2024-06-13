using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public static int current_Scene;
    public void GotoNextScene()
    {
        current_Scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_Scene + 1);
        Time.timeScale = 1.0f;
        Resources.UnloadUnusedAssets();
    }
    public void GotoAnyScene(int indexScene)
    {
        current_Scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indexScene);
        Time.timeScale = 1.0f;
        Resources.UnloadUnusedAssets();
    }
    public void ReloadScene()
    {
        current_Scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current_Scene);
        Time.timeScale = 1.0f;
        Resources.UnloadUnusedAssets();
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
