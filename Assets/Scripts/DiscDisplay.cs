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

    void OnMouseDown() {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position); // So obtain the z coordinate of the object

        // The "distance" between the mouse and the object
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;
        transform.position = cursorPosition;
    }
}
