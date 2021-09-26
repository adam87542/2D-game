using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    float DelayTime = 2f;
    float SlowModeTime = 0.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Exit());
    }
    IEnumerator Exit()
    {
        Time.timeScale = SlowModeTime;
        yield return new WaitForSecondsRealtime(DelayTime);
        Time.timeScale = 1f;
        var CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene + 1);
    }
}
