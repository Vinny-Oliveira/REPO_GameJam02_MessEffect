using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game", menuName = "Game")]
public class Game : ScriptableObject {

    public string strCaseName;
    public string strDiscName;

    public Sprite cover;

    public bool isMatch;

}
