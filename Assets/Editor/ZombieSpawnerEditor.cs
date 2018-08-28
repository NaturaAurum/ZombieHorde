using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Assets.Scripts.NonECS;
[CustomEditor(typeof(ZombieSpawner))]
public class ZombieSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Get Spawn Points"))
        {
            (target as ZombieSpawner).GetSpawnPoints();
        }
    }
}
