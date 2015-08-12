using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

    private static EventManager _instance;

    public static EventManager instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<EventManager>();
            return _instance;
        }
    }



    public delegate void OnMousePress(); //This is the event type
    public static event OnMousePress onMousePress; // Use this for initialization

    public delegate void OnMouseUp();
    public static event OnMouseUp onMouseUp;

    public delegate void OnEventPause();
    public static event OnEventPause onEventPause;

    public delegate void OnEventUnPause();
    public static event OnEventUnPause onEventUnPause;

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

    public void EventPause()
    {
        onEventPause();
        StartCoroutine(Wait());
    }
    public void EventUnPause()
    {
        onEventUnPause();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        EventUnPause();
    }
}
