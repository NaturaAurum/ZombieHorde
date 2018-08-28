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
        public Mesh ZombieMesh;
        public Material ZombieMaterial;

        private void OnDrawGizmos()
        {
            if (SpawnPoints != null && SpawnPoints.Length > 0)
            {
                Gizmos.color = Color.cyan;
                foreach (var spawnPoint in SpawnPoints)
                {
                    Gizmos.DrawCube( spawnPoint.position, Vector3.one * 0.5f );
                }
            }
        }

        public Transform GetSpawnPoint()
        {
            return SpawnPoints[ Random.Range( 0, SpawnPoints.Length ) ];
        }
    }
}
