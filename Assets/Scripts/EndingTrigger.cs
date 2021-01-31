using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;

    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") { dialogueTrigger.TriggerDialogue(); }
    }
}
