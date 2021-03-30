using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainMenu() {
        Debug.Log("Switching Scenes");
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayLevel() {
        Debug.Log("Switching Scenes");
        SceneManager.LoadScene("SpecialLevel");
    }

    public void OpenSettings() {
        Debug.Log("Switching Scenes");
        // CHeck Data
        SceneManager.LoadScene("Settings");
    }
}
