using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D pRB;
    public float upperBounds;
    public float lowerBounds;
    public float maxSpeed;

    // Update is called once per frame
    void Update()
    {
       /* if (Player.transform.position.y >= upperBounds)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, lowerBounds, Player.transform.position.z);
        }*/

        if (Player.transform.position.y <= lowerBounds)
        {
            Player.transform.position = new Vector3(Player.transform.position.x, upperBounds, Player.transform.position.z);
        }

        if (pRB.velocity.magnitude > maxSpeed)
        {
            pRB.velocity = Vector3.ClampMagnitude(pRB.velocity, maxSpeed);
        }
    }
}
