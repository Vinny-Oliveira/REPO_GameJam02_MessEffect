using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiscDisplay : MonoBehaviour
{
    public Game gameDisc;

    // UI Elements
    public TextMeshProUGUI txtGameTitle;
    public Image gameCover;


    // Start is called before the first frame update
    void Start()
    {
        // Get the information from the game scriptable object and place it in the game object
        txtGameTitle.text = gameDisc.gameName; //GameManager.GetInstance().gameDictionary[game.caseName];
        gameCover.sprite = gameDisc.cover;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
