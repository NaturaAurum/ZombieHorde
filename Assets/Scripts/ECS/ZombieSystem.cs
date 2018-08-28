using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Jobs;

namespace Assets.Scripts.ECS
{
    public class ZombieSystem : JobComponentSystem
    {

        struct ZombieData
        {
            public ComponentDataArray<Position> positions;
            [ReadOnly] public ComponentDataArray<Rotation> rotations;
            [ReadOnly] public ComponentDataArray<MoveSpeed> moveSpeeds;
            [ReadOnly] public ComponentDataArray<Zombie> zombies;
        }

        ComponentGroup zombieGroup;

        protected override void OnCreateManager( int capacity )
        {
            zombieGroup = GetComponentGroup
            (
                typeof( Position ),
                ComponentType.ReadOnly(typeof(Rotation)),
                ComponentType.ReadOnly(typeof(MoveSpeed)),
                ComponentType.ReadOnly(typeof(Zombie))
            );
        }

        protected override JobHandle OnUpdate( JobHandle inputDeps )
        {
            return base.OnUpdate( inputDeps );
        }
    }
}
