﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum GAME { MASS_EFFECT, INTERSTELLAR, BLADE_RUNNER };

public class GameManager : MonoBehaviour
{
    // Dictionary with the infomration of the game cases
    //public Dictionary<GAME, string> gameDictionary = new Dictionary<GAME, string>();
    public Dictionary<string, bool> gameDictionary = new Dictionary<string, bool>();

    // Slots to place discs
    public GameObject discHolder1;
    public GameObject discHolder2;

    // Objects for the position of the case that is on display
    public GameObject caseOnDisplay;
    public GameObject casePlaceHolder;

    #region IN_GAME Variables
    // Booleans for game control
    public bool isClickable;
    public bool isGameOver;
    public bool isGamePaused;
    
    #endregion

    #region References for canvases and panels
    // UI variables
    //public GameObject pauseCanvas;
    public GameObject gameOverCanvas;

    #endregion

    #region LAZY_SINGLETON
    private static GameManager instance;

    public static GameManager GetInstance() {
        if (instance != null) {
            return instance;
        } else {
            return null;
        }
    }

    private void Awake() {

        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        isClickable = true;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    /// <summary>
    /// Set the proper state of the object depending on whether it is tweening on not
    /// </summary>
    public void ChangeClickingState() {
        isClickable = !isClickable;
    }

    /// <summary>
    /// Check if all game discs match their respective cases
    /// </summary>
    public void CheckForAllMatches() {
        foreach (string key in gameDictionary.Keys) { // Loop through the items in the dictionary
            if (!gameDictionary[key]) {
                return;
            }
        }

        Debug.Log("YOU WIN!");
        TriggerGameOver();
    }

    /// <summary>
    /// Game over if all games are organized
    /// </summary>
    public void TriggerGameOver() {
        Time.timeScale = 0f;
        isGameOver = true;
        gameOverCanvas.SetActive(true);
    }

    #region PAUSE MANAGEMENT

    public void PauseGame() {
        Time.timeScale = 0f;
        //pauseCanvas.SetActive(true);
        //Cursor.lockState = CursorLockMode.None;
        isGamePaused = true;
    }

    public void UnpauseGame() {
        Time.timeScale = 1f;
        //pauseCanvas.SetActive(false);
        //Cursor.lockState = CursorLockMode.Locked;
        isGamePaused = false;
    }

    #endregion

    public void QuitGame()
    {
        Application.Quit();
    }

}
