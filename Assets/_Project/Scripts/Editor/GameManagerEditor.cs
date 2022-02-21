using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MudioGames.Showcase.Managers;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    List<GameObject> _pooledObjects = new List<GameObject>();
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var ie = (GameManager)target;
        GUILayout.Space(5);
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Create"))
        {
            // var pooledObject = ie..Spawn(Random.insideUnitCircle * 10.0f, Vector3.zero);
            // if (pooledObject != null)
            // {
            //     _pooledObjects.Add(pooledObject);
            // }
        }
        else if (GUILayout.Button("Release"))
        {
            // var pooledObject = _pooledObjects.FirstOrDefault();
            // if (pooledObject != null)
            // {
            //     ie.PoolingService.Release(pooledObject);
            //     _pooledObjects.Remove(pooledObject);
            // }

        }

        GUILayout.EndHorizontal();

    }
}
