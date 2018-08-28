using Unity.Entities;

namespace Assets.Scripts.ECS
{
    public class ZombieSpawnSystem : ComponentSystem
    {
        public static void SetUp(EntityManager entityManager)
        {
            var spawnerEntity = ZombieHordeBootstrap.Settings.SpawnPoints[0].GetComponent<GameObjectEntity>().Entity;
            entityManager.SetComponentData(spawnerEntity, new ZombieSpawner
            {
                spawnedCount = 0,
                spawnTerm = 0.1f,
            });
        }

        protected override void OnUpdate()
        {
            
        }
    }
}
