using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selectedObject;
    public GameObject lastSelectedObject;
    public GameObject top;
    public GameObject buttom;

    private bool buttonSelected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;
        }
        if (buttonSelected)
        {
            if (eventSystem.currentSelectedGameObject == top && Input.GetAxisRaw("Vertical") == 1)
            {
                eventSystem.SetSelectedGameObject(lastSelectedObject);
            }
            if (eventSystem.currentSelectedGameObject == buttom && Input.GetAxisRaw("Vertical") == -1)
            {
                eventSystem.SetSelectedGameObject(selectedObject);
            }
        }
        
    }

    private void OnDisable()
    {
        buttonSelected = false;
    }
}
