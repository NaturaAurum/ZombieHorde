using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Jobs;

namespace Assets.Scripts.ECS
{
    [System.Serializable]
    public struct ZombieSpawner : IComponentData
    {
        public int spawnedCount;
        public float spawnTerm;
    }

    public class ZombieSpawnerComponent : ComponentDataWrapper<ZombieSpawner>
    {
        
    }
}
