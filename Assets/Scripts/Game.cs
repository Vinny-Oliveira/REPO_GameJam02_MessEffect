using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game", menuName = "Game")]
public class Game : ScriptableObject {

    /* PROPERTIES OF THE GAME */

    public string strCaseName;
    public string strDiscName;

    public Sprite cover;

    /// <summary>
    /// Checks if the game inside the case matches the case
    /// </summary>
    /// <returns></returns>
    public bool IsMatch() {
        if (strCaseName == strDiscName) {
            return true;
        } else {
            return false;
        }
    }

}
