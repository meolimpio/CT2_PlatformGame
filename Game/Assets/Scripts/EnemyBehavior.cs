using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    Rigidbody2D rb;
    BoxCollider2D boxCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFacingRight())
        {
            rb.velocity = new Vector2(speed, 0f);
        }

        else
        {
            rb.velocity = new Vector2(-speed, 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
    }

    private bool isFacingRight()
    {
        return transform.localScale.x == 1;
    }
}
