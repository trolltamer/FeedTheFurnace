using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 SpawnManager is a class responsible for randomly spawning gameobjects from a list of prefabs at a random location from a list of locations.
 SpawnManager also handles initialization of objects it creates.

The Spawn event instantiates the object and calls CalcSpawnInterval to determine the new spawnInterval, 
as well as calling InitiaizeSpawnedObject which assigns the sprite (will need to be reworked to easily swap sprites), and applies random torque
*/

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    List<Transform> spawnerList;
    [SerializeField]
    private float spawnInterval;
    private float baseSpawnInterval = 1f;
    private float baseTorque = 7.5f;
    [SerializeField]
    private float spawnIntervalNumerator = 10f;
    [SerializeField]
    private float minSpawnInterval = 0.15f;

    private Sprite StickSkin;
    private Sprite DynamiteSkin;

	// Use this for initialization
	void Start () {
        spawnInterval = baseSpawnInterval;

        StickSkin = GameManager.Instance.WardrobeManager.WardrobeData.StickSpriteList[ GameManager.Instance.WardrobeManager.WardrobeData.WardrobeIndexList[0].index ].UnlockableSprite;
        DynamiteSkin = GameManager.Instance.WardrobeManager.WardrobeData.DynamiteSpriteList[GameManager.Instance.WardrobeManager.WardrobeData.WardrobeIndexList[1].index].UnlockableSprite;
    }

    // Update is called once per frame
    void Update() {
        spawnInterval -= Time.deltaTime;
        if (spawnInterval <= 0)
        {
            Spawn();
        }
	}

    void Spawn()
    {
        int randomSpawnableIndex = Random.Range(0, GameManager.Instance.GameData.SpawnablePrefabList.Count);
        int randomLocationIndex = Random.Range(0, spawnerList.Count);

        GameObject spawnedObj = Instantiate(GameManager.Instance.GameData.SpawnablePrefabList[randomSpawnableIndex]);
        spawnedObj.transform.position = spawnerList[randomLocationIndex].position;

        InitializeSpawnedObj(spawnedObj);

        spawnInterval = CalcSpawnInterval();
    }

    float CalcSpawnInterval(){
    
        float multiplier = Mathf.Max(1, GameManager.Instance.GameData.currentScoreMultiplier.Value);

        float returnVal = Mathf.Min(baseSpawnInterval, Mathf.Max( (spawnIntervalNumerator/multiplier), minSpawnInterval));
        //Debug.Log("spawn interval:" + returnVal);

        return returnVal;
    }

    void InitializeSpawnedObj(GameObject spawnedObj)
    {
        ObjectTypeSO type = spawnedObj.GetComponent<Spawnable>().objectType;

        if (type == GameManager.Instance.GameData.SpawnablePrefabList[0].GetComponent<Spawnable>().objectType) //stick
        {
            spawnedObj.GetComponent<SpriteRenderer>().sprite = StickSkin;
        }
        else if (type == GameManager.Instance.GameData.SpawnablePrefabList[1].GetComponent<Spawnable>().objectType) //dynamite
        {
            spawnedObj.GetComponent<SpriteRenderer>().sprite = DynamiteSkin;
        }

        float randomSpinForce = Random.Range(-2, 2);

        Rigidbody2D spawnedRB2D = spawnedObj.GetComponent<Rigidbody2D>();

        spawnedRB2D.AddTorque(baseTorque * randomSpinForce);

        spawnedRB2D.gravityScale = GameManager.Instance.GameData.spawnableGravityScale;
    }
}
