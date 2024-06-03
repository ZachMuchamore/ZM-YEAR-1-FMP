using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenus : MonoBehaviour
{
    public GameObject mainMenu;

    public GameObject optionsMenu;

    public GameObject controlsMenu;



    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        controlsMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void ControlsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void BackToMain()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game scene");
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
