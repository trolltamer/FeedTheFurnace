using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 EventSO class is to create asset bound events that can easily be swapped and built in the inspector without having to modify/register within other scripts,
 simply attach EventListenerMono to any subscribers and add eventSO variables to publishers. Create EventSO's in create asset menu
     */

[CreateAssetMenu]
public class EventScriptableObject : ScriptableObject {

    List<EventListenerMono> ListenerList = new List<EventListenerMono>();

    public void Raise()
    {
        for (int i = 0; i < ListenerList.Count; i++)
        {
            Debug.Log("Event SO Raising Event" + this.name + " to listeners");
            ListenerList[i].OnEventRaised();
        }
    }

    public void RegisterListeners(EventListenerMono listener)
    {

        if (!ListenerList.Contains(listener))
        {
            ListenerList.Add(listener);
        }
    }

    public void DeRegisterListeners(EventListenerMono listener)
    {
        if (ListenerList.Contains(listener))
        {
            ListenerList.Remove(listener);
        }
    }

}
