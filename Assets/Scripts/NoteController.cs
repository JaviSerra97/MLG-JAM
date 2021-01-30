using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public static NoteController instance;
    public GameObject notePanel;

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
        // index es para identificar la nota y cambiar el texto
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
}