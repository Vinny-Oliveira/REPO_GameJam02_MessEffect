﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscHolder : MonoBehaviour {

    //public bool isParent = false;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

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