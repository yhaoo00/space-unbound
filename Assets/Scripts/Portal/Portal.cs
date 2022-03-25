using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    //public Image black;
    //public Animator anim;

    void OnTriggerStay2D(Collider2D collide)
    {
        if(collide.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.W))
            {
                //StartCoroutine(Fading());
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private bool hasEntered;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && hasEntered == false)
        {
            SoundManager.PlaySound("portal");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && hasEntered == true)
        {
            hasEntered = false;
        }
    }

    /*IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }*/
}
