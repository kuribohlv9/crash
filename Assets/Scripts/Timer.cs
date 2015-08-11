using UnityEngine;
using System.Collections;

public class Timer {

    private float m_time;
    private float m_target;
    private float m_incremation;
    private bool m_active;

	// Use this for initialization
	void Start () {
        m_active = false;
        m_time = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float GetTime()
    {
        return m_time;
    }

    public float GetTarget()
    {
        return m_target;
    }

    public bool GetActive()
    {
        return m_active;
    }

    public bool TimerUpdate()
    {
        if (m_active)
        {
            m_time += m_incremation;
            if (m_time > m_target)
            {
                return true;
            }
        }
        return false;
    }

    public bool TimerUpdate(float value)
    {
        if (m_active)
        {
            m_time += value;
            if (m_time > m_target)
            {
                return true;
            }
        }
        return false;
    }

    public void SetTime(float value)
    {
        m_time = value;
    }

    public void SetTarget(float value)
    {
        m_target = value;
    }

    public void SetIncremation(float value)
    {
        m_incremation = value;
    }

    public void SetActive(bool state)
    {
        m_active = state;
    }

    public void Reset()
    {
        m_time = 0.0f;
        m_active = false;
    }
}