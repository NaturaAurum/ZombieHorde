using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.NonECS
{
    public static class ZombieCounter
    {
        public static int count = 0;
    }
    public class ZombieSpawner : MonoBehaviour
    {
        public GameObject ZombiePrefab = null;
        public float ZombieSpawnTick;

        public Transform[] zombieSpawnPoints;

        public void GetSpawnPoints()
        {
            zombieSpawnPoints = GetComponentsInChildren<Transform>();
        }

        private void OnDrawGizmos()
        {
            if (zombieSpawnPoints != null && zombieSpawnPoints.Length > 0)
            {
                Gizmos.color = Color.cyan;
                foreach (var spawnPoint in zombieSpawnPoints)
                {
                    Gizmos.DrawCube(spawnPoint.position, Vector3.one * 0.5f);
                }
            }
        }

        private IEnumerator Start()
        {
            yield return null;
            while (true)
            {
                yield return new WaitForSeconds(ZombieSpawnTick);
                var randomPoint = zombieSpawnPoints[Random.Range(0, zombieSpawnPoints.Length)];
                Instantiate(ZombiePrefab, randomPoint.position, randomPoint.rotation);
                ZombieCounter.count++;
            }
        }

        private void OnGUI()
        {
            GUI.TextField(new Rect(0, 0, 200, 20), ZombieCounter.count.ToString());
        }
    }
}
