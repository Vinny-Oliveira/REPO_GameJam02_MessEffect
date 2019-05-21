using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GAME { MASS_EFFECT, INTERSTELLAR, BLADE_RUNNER };

[CreateAssetMenu(fileName = "New Game", menuName = "Game")]
public class GameCase : ScriptableObject {

    /* PROPERTIES OF THE GAME */

    public GAME caseName;
    public GAME discName;

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
