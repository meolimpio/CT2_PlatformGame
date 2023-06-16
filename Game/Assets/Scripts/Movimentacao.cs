using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    public float speed;
    public float jumpForce = 5f;
    public bool inFloor;
    private float direction;
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
        }
    }

}

