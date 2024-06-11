using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenus : MonoBehaviour
{
    public GameObject mainMenu;

    public GameObject controlsMenu;

    public TextMeshProUGUI highScoreUI;
    public TextMeshProUGUI zombiesKilledUI;
    public TextMeshProUGUI timePlayedUI;




    // Start is called before the first frame update
    void Start()
    {
        int highScore = SaveLoadManager.instance.LoadHighScore();
        highScoreUI.text = $"Highest Wave Achieved: {highScore}";

        int ZombieScore = SaveLoadManager.instance.LoadZombieScore();
        highScoreUI.text = $"Most Zombies Killed: {ZombieScore}";

        mainMenu.SetActive(true);
        controlsMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoresMenu()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    public void ControlsMenu()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void BackToMain()
    {
        mainMenu.SetActive(true);
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
