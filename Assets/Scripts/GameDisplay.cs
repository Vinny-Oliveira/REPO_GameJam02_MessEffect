using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GameDisplay : MonoBehaviour
{
    public GameCase game;
    public TextMeshProUGUI txtGameTitle;
    public Image gameCover;

    public bool isDisplayed;

    // Start is called before the first frame update
    void Start()
    {
        // Get the information from the game scriptable object and place it in the game object
        txtGameTitle.text = game.caseName; //GameManager.GetInstance().gameDictionary[game.caseName];
        gameCover.sprite = game.cover;
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
            Vector3 target = transform.position + new Vector3(0, 0, -1.5f);
            mySequence.Append(transform.DOMove(target, 2f));
            mySequence.Append(transform.DOLocalRotate(new Vector3(0, 90f, 0), 2f));
        } else {
            Vector3 target = transform.position + new Vector3(0, 0, 1.5f);
            mySequence.Append(transform.DOMove(target, 2f));
            mySequence.Prepend(transform.DOLocalRotate(new Vector3(0, 0, 0), 2f));
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
