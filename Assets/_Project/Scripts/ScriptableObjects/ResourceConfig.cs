using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourceConfig", menuName = "ScriptableObjects/ResourceConfig", order = 1)]
public class ResourceConfig : ScriptableObject
{
    [Header("Player")]
    public GameObject PlayerPrefab;

    public Vector3 PlayerSpawnPosition;

    public float PlayerSpeed;
   
    [Header("AI")]
    public GameObject AIPrefab;

    public int  MaxActorCount;
    public int MinAICount;
    
    public float ActorSpeed;
    public Vector2 SpawnPositionBounds;

}
