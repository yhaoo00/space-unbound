using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public float jumpForce;
    public Animator anim = null;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SoundManager.PlaySound("jump");
            anim.Play("Jump_pad_jump");
            boostPlayer(other.transform);
        }
    }

    void boostPlayer(Transform playerJump)
    {
        Vector2 jumpDirection = new Vector2(0, (playerJump.position.y - transform.position.y)).normalized;
        jumpDirection *= jumpForce;
        Rigidbody2D jumprb = playerJump.gameObject.GetComponent<Rigidbody2D>();
        jumprb.velocity = Vector2.zero;
        jumprb.AddForce(jumpDirection, ForceMode2D.Impulse);
    }
}
