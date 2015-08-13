using UnityEngine;
using System.Collections;

public class ChargeMeterBehaviour : MonoBehaviour {

    [SerializeField]
    private float charge_value = 0.05f;
    public GameObject startPoint;
    private bool charge_active = false;

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

        if(charge_active)
        {
            HandleCharge();
        }
	}

    void HandleCharge()
    {
        Vector3 temp = transform.localScale;
        temp.y += charge_value;
        transform.localScale = temp;

        temp = transform.localPosition;
        temp.y += charge_value / 2;
        transform.localPosition = temp;

        if (transform.localScale.y > 5 || transform.localScale.y < 0)
        {
            charge_value *= -1;
        }
    }

    void onMousePress()
    {
        charge_active = true;
    }
    void onMouseUp()
    {
        charge_active = false;
        float power = Mathf.Clamp(transform.localScale.y / 5 * 100, 0, 100);
        Debug.Log(power);
        startPoint.GetComponent<StartingPoint>().StartLaunch(power/100);
        gameObject.SetActive(false);
    }
}
