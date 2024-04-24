using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        // สร้างการฟังก์ชันสำหรับจับเหตุการณ์เมื่อมีการเปลี่ยนซีน
        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    private void OnSceneChanged(Scene previousScene, Scene newScene)
    {
        // ถ้าเปลี่ยนซีนให้บันทึกเกมโดยอัตโนมัติ
        SaveGame();
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/Save/savegame.txt";
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            SceneManager.LoadScene(data);
        }
        else
        {
            Debug.Log("No save file found.");
        }
    }

   public void NewGame()
{
    // ลบไฟล์บันทึกเกม (หากมี)
    string saveGamePath = Application.persistentDataPath + "/Save/savegame.txt";
    string saveNamePath = Application.persistentDataPath + "/Save/savename.txt";
    
    if (File.Exists(saveGamePath))
    {
        File.Delete(saveGamePath);
        Debug.Log("Savegame file deleted.");
    }

    if (File.Exists(saveNamePath))
    {
        File.Delete(saveNamePath);
        Debug.Log("Savename file deleted.");
    }
    
    // โหลดซีน "Choose a character" เพื่อเริ่มเกมใหม่
    SceneManager.LoadScene("Choose a character");
}


    public void SaveGame()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        string path = Application.persistentDataPath + "/Save/savegame.txt";

        // สร้างโฟลเดอร์ Save ถ้ายังไม่มี
        Directory.CreateDirectory(Application.persistentDataPath + "/Save");

        File.WriteAllText(path, currentScene);

        Debug.Log("Game saved.");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("Loading next scene: " + nextSceneIndex);
        SceneManager.LoadSceneAsync(nextSceneIndex);
    }
}
