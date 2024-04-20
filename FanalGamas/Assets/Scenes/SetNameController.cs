using UnityEngine;
using TMPro;

public class SetNameController : MonoBehaviour
{
    public TMP_InputField user_inputField;
    public TextMeshProUGUI user_name_text;

    // PlayerPrefs key for storing user_name
    private string playerNameKey = "PlayerName";

    void Start()
    {
        // Load user_name from PlayerPrefs when the game starts
        LoadUserName();
    }

    public void setName()
    {
        string inputText = user_inputField.text.Trim();
        if (!string.IsNullOrEmpty(inputText))
        {
            // Save user_name to PlayerPrefs
            PlayerPrefs.SetString(playerNameKey, inputText);
            // Update user_name_text
            user_name_text.text = inputText;

        }
    }

    void LoadUserName()
    {
        // Check if user_name exists in PlayerPrefs
        if (PlayerPrefs.HasKey(playerNameKey))
        {
            // Get user_name from PlayerPrefs
            string playerName = PlayerPrefs.GetString(playerNameKey);
            // Update user_name_text
            user_name_text.text = playerName;
        }
    }
}
