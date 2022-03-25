using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    public TextMeshProUGUI tmp;

    private int deathCount = 3;
    private bool hasEntered;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tmp.SetText(deathCount.ToString());
        if (collision.gameObject.CompareTag("Obstacles") && hasEntered == false) 
        {
            SoundManager.PlaySound("die");
            hasEntered = true;
            deathCount -= 1;
            gameObject.transform.position = spawnPoint.position;
            if (deathCount <= 0)
            {
                deathCount = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles") && hasEntered == true)
        {
            hasEntered = false;
        }
    }
    
}
