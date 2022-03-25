using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerDie, playerDrop, playerPickup, playerJump, playerSelect, triggerPortal, winSFX;
    static AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        playerDie = Resources.Load<AudioClip>("die");
        playerDrop = Resources.Load<AudioClip>("drop");
        playerPickup = Resources.Load<AudioClip>("pickup");
        playerJump = Resources.Load<AudioClip>("jump");
        playerSelect = Resources.Load<AudioClip>("select");
        triggerPortal = Resources.Load<AudioClip>("portal");
        winSFX = Resources.Load<AudioClip>("win");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "die":
                audioSource.PlayOneShot(playerDie);
                break;
            case "drop":
                audioSource.PlayOneShot(playerDrop);
                break;
            case "pickup":
                audioSource.PlayOneShot(playerPickup);
                break;
            case "jump":
                audioSource.PlayOneShot(playerJump);
                break;
            case "select":
                audioSource.PlayOneShot(playerSelect);
                break;
            case "portal":
                audioSource.PlayOneShot(triggerPortal);
                break;
            case "win":
                audioSource.PlayOneShot(winSFX);
                break;
        }
    }
}
