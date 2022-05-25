using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    private Button m_Start;
    private Image m_image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CloseMainMenu()
    {
        SceneManager.LoadScene(sceneName: "Cockpit");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
