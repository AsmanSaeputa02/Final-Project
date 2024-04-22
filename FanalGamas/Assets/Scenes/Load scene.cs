using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    // สร้างตัวแปรสำหรับรับชื่อตัวละคร
    public InputField characterNameInput;

    // เมื่อคลิกที่ปุ่มโหลดซีน
    public void LoadSelectedScene(string sceneName)
    {
        // ตรวจสอบว่ามีการป้อนชื่อตัวละครหรือไม่
        if (!string.IsNullOrEmpty(characterNameInput.text))
        {
            // รับชื่อตัวละครจาก InputField
            string characterName = characterNameInput.text;

            // สร้างชื่อซีนโดยใช้ชื่อตัวละคร
            string sceneToLoad = sceneName + "_" + characterName;

            // โหลดซีนที่เกี่ยวข้อง
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Please enter character name.");
        }
    }
}
