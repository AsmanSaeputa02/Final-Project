using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetNameController : MonoBehaviour
{
    public TextMeshProUGUI user_name; // Corrected variable name
    public TMP_InputField user_inputField; // Corrected variable name
    public GameObject hideButton; // Button to hide the dialogue box

    public void setName()
    {
        string inputText = user_inputField.text.Trim(); // Get input text without leading or trailing whitespace

        if (!string.IsNullOrEmpty(inputText)) // Check if input text is not empty or null
        {
            user_name.text = inputText;
            StartCoroutine(ShowHideButtonAfterDelay(1f)); // Start coroutine to show hide button after 1 second
        }
    }

    IEnumerator ShowHideButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for specified delay
        hideButton.SetActive(true); // Show the hide button
    }

    public void ResetName()
    {
        user_name.text = "";
        hideButton.SetActive(false); // Hide the hide button when resetting the name
    }
}
