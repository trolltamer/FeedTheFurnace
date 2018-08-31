using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 The boundary area class is responsible for destroying any of the falling objects which are exiting the playspace, as well as sending events notifying other classes of this when relevant
 */

public class BoundaryArea : MonoBehaviour {

    public EventScriptableObject StickOBEventSO;
    public EventScriptableObject DynamiteOBEventSO;

    private ObjectTypeSO scoreType;
    private ObjectTypeSO loseType;

    private void Start()
    {
        //Should be Sticks at index 0
        scoreType = GameManager.Instance.GameData.SpawnablePrefabList[0].GetComponent<Spawnable>().objectType;
        //should be Dynamite at index 1
        loseType = GameManager.Instance.GameData.SpawnablePrefabList[1].GetComponent<Spawnable>().objectType;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ObjectTypeSO type = collision.gameObject.GetComponent<Spawnable>().objectType;
        Debug.Log(type.name);

        if(type == scoreType)
        {
            //Debug.Log("stick out of bounds");
            StickOBEventSO.Raise();
        }

        if (type == loseType)
        {
            //Debug.Log("dynamite out of bounds");
            DynamiteOBEventSO.Raise();
            
        }

        Destroy(collision.gameObject);
    }

}
