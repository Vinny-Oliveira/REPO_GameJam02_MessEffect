using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiscDisplay : MonoBehaviour
{
    public Game gameDisc;

    // UI Elements
    //public TextMeshProUGUI txtGameTitle;
    public Image gameCover;

    // Drag and drop variables
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 initialPosition;
    const float DISTANCE_TO_SLOT = 0.5f;

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

    /// <summary>
    /// Make the game go to the disc holder or back to the case when the mouse button is released
    /// </summary>
    private void OnMouseUp() {
        GameObject goDiscHolder1 = GameManager.GetInstance().discHolder1;
        GameObject goDiscHolder2 = GameManager.GetInstance().discHolder2;

                /* Disc holder is empty */                                      /* Disc holder is in range */
        if ((!goDiscHolder1.GetComponent<DiscHolder>().HasChildren()) && (Vector3.Distance(transform.position, goDiscHolder1.transform.position) < DISTANCE_TO_SLOT)) { // Distance to 1st disc holder
            AttachToDiscHolder(goDiscHolder1);
        } else if ((!goDiscHolder2.GetComponent<DiscHolder>().HasChildren()) && (Vector3.Distance(transform.position, goDiscHolder2.transform.position) < DISTANCE_TO_SLOT)) { // Distance to 2nd disc holder
            AttachToDiscHolder(goDiscHolder2);
        } else {
            transform.position = initialPosition;
        }
    }

    /// <summary>
    /// Place the disc in the disc holder and make it a child of the holder
    /// </summary>
    /// <param name="inNewPosition"></param>
    /// <param name="inNewParent"></param>
    void AttachToDiscHolder(GameObject inNewParent) {
        transform.position = inNewParent.transform.position;
        transform.parent = null;
        transform.parent = inNewParent.transform;
        //inNewParent.GetComponent<DiscHolder>().isParent = true;
    }
}
