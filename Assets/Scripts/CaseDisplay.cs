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
        gameCover.sprite = gameCase.cover;

        // Get the initial position
        initialPosition = transform.position;

        // The disc that is inside
        CheckForDiscInside();

        // Populate the dictionary of games
        GameManager.GetInstance().gameDictionary.Add(gameCase.gameName, false); // Game and case do not match at start
    }

    /// <summary>
    /// Check if the the disc inside this box belongs to it
    /// </summary>
    [ContextMenu("Check if match")]
    public void CheckIfMatch() { /**** Eventually, this function should return a boolean so we can check if all games match their cases ****/
        CheckForDiscInside();

        if (disc == null) { // If there is no disc inside the case
            GameManager.GetInstance().gameDictionary[gameCase.gameName] = false;
            Debug.Log("The case is empty.");
        } else if (gameCase.gameName == disc.gameDisc.gameName) { // Checks if the disc inside matches with the case
            GameManager.GetInstance().gameDictionary[gameCase.gameName] = true;
            GameManager.GetInstance().CheckForAllMatches();
            Debug.Log("Great! This is the right disc!");
        } else {
            GameManager.GetInstance().gameDictionary[gameCase.gameName] = false;
            Debug.Log("This disc does not belong to this case");
        }
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
            mySequence.Append(transform.DOMove(target, TRANSTATION_TIME)); // Move towards player
            mySequence.Append(transform.DOLocalRotate(ROTATION_CASE, ROTATION_TIME)); // Rotate the front of the case to the player
            mySequence.Append(rotationAxis.transform.DOLocalRotate(ROTATION_OPEN_CASE, OPEN_CLOSE_TIME).OnStepComplete(AttachToGameManager)); // Open the case and make it manageable by the Game Manager
            mySequence.OnStart(GameManager.GetInstance().ChangeClickingState); // Prevent other games to be clicked
        } else { // The case closes
            Vector3 target = initialPosition;
            mySequence.Append(transform.DOMove(target, TRANSTATION_TIME).OnStepComplete(GameManager.GetInstance().ChangeClickingState)); // Allows games to be clicked again
            mySequence.Prepend(transform.DOLocalRotate(Vector3.zero, ROTATION_TIME));
            mySequence.Prepend(rotationAxis.transform.DOLocalRotate(Vector3.zero, OPEN_CLOSE_TIME).OnStepComplete(CheckIfMatch));
            mySequence.OnStart(DetachFromGameManager);
        }

        // Play the tween and switch the display value
        mySequence.Play().OnComplete(ChangeTweeingState);
        isDisplayed = !isDisplayed;
    }

    /// <summary>
    /// Make this case an object of the Game Manager
    /// </summary>
    void AttachToGameManager() {
        GameManager.GetInstance().caseOnDisplay = gameObject;
    }

    /// <summary>
    /// Erase the case displayed in the Game Manager
    /// </summary>
    void DetachFromGameManager() {
        GameManager.GetInstance().caseOnDisplay = null;
    }

    /// <summary>
    /// Check if there are discs inside the case
    /// </summary>
    public void CheckForDiscInside() {
        disc = GetComponentInChildren<DiscDisplay>();
    }

    /// <summary>
    /// Make the game case move when it is clicked
    /// </summary>
    private void OnMouseDown()
    {
        // Do nothing if the game is either paused or over
        if (GameManager.GetInstance().isGamePaused || GameManager.GetInstance().isGameOver) { return; }

        /* Case not moving AND (The case is displayed OR Multiple cases may be clicked) */
        if (!isTweening && (isDisplayed || GameManager.GetInstance().isClickable)) {
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
