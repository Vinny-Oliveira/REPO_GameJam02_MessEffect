﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GAME { MASS_EFFECT, INTERSTELLAR, BLADE_RUNNER };

public class GameManager : MonoBehaviour
{
    public Dictionary<GAME, string> gameDictionary = new Dictionary<GAME, string>();

    public GameObject discHolder;

    public bool isClickable;

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

        /* FOR THE 2nd POSSIBILITY
        gameDictionary.Add(GAME.MASS_EFFECT, "Mass Effect");
        gameDictionary.Add(GAME.INTERSTELLAR, "Interstellar");
        gameDictionary.Add(GAME.BLADE_RUNNER, "Blade Runner");
        */

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

    public void ExitGame()
    {
        Application.Quit();
    }

}
