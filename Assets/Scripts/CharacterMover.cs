using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacterMover : MonoBehaviour {

    public Text text;

    public float distance = 7.0f;
    private float distance_covered = 0;

    public GameObject[] characters;

    private Timer timer = new Timer();


	// Use this for initialization
	void Start () {
        timer.SetTarget(distance);
        timer.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
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
        GameObject temp = (GameObject)Instantiate(characters[Random.Range(0, characters.GetLength(0))], transform.position, transform.rotation);
        temp.transform.parent = transform;
    }
}
