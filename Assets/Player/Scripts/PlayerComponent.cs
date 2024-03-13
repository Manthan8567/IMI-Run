using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public float horizontalInput = 0f;
    public float speed = 20f;
    public Player_movement movement;
    public bool isAlive = true;
    public GameManager gameManager;
    public Animator anim;
    public Hearth_manager hearth_manager;

    [SerializeField] private AudioSource coinSound, Death,winSound,background;
    public static bool isGameWin;
    public GameObject gameWin;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");


        if (Input.GetButtonDown("Jump") && isAlive == true)
        {
            if (movement.m_Grounded)
            {
                anim.SetTrigger("Jump");
            }
            movement.Jump();
        }
        anim.SetBool("Grounded", movement.m_Grounded);
        anim.SetBool("IsAlive", isAlive);

        if (horizontalInput == 0f)
        {
            anim.speed = 1;
            anim.SetBool("Move", false);
        }
        else
        {
            if (isAlive && movement.m_Grounded)
            {
                anim.speed = 1 * Mathf.Abs(horizontalInput);
            }
            anim.SetBool("Move", true);
        }
    }

    private void FixedUpdate()
    {
        if (isAlive == true)
        {
            movement.Move(horizontalInput * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            ScoreTextScript.coinAmount++;
            coinSound.Play();
            Debug.Log("Coin Picked!");
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.tag == "CheckPoint")
        {
            gameManager.spawnpoint = collision.gameObject.transform;
        }
        if (collision.gameObject.tag == "LevelEnd")
        {
            gameManager.FinishLevel();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle" || collision.gameObject.tag == "Enemy")
        {
            isAlive = false;
            anim.SetTrigger("Die");
            background.Pause();
            Death.Play();
            background.Play();
            hearth_manager.hearth--;
            

        }
        if (collision.gameObject.tag == "WeakPoint")
        {
            collision.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(collision.transform.parent.gameObject);
        }
        if (collision.gameObject.tag == "Home")
        {
            background.Pause();
            gameWin.SetActive(true);
            winSound.Play();
        }
    }
}
