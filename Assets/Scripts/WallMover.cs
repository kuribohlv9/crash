using UnityEngine;
using System.Collections;

public class WallMover : MonoBehaviour {

    private Timer timer = new Timer();
    private bool paused = false;

    public float distance;
    public GameObject wall;

	// Use this for initialization
	void Start ()
    {
        timer.SetActive(true);
        timer.SetTarget(distance);

        EventManager.onEventPause += OnEventPause;
        EventManager.onEventUnPause += OnEventUnPause;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (paused)
            return;

        MoveChildren();

        if (timer.TimerUpdate(PlayerBehaviour.HorizontalSpeed))
        {
            CreateCharacter();
            timer.SetTime(timer.GetTime() - timer.GetTarget());
        }
	}

    void MoveChildren()
    {
        foreach (Transform child in transform)
        {
            if (child.transform.position.x < -30)
            {
                Destroy(child.gameObject);
            }

            Vector2 temp = child.position;
            temp.x -= PlayerBehaviour.HorizontalSpeed;
            child.position = temp;
        }
    }

    void CreateCharacter()
    {
        GameObject temp = (GameObject)Instantiate(wall, transform.position, transform.rotation);
        temp.transform.parent = transform;
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
