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
        string path = Application.persistentDataPath + "/Save/savegame.txt";
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Save file deleted.");
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
}
