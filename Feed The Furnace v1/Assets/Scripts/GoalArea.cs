using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
 GoalArea handles collisions with spawnable objects, awarding points for certain types, and taking damage/losing for others. Other types can be added and new effects/behaviours as well
 */

public class GoalArea : MonoBehaviour {

    public EventScriptableObject scoreEventSO;
    public EventScriptableObject loseEventSO;

    private ObjectTypeSO scoreType;
    private ObjectTypeSO loseType;

    private void Awake()
    {
        //Should be Sticks at index 0
        scoreType = GameManager.Instance.GameData.SpawnablePrefabList[0].GetComponent<Spawnable>().objectType;
        //should be Dynamite at index 1
        loseType = GameManager.Instance.GameData.SpawnablePrefabList[1].GetComponent<Spawnable>().objectType;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedGameObject = collision.gameObject;
        ObjectTypeSO type = collidedGameObject.GetComponent<Spawnable>().objectType;


        
        if (type == scoreType)
        {
            //Score(collidedGameObject);
            scoreEventSO.Raise();
            Destroy(collidedGameObject);
        }
        else         
        if (type == loseType)
        {
            //Lose(collidedGameObject);
            loseEventSO.Raise();
            Destroy(collidedGameObject);
        }
        else Debug.LogError("spawnable type not found");
        return;
    }

}
