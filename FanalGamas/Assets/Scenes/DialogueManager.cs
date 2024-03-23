using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueNameText, dialogueSentenceText; // Fixed the variable type
    private Queue<string> sentencesQueue = new Queue<string>(); // Specified the type and made it private

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueNameText.text = dialogue.dialogueName;
        sentencesQueue.Clear();
        foreach (string sentence in dialogue.sentences)
            sentencesQueue.Enqueue(sentence);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentencesQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentencesQueue.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public IEnumerator TypeSentence(string text)
    {
        dialogueSentenceText.text = "";
        foreach (char character in text.ToCharArray())
        {
            dialogueSentenceText.text += character;
            yield return new WaitForFixedUpdate();
        }
    }

    public void EndDialogue()
    {
        dialogueSentenceText.text = "Dialogue Ended";
    }
}
