using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceConfig", menuName = "ScriptableObjects/ResourceConfig", order = 1)]
public class ResourceConfig : ScriptableObject
{
    [Header("Player")]
    public GameObject PlayerPrefab;

    public Vector3 PlayerSpawnPosition;
   
    [Header("Prize")]
    public GameObject PrizePrefab;

    public int  PrizeCount;

    public Vector2 SpawnPositionBounds;

}
