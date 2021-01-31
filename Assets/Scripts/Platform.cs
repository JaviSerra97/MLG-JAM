using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    GameObject HitchInitial;
    private DialogueTrigger dialogueTrigger;
    private bool dialogueTriggered = false;

    void Awake()
    {
        HitchInitial = GameObject.FindGameObjectWithTag("HitchInitial");
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (!dialogueTriggered)
        {
            dialogueTrigger.TriggerDialogue();
            dialogueTriggered = true;
        }

        if (other.gameObject.CompareTag("Player") && InventoryController.instance.CheckItem(InventoryController.ItemType.rope))
        {
            if (!HitchInitial.GetComponent<HitchInitial>().reached)
                HitchInitial.GetComponent<HitchInitial>().Activate();
        }
        
    }
}
