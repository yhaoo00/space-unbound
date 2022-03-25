using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{ 
    private readonly Queue<string> sentences = new Queue<string>();

    public TextMeshProUGUI nameTmp;
    public TextMeshProUGUI dialogueTmp;
    public Animator anim;

    public void StartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0;
        anim.SetBool("isOpen", true);
        nameTmp.SetText(dialogue.name.ToString());

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //dialogueTmp.SetText(sentence.ToString());
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueTmp.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueTmp.text += letter;
            yield return new WaitForSecondsRealtime(.01f);
        }
    }

    void EndDialogue()
    {
        anim.SetBool("isOpen", false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            DisplayNextSentence();
    }
}
