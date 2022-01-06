using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TrialEvent : UnityEvent<string>
{
}

public class GameEngine : MonoBehaviour
{
    public TrialEvent m_MyEvent;

    void Start()
    {
        if (m_MyEvent == null)
            m_MyEvent = new TrialEvent();

        m_MyEvent.AddListener(Ping);
    }

    void Update()
    {
        if (Input.anyKeyDown && m_MyEvent != null)
        {
            m_MyEvent.Invoke("Hello");
        }
    }

    void Ping(string i)
    {
        Debug.Log("Ping" + i);
    }
}
