using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Jobs;

namespace Assets.Scripts.ECS
{
    [System.Serializable]
    public struct Zombie : IComponentData
    {
        public int checkLayers;
        public float3 target;
    }

    public class ZombieComponent : ComponentDataWrapper<Zombie>
    {
        public Animator animator;
    }
}
