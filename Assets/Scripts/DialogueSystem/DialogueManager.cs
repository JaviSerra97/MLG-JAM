using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    public GameObject conversationPanel;

    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { DisplayNextSentence(); }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        conversationPanel.SetActive(true);

        nameText.text = dialogue.name;

        sentences.Clear();

        if (LanguageSelector.instance.english)
        {
            foreach (string sentence in dialogue.englishSentences)
            {
                sentences.Enqueue(sentence);
            }
        }

        else
        {
            foreach (string sentence in dialogue.spanishSentences)
            {
                sentences.Enqueue(sentence);
            }
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentece(sentence));
    }

    IEnumerator TypeSentece(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            yield return null;
        }
    }

    void EndDialogue()
    {
        conversationPanel.SetActive(false);
    }
}
