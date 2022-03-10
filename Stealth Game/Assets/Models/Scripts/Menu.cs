using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject PauseMenu;
    public GameObject Credits;
    public GameObject Back;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            {
            PauseGame();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Credits1()
    {
        Credits.SetActive(true);
        Back.SetActive(true);
    }
    public void GoBack()
    {
        Credits.SetActive(false);
        Back.SetActive(false);
    }
}
