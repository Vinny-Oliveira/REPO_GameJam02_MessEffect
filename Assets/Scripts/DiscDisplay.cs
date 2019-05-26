using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiscDisplay : MonoBehaviour
{
    public Game gameDisc;

    // UI Elements
    public TextMeshProUGUI txtGameTitle;
    public Image gameCover;

    // Drag and drop variables
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Get the information from the game scriptable object and place it in the game object
        //txtGameTitle.text = gameDisc.gameName; //GameManager.GetInstance().gameDictionary[game.caseName];
        gameCover.sprite = gameDisc.cover;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    /// <summary>
    /// When the mouse clicks on the disc, obtain information about its position
    /// </summary>
    void OnMouseDown() {
        initialPosition = transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); // To obtain the z coordinate of the object

        // The "distance" between the mouse and the object
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    /// <summary>
    /// Drag the disc around the screen
    /// </summary>
    private void OnMouseDrag()
    {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;
        transform.position = cursorPosition;
    }

    private void OnMouseUp()
    {
        Vector3 discHolderPosition = GameManager.GetInstance().discHolder.transform.position;

        if (Vector3.Distance(transform.position, discHolderPosition) < 1f) {
            transform.position = discHolderPosition;
            transform.parent = GameManager.GetInstance().discHolder.transform;
        } else {
            transform.position = initialPosition;
        }
    }
}
