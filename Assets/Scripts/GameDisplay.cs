using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDisplay : MonoBehaviour
{
    public Game game;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    /// <summary>
    /// Check if the the disc inside this box belongs to it
    /// </summary>
    [ContextMenu("Check if match")]
    public void CheckIfMatch() {
        if (game.IsMatch()) {
            Debug.Log("Great! This is the right disc!");
        } else {
            Debug.Log("This disc does not belong to this case"); 
        }
    }
}
