using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager; // Corrected the class name

    void Start()
    {
        Invoke("TriggerDialogue", 1f); // เรียกใช้เมทอด TriggerDialogue() หลังจากผ่านไป 1 วินาที
    }

    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
    }
}
