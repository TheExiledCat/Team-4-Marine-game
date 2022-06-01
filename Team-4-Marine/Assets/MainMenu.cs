using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public void CloseMainMenu()
    {
        SceneManager.LoadScene(sceneName: "Cockpit");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
