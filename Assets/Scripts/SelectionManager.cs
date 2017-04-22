using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private bool _selectionMade = false;
    public GameObject FirstButton;

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) ||
            (Input.GetKeyDown(KeyCode.DownArrow) ||
            (Input.GetKeyDown(KeyCode.LeftArrow) ||
            (Input.GetKeyDown(KeyCode.RightArrow)) &&
            _selectionMade == false)
        {
            print("key was pressed");
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(FirstButton);
            _selectionMade = true;
        }
    }
}