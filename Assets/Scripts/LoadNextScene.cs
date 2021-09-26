using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNextScene : MonoBehaviour
{
public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public void GameOver()
    {
        StartCoroutine(WaitAndLoad());
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Loser");

    }
}
