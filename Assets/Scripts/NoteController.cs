using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteController : MonoBehaviour
{
    public static NoteController instance;
    public GameObject notePanel;
    public Text noteText;

    public List<Note> noteList;

    [HideInInspector]
    public bool showingNote = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (showingNote)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HideNote();
            }
        }
    }

    public void ShowNote(int index)
    {
        SetNoteText(index);
        notePanel.SetActive(true);
        showingNote = true;
        ObjectExaminer.instance.BlockActions();
    }

    public void HideNote()
    {
        notePanel.SetActive(false);
        Invoke(nameof(EnableExaminer), 0.1f);
    }

    private void EnableExaminer()
    {
        showingNote = false;
        ObjectExaminer.instance.UnblockActions();
    }

    private void SetNoteText(int index)
    {
        if (LanguageSelector.instance.english)
        {
            noteText.text = noteList[index].englishText;
        }
        else
        {
            noteText.text = noteList[index].spanishText;
        }
    }
}