using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 GameData is a class to hold data that is used by multiple managers so it can be stored and accessed in an abstracted way, especially used for depenency injections

    The SpawnablePrefabList, manually injected through the inspector is a key refence for type comparisons. Check the inspector to figure out which indexes should be compared.

    The wardrobe portion of the class is centralized through the inspector, WardrobeIndexList and WardrobeIndexSO scriptable object instances.
    To make an easily swappable skin system for sprites and particle systems create a new public list of either sprites or gameobjeccts, as well as a WardrobeIndexSO.
    Rather than instantiating from a direct reference to a sprite or prefab the WardrobeIndexSO instance of the specific list can be instantiated.

    eg WardrobeIndexList[0] contains a WardrobeIndexSO asset called StickSpriteIndex that contains an int index. 
       When instantiating a Stick, the sprite is determined by StickSpriteList[WardrobeIndexList[0]]
 */

public class GameData : MonoBehaviour{

    public List<GameObject> SpawnablePrefabList;

    public GameObject GoalAreaPrefab;

    public float spawnableGravityScale = 0.5f;

    public FloatVariableSO currentGameScore;

    public FloatVariableSO currentScoreMultiplier;


}
