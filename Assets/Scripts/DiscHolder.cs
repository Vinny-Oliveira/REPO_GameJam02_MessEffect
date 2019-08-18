using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscHolder : MonoBehaviour {

    /// <summary>
    /// Check if the disc holder has discs as children
    /// </summary>
    /// <returns></returns>
    public bool HasChildren() {
        if (GetComponentInChildren<DiscDisplay>() == null) {
            return false;
        } else {
            return true;
        }
    }
}
