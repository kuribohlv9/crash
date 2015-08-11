using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    public static float HorizontalSpeed = 0.5f;
    public static float PlayerAngle = 45;

    private Rigidbody2D _rigidbody;

    public Text power_text;
    public Text height_text;


	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        Launch(1, 45);
        height_text.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y > 26)
        {
            height_text.enabled = true;
            height_text.text = transform.position.y.ToString("F2") + "m";
        }
        else
        {
            height_text.enabled = false;
        }
	}

    public void Launch(float modifier, float angle)
    {
        float power = HorizontalSpeed / Mathf.Cos(PlayerAngle * (Mathf.PI / 180));
        power *= modifier;
        PlayerAngle = angle;

        HorizontalSpeed = Mathf.Cos(angle * (Mathf.PI / 180)) * power;
        float verticalspeed = Mathf.Sin(angle * (Mathf.PI / 180)) * power * 30;

        Vector2 temp = _rigidbody.velocity;
        temp.y = verticalspeed;
        _rigidbody.velocity = temp;

        power_text.text = (power*100).ToString("F2") + "P";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Character"))
        {
            Launch(other.GetComponent<CharacterBehaviour>().modifier, other.GetComponent<CharacterBehaviour>().angle);
        }
        else if(other.CompareTag("Floor"))
        {
            Launch(0.9f, PlayerAngle);
        }
    }
}
