using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private string newLevel;
    public TimeManager timeManager;
    public float slowness = 3.5f;
    public SceneFader fader;
    public int levelToUnlock;

    public void Update()
    {
        /*if ((triggerP1 = true) && (triggerP2 = true))       //make sure trigger is set back to false if they leave endzone
        {
            timeManager.DoSlowmotion();
            StartCoroutine(runNext());
        }*/
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        timeManager.DoSlowmotion();
        StartCoroutine(runNext());
    }

    IEnumerator runNext()
    {
            yield return new WaitForSeconds(1f / slowness);
            WinLevel();
            fader.FadeTo("LevelScreen");
    }

    public void WinLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }
}
