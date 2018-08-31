using UnityEngine;
using UnityEngine.Events;

/*
 Handles event responses, registrationa and deregistration and ties in unity event editor gui
     */

public class EventListenerMono : MonoBehaviour {

    public EventScriptableObject Event;
    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListeners(this);
    }

    private void OnDisable()
    {
        Event.DeRegisterListeners(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}
