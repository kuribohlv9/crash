using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

    public delegate void OnMousePress(); //This is the event type
    public static event OnMousePress onMousePress; // Use this for initialization

    public delegate void OnMouseUp();
    public static event OnMouseUp onMouseUp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            onMousePress();
        }

        if(Input.GetMouseButtonUp(0))
        {
            onMouseUp();
        }
	}
}
