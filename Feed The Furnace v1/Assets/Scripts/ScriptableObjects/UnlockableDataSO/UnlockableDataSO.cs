using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UnlockableDataSO : ScriptableObject {

    public Sprite UnlockableSprite;
    public GameObject UnlockableGameObject;
    public bool Unlocked;
    public int Price;

}
