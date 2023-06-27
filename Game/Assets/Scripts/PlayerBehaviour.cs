using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    public float speed;
    private float jumpForce = 5f;
    public bool inFloor;
    private float direction;
    private int numLives = 3;
    public int jumpExtra = 1;
    
    private GameController gcPlayer;
    public Transform detectGround;
    public LayerMask isGround;

    private Vector3 facingRight;
    private Vector3 facingLeft;

    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gcPlayer = GameController.gc;
        gcPlayer.coins = 0;
    }

    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if(Input.GetAxis("Horizontal") != 0) //correndo
        {
            animator.SetBool("isRunning", true);
        }

        else //parado
        {
            animator.SetBool("isRunning", false);
        }

        rb.velocity = new Vector2(direction * speed, rb.velocity.y);

        inFloor = Physics2D.OverlapCircle(detectGround.position, 0.2f, isGround);

        if(direction > 0) //olhando para a direita
        {
            transform.localScale = facingRight;
        }

        if(direction < 0) //olhando para a esquerda
        {
            transform.localScale = facingLeft;
        }

        if (Input.GetButtonDown("Jump") && inFloor == true)
        {
            rb.velocity = Vector2.up * 5;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Jump") && inFloor == false && jumpExtra > 0)
        {
            rb.velocity = Vector2.up * 5;
            jumpExtra--;
            animator.SetBool("doubleJump", true);
            
        }

        if (inFloor && rb.velocity.y == 0) 
        {
            jumpExtra = 1;
            animator.SetBool("isJumping", false);
            animator.SetBool("doubleJump", false);
        }

    }

    //colidir com o inimigo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LoseLife();
        }
    }

    //colisão com as moedas
    void OnTriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            gcPlayer.coins++;
            gcPlayer.Score.text = gcPlayer.coins.ToString();
        }
    }

    
    //perda de vida quando colide com o inimigo
    public void LoseLife()
    {
        numLives--;

        if (numLives <= 0)
        {
            Debug.Log("Game Over");
        }

        else
        {
            Debug.Log("Continue");
        }
    }

}

