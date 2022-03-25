using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movSpeed = 10f;
    public Rigidbody2D rb;

    public Animator anim;

    float mov_x;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        mov_x = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(mov_x) > .05f) anim.SetBool("isRunning", true);
        else anim.SetBool("isRunning", false);

        if (mov_x > 0f) transform.localScale = new Vector3(1f, 1f, 1f);
        else if (mov_x < 0f) transform.localScale = new Vector3(-1f, 1f, 1f);

    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(mov_x * movSpeed, rb.velocity.y);

        rb.velocity = movement;
    }
}
