using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenuButton : MonoBehaviour {

    private Button _button;

	// Use this for initialization
	void Start () {
        _button = GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Play()
    {
        Application.LoadLevel("game");
    }
}
