using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;

    void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    private void Start()
    {
        dialogueTrigger.TriggerDialogue();
    }
}
