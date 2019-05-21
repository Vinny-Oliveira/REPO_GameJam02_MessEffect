using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game", menuName = "Game")]
public class Game : ScriptableObject {

    /* PROPERTIES OF THE GAME */

    public string gameName; /* 1st POSSIBILITY: Strings written on the scriptable object in Unity.
                                                Efficiency may not be a problem, because the name would be written only once */
    //public GAME gameName; /* 2nd POSSIBILITY: Enums defined in our GameManager with names of the game, but with the strings defined in a dictionary.
    //                                          Efficiency could be a problem, because the dictionary would have to be loaded in the beginning of the game.
    //                                          Still, it would be a good chance to learn more about lists and dictionaries. */
    public Sprite cover;

    /// <summary>
    /// Checks if the game inside the case matches the case
    /// </summary>
    /// <returns></returns>
    //public bool IsMatch() {
    //    if (caseName == discName) {
    //        return true;
    //    } else {
    //        return false;
    //    }
    //}

}
