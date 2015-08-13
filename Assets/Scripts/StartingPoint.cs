using UnityEngine;
using System.Collections;

public class StartingPoint : MonoBehaviour {

    private bool rotate_active = true;
    public GameObject player;
    private float angle = 0;

    [SerializeField]
    private float angle_incrementation = 0.2f;

    void OnEnable()
    {
        EventManager.onMousePress += onMousePress;
        EventManager.onMouseUp += onMouseUp;
    }
    void OnDisable()
    {
        EventManager.onMousePress -= onMousePress;
        EventManager.onMouseUp -= onMouseUp;
    }
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (rotate_active)
        {
            HandleRotating();
        }
	}

    void HandleRotating()
    {
        //Vector3 mousePosition = Input.mousePosition;
        ////mousePosition.z = 5.23f; //The distance between the camera and object
        //Vector3 object_pos = Camera.main.WorldToScreenPoint(transform.position);
        //mousePosition.x = mousePosition.x - object_pos.x;
        //mousePosition.y = mousePosition.y - object_pos.y;
        //float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        angle += angle_incrementation;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (angle > 90 || angle < 0)
        {
            angle_incrementation *= -1;
        }
    }

    void onMousePress()
    {
        rotate_active = false;
    }
    void onMouseUp()
    {
        rotate_active = true;
        Debug.Log(angle);
    }

    public void StartLaunch(float power)
    {
        if (angle < 10)
            angle = 10;
        else if (angle > 80)
            angle = 80;

        player.GetComponent<PlayerBehaviour>().StartLaunch(angle, power);
        gameObject.SetActive(false);
    }
}
