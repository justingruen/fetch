using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : MonoBehaviour
{
    public Animator anim;
    public float slowness;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("isElec") == false) //falk   -se and not true? wtf?
        {
            anim.SetBool("isElec", true);
            StartCoroutine(turnOn());
        }
    }

    IEnumerator turnOn()
    {
        yield return new WaitForSeconds(1f / slowness);
    }
}
