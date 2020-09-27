using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public float slowness = 3.5f;
    public SceneFader fader;
    public Animator anim;
    private Scene m_scene;
    private string sceneName;
    public float respawnX = -4;
    public float respawnY = -4;

   
    private void OnCollisionEnter2D(Collision2D other)
    {
        anim.SetBool("Dies", true);
        anim.SetFloat("Timer", 1);
        StartCoroutine(runNext(other));

    }

    IEnumerator runNext(Collision2D other)
    {
        m_scene = SceneManager.GetActiveScene();
        sceneName = m_scene.name;

        yield return new WaitForSeconds(1f / slowness);
        //SceneManager.LoadScene(newLevel);
        anim.SetBool("Dies", false);
        anim.SetFloat("Timer", 0);

        yield return new WaitForSeconds(1f / (slowness * 2));
        other.transform.position = new Vector2(respawnX, respawnY);
        other.transform.localScale = new Vector2(1, 1);
    }
}
