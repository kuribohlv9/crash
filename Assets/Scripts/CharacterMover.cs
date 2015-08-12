using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacterMover : MonoBehaviour {

    private bool paused = false;
    private float distance_covered = 0;
    private Timer timer = new Timer();

    public Text text;
    public float distance = 7.0f;
    public GameObject[] characters;

	// Use this for initialization
	void Start ()
    {
        timer.SetTarget(distance);
        timer.SetActive(true);

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
            timer.SetTime(0);
        }
	}

    void MoveChildren()
    {
        foreach(Transform child in transform)
        {
            if (child.transform.position.x < -30)
            {
                Destroy(child.gameObject);
            }

            Vector2 temp = child.position;
            temp.x -= PlayerBehaviour.HorizontalSpeed;
            child.position = temp;

            distance_covered += PlayerBehaviour.HorizontalSpeed;
            
            text.text = (distance_covered / 10).ToString("F2") + "m";
        }
    }

    void CreateCharacter()
    {
        int roll = Random.Range(1, 100);
        if(roll < 45)
        {
            GameObject temp = (GameObject)Instantiate(characters[0], transform.position, transform.rotation);
            temp.transform.parent = transform;
        }
        else if(roll < 90)
        {
            GameObject temp = (GameObject)Instantiate(characters[1], transform.position, transform.rotation);
            temp.transform.parent = transform;
        }
        else if(roll < 100)
        {
            GameObject temp = (GameObject)Instantiate(characters[2], transform.position, transform.rotation);
            temp.transform.parent = transform;
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
