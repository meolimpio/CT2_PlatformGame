using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocidadeHorizontal = Input.GetAxis("Horizontal") * speed;
        float velocidadeVertical = Input.GetAxis("Vertical") * speed;
    }
}
