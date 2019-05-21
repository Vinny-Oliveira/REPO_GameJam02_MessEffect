using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game", menuName = "Game")]
public class GameCase : ScriptableObject {

    /* PROPERTIES OF THE GAME */

    public string caseName;
    public string discName;

    public Sprite cover;

    /// <summary>
    /// Checks if the game inside the case matches the case
    /// </summary>
    /// <returns></returns>
    public bool IsMatch() {
        if (caseName == discName) {
            return true;
        } else {
            return false;
        }
    }

}
