using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    // Add a reference to the SetNameController
    public SetNameController setNameController;

    void Start()
    {
        // Call TriggerDialogue after 1 second
        Invoke("TriggerDialogue", 1f);
    }

    public void TriggerDialogue()
    {
        // Get the name from the SetNameController
        string userName = setNameController.user_inputField.text.Trim();
        
        // Assign the name to the dialogue
        dialogue.dialogueName = userName;
        
        // Start the dialogue
        dialogueManager.StartDialogue(dialogue);
    }
}
