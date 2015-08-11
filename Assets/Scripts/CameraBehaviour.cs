using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;

    private Camera camera;

	// Use this for initialization
	void Start () {
        camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(player.transform.position.y < 7 && player.transform.position.y > 0)
        {
        camera.orthographicSize = player.transform.position.y + 9;

        Vector3 temp = camera.transform.position;
        temp.y = camera.orthographicSize - 5;
        camera.transform.position = temp;
        }
	}
}
