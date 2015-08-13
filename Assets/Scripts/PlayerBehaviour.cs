using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private Rigidbody2D _rigidbody;
    private bool paused = false;
    private float VerticalSpeed;

    public static float HorizontalSpeed = 0.5f;
    public static float PlayerAngle = 45;
    public Text power_text;
    public Text height_text;

    void OnEnable()
    {
        EventManager.onEventPause += OnEventPause;
        EventManager.onEventUnPause += OnEventUnPause;

        HorizontalSpeed = 0.5f;
        PlayerAngle = 45;

    }
    void OnDisable()
    {
        EventManager.onEventPause -= OnEventPause;
        EventManager.onEventUnPause -= OnEventUnPause;
    }

	// Use this for initialization
	void Start ()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        height_text.enabled = false;

        //Launch(1, 45);
        EventManager.instance.EventPause(0);
        _rigidbody.isKinematic = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (paused)
            return;

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

    private void Launch(float modifier, float angle, float flatpower = 0)
    {
        float power = HorizontalSpeed / Mathf.Cos(PlayerAngle * (Mathf.PI / 180));
        power = (power * modifier) + (flatpower / 100);
        PlayerAngle = angle;

        HorizontalSpeed = Mathf.Cos(angle * (Mathf.PI / 180)) * power;
        float verticalspeed = Mathf.Sin(angle * (Mathf.PI / 180)) * power * 30;

        Vector2 temp = _rigidbody.velocity;
        temp.y = verticalspeed;
        _rigidbody.velocity = temp;

        power_text.text = (power*100).ToString("F2") + "P";
        if(power*100 < 10)
        {
            Application.LoadLevel("menu");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (_rigidbody.isKinematic)
            return;

        if(other.CompareTag("Character"))
        {
            CharacterBehaviour characterstats = other.GetComponent<CharacterBehaviour>();
            Launch(characterstats.modifier, characterstats.angle, characterstats.flatpower);
            Destroy(other);
            EventManager.instance.EventPause();
            other.gameObject.GetComponent<CharacterBehaviour>().Event();
        }
        else if(other.CompareTag("Floor"))
        {
            Launch(0.95f, PlayerAngle, -3);
        }
    }

    public void StartLaunch(float angle, float power)
    {
        _rigidbody.isKinematic = false;
        EventManager.instance.EventUnPause();
        Launch(power, angle);
    }

    private void OnEventPause()
    {
        paused = true;
        VerticalSpeed = _rigidbody.velocity.y;
        _rigidbody.isKinematic = true;
    }
    private void OnEventUnPause()
    {
        paused = false;
        _rigidbody.isKinematic = false;

        Vector2 temp = _rigidbody.velocity;
        temp.y = VerticalSpeed;
        _rigidbody.velocity = temp;
    }
}
