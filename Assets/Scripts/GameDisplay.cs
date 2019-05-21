﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GameDisplay : MonoBehaviour
{
    // Game information of the game case
    public GameCase game;

    // UI Elements
    public TextMeshProUGUI txtGameTitle;
    public Image gameCover;

    public GameObject rotationAxis;
    private Vector3 initialPosition;
    public bool isDisplayed;

    // Start is called before the first frame update
    void Start()
    {
        // Get the information from the game scriptable object and place it in the game object
        txtGameTitle.text = game.caseName; //GameManager.GetInstance().gameDictionary[game.caseName];
        gameCover.sprite = game.cover;

        // Get the initial position
        initialPosition = transform.position;
    }

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

    // Testing the movement of the game case
    [ContextMenu("Make game move")]
    public void MakeGameMove() {
        Sequence mySequence = DOTween.Sequence();

        if (!isDisplayed) {
            Vector3 target = new Vector3(0, 0, -1.5f);
            mySequence.Append(transform.DOMove(target, 2f));
            mySequence.Append(transform.DOLocalRotate(new Vector3(0, 90f, 0), 2f));
            mySequence.Append(rotationAxis.transform.DOLocalRotate(new Vector3(0, 170f, 0), 1.5f));
        } else {
            Vector3 target = initialPosition;
            mySequence.Append(transform.DOMove(target, 2f));
            mySequence.Prepend(transform.DOLocalRotate(new Vector3(0, 0, 0), 2f));
            mySequence.Prepend(rotationAxis.transform.DOLocalRotate(new Vector3(0, 0, 0), 1.5f));
        }

        
        mySequence.Play();
        isDisplayed = !isDisplayed;
    }

    //// Testing the movement of the game case
    //[ContextMenu("Test Move")]
    //public void TestMove()
    //{
    //    Tween myTween = transform.DOLocalRotate(new Vector3(0, 90f, 0), 2f).SetAutoKill(false);

    //    if (isForward) {
    //        myTween.Play();
    //    } else {
    //        myTween.Rewind();
    //    }

    //    isForward = !isForward;
    //}
}
