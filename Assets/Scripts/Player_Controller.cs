using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Player_Controller : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private Animator anim;
    public Animator anim2;
    public Animator electric;


    public float slowness = 3.5f;
    public SceneFader fader;
    private Scene m_scene;
    private string sceneName;
    public float respawnX = -4;
    public float respawnY = -4;

    public GameObject Player1;

    public bool isDead;

    public bool starting = true;
    public bool goLeft = false;
    public float waiterLength;
    public float pushSpeed = 5f;

    public CinemachineVirtualCamera cine;

    // Start is called before the first frame update
    void Start()
    {

        theRB = GetComponent<Rigidbody2D>();        //doesnt it just have it?
        theRB.AddForce(Vector2.up * pushSpeed);
        if (goLeft == true)
        {
            theRB.AddForce(Vector2.left * pushSpeed);
        }
        else
        {
            theRB.AddForce(Vector2.right * pushSpeed);
        }
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        //cine.transform.rotation.x = 0;
        //cine.transform.rotation.y = 0;

        if (starting == true)
        {
            return;
        }

        if (PauseMenu.isPaused == true)
        {
            Time.timeScale = 0;
        }

        if (isDead == true)
        {
            return;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);

        anim = GetComponent<Animator>();

        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        } else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        } else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded == true)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if(theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if(theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs (theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Deadly"))
        {
            isDead = true;
            anim2.SetBool("Dies", true);
            anim2.SetFloat("Timer", 1);
            StartCoroutine(runNext());
        }

        if (other.gameObject.CompareTag("Electric"))
        {
            if(electric.GetBool("isElec") == true)
            {
                isDead = true;
                anim2.SetBool("Dies", true);
                anim2.SetFloat("Timer", 1);
                StartCoroutine(runNext());
            }
        }

    }

    IEnumerator runNext()
    {
        m_scene = SceneManager.GetActiveScene();
        sceneName = m_scene.name;

        yield return new WaitForSeconds(1f / slowness);
        //SceneManager.LoadScene(newLevel);
        anim2.SetBool("Dies", false);
        anim2.SetFloat("Timer", 0);

        yield return new WaitForSeconds(1f / (slowness * 2));
        isDead = false;
        Player1.transform.position = new Vector2(respawnX, respawnY);
        Player1.transform.localScale = new Vector2(1, 1);
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1f / waiterLength);
        starting = false;
    }
}
