using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;

    void Update()
{
    if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
    {
        Debug.Log("E key pressed and player is close.");
        if (dialoguePanel.activeInHierarchy)
        {
            Debug.Log("Dialogue panel is active. Zeroing text.");
            ZeroText();
        }
        else
        {
            Debug.Log("Dialogue panel is inactive. Showing dialogue.");
            dialoguePanel.SetActive(true);
            StartCoroutine(Typing());
        }
    }
}

IEnumerator Typing()
{
    Debug.Log("Typing coroutine started.");
    foreach (char letter in dialogue[index].ToCharArray())
    {
        dialogText.text += letter;
        yield return new WaitForSeconds(wordSpeed);
    }
}


    public void ZeroText()
    {
        dialogText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            // End of dialogue, you can add any behavior here
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            ZeroText();
        }
    }
}
