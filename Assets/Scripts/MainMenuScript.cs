using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {
    
    public GameObject mainMenuScreen;
    public GameObject instructionsScreen;

    void Awake() {
        mainMenuScreen.SetActive(true);
        instructionsScreen.SetActive(false);
    }

    public void StartGame() {
        mainMenuScreen.SetActive(false);
    }

    public void Instructions() {
        instructionsScreen.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Back() {
        instructionsScreen.SetActive(false);
    }

    public void Credits()
    {
        SceneManager.LoadScene(1);
    }
}
