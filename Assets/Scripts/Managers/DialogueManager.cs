using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    private Queue<string> sentences;
    private GameObject db;
    private AudioSource audio;
    void Start() {
        sentences = new Queue<string>();
        db = GameObject.Find("DialogueBox");
        audio = GetComponent<AudioSource>();
        db.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue) {
        db.SetActive(true);
        Debug.Log("Start conversation");
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
    
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue(); return;
        }
        audio.Play();
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        // StartCoroutine(TypeEffect(sentence));
    }

    // IEnumerator TypeEffect(string sentence) {
    //     foreach (char letter in sentence.ToCharArray()) {
    //         dialogueText.text += letter;
    //         yield return new WaitForSeconds(0.02f);
    //     }
    // }

    public void EndDialogue() {
        db.SetActive(false);
    }

    void Show()
    {
        //  canvasGroup.alpha = 1f;
        //  canvasGroup.blocksRaycasts = true;
    }

    public void FixedUpdate() {
        if (Input.GetButtonDown("Fire1")) {
            DisplayNextSentence();
        }
    }
}
