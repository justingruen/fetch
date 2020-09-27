using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speedRotate;
    public bool rotateRight;

    // Update is called once per frame
    void Update()
    {
        if (rotateRight)
        {
            transform.Rotate(Vector3.forward * -speedRotate * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
        }
    }
}
