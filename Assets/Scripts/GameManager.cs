using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dictionary<GAME, string> gameDictionary;

    // Start is called before the first frame update
    void Start()
    {
        gameDictionary.Add(GAME.MASS_EFFECT, "Mass Effect");
        gameDictionary.Add(GAME.INTERSTELLAR, "Interstellar");
        gameDictionary.Add(GAME.BLADE_RUNNER, "Blade Runner");
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
