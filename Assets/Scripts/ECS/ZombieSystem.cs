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

        struct ZombieGroup
        {
            public ComponentDataArray<Position> positions;
            public ComponentDataArray<Rotation> rotations;
            public ComponentDataArray<Zombie> zombies;
        }

        [Inject] private ZombieGroup zombieGroup;

        [BurstCompile]
        struct ZombieTransform : IJobParallelForTransform
        {
            public ComponentDataArray<Position> positions;
            public ComponentDataArray<Rotation> rotations;
            public ComponentDataArray<Zombie> zombies;

            public void Execute(int index, TransformAccess transform)
            {
                
            }
        }
    }
}
