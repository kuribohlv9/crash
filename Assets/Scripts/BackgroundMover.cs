using UnityEngine;
using System.Collections;

public class BackgroundMover : MonoBehaviour {

    private bool paused = false;
    void OnEnable()
    {
        EventManager.onEventPause += OnEventPause;
        EventManager.onEventUnPause += OnEventUnPause;
    }
    void OnDisable()
    {
        EventManager.onEventPause -= OnEventPause;
        EventManager.onEventUnPause -= OnEventUnPause;
    }
	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(paused)
            return;

        MoveChildren();
	}

    void MoveChildren()
    {
        foreach (Transform child in transform)
        {
            Vector2 temp;
            if (child.transform.position.x < -64.699999f)
            {
                temp = child.transform.position;
                temp.x += 64.699999f*2;
                child.transform.position = temp;
            }

            temp = child.position;
            temp.x -= PlayerBehaviour.HorizontalSpeed / 2;
            child.position = temp;
        }
    }

    private void OnEventPause()
    {
        paused = true;
    }
    private void OnEventUnPause()
    {
        paused = false;
    }
}
