
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
namespace Assets.Scripts.ECS
{
    public sealed class ZombieHordeBootstrap
    {
        public static EntityArchetype BasicZombieArcheType;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();

            
        }
    }
}
