using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ECS
{
#if UNITY_EDITOR
    using UnityEditor;
    [CustomEditor(typeof(ZombieHordeSettings))]
    public class ZombieHordeSettingsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Set Spawn Point"))
            {
                var spawnerGO = GameObject.Find("ZombieSpawner_ECS");
                (target as ZombieHordeSettings).SpawnPoints = spawnerGO?.GetComponentsInChildren<Transform>();
            }
        }
    }
#endif
    public class ZombieHordeSettings : MonoBehaviour
    {
        public GameObject ZombiePrefab;
        public Transform[] SpawnPoints;
    }
}
