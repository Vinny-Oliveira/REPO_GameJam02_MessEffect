using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CaseDisplay : MonoBehaviour
{
    // Game information of the game case
    public Game gameCase;

    // UI Elements
    //public TextMeshProUGUI txtGameTitle;
    public Image gameCover;

    // Tweening variables - Vectors
    Vector3 OUTSIDE_POSITION = new Vector3(0, 0, -1.5f);
    Vector3 ROTATION_CASE = new Vector3(0, 90f, 0);
    Vector3 ROTATION_OPEN_CASE = new Vector3(0, 170f, 0);

    // Tweening variables - Time dirations
    const float TRANSTATION_TIME = 1.5f;
    const float ROTATION_TIME = 1f;
    const float OPEN_CLOSE_TIME = 1f;

    // Control variables
    public GameObject rotationAxis;
    private Vector3 initialPosition;
    public bool isDisplayed;
    private bool isTweening;

    // The disc inside
    public DiscDisplay disc;

    // Start is called before the first frame update
    void Start()
    {
        // Get the information from the game scriptable object and place it in the game object
        //txtGameTitle.text = gameCase.gameName; //GameManager.GetInstance().gameDictionary[game.caseName];
        gameCover.sprite = gameCase.cover;

        // Get the initial position
        initialPosition = transform.position;

        // The disc that is inside
        disc = GetComponentInChildren<DiscDisplay>();
    }

    /// <summary>
    /// Check if the the disc inside this box belongs to it
    /// </summary>
    [ContextMenu("Check if match")]
    public void CheckIfMatch() { /**** Eventually, this function should return a boolean so we can check if all games match their cases ****/
        if (disc == null) { // If there is no disc inside the case
            Debug.Log("The case is empty.");
        } else if (gameCase.gameName == disc.gameDisc.gameName) { // Checks if the disc inside matches with the case
            Debug.Log("Great! This is the right disc!");
        } else {
            Debug.Log("This disc does not belong to this case");
        }

        //if (gameCase.IsMatch()) {
        //    Debug.Log("Great! This is the right disc!");
        //} else {
        //    Debug.Log("This disc does not belong to this case"); 
        //}
    }

    /// <summary>
    /// Make the game case move towards the player and open; also, make it close and move away from the player
    /// </summary>
    [ContextMenu("Make game move")]
    public void MakeGameMove() {
        ChangeTweeingState(); // Change the state right before the movement starts to avoid double clicks

        Sequence mySequence = DOTween.Sequence();

        if (!isDisplayed) { // The case opens for the player
            Vector3 target = OUTSIDE_POSITION;
            mySequence.Append(transform.DOMove(target, TRANSTATION_TIME).OnStart(GameManager.GetInstance().ChangeClickingState)); // Prevent other games to be clicked
            mySequence.Append(transform.DOLocalRotate(ROTATION_CASE, ROTATION_TIME));
            mySequence.Append(rotationAxis.transform.DOLocalRotate(ROTATION_OPEN_CASE, OPEN_CLOSE_TIME));
        } else { // The case closes
            Vector3 target = initialPosition;
            mySequence.Append(transform.DOMove(target, TRANSTATION_TIME).OnStepComplete(GameManager.GetInstance().ChangeClickingState)); // Allows games to be clicked again
            mySequence.Prepend(transform.DOLocalRotate(Vector3.zero, ROTATION_TIME));
            mySequence.Prepend(rotationAxis.transform.DOLocalRotate(Vector3.zero, OPEN_CLOSE_TIME));
        }

        // Play the tween and switch the display value
        mySequence.Play().OnComplete(ChangeTweeingState);
        isDisplayed = !isDisplayed;
    }

    /// <summary>
    /// Make the game case move when it is clicked
    /// </summary>
    private void OnMouseDown()
    {
        if ((!isTweening && isDisplayed) || (!isTweening && GameManager.GetInstance().isClickable)) {
            MakeGameMove();
        }
    }

    /// <summary>
    /// Set the proper state of the object depending on whether it is tweening on not
    /// </summary>
    private void ChangeTweeingState() {
        isTweening = !isTweening;
    }
}
