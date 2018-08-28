using Assets.Scripts.NonECS;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

namespace Assets.Scripts.ECS
{
    public class ZombieSpawnSystem : ComponentSystem
    {

        private ZombieSpawnerComponent zombieSpawnerComponent;
        private Entity zombieSpawnerEntity;

        public static void SetUp(EntityManager entityManager)
        {
            //var spawnerEntity = ZombieHordeBootstrap.Settings.SpawnPoints[0].GetComponent<GameObjectEntity>().Entity;
            //entityManager.SetComponentData(spawnerEntity, new ZombieSpawner
            //{
            //    spawnedCount = 0,
            //    spawnTerm = 0.1f,
            //});
        }

        protected override void OnStartRunning()
        {
            zombieSpawnerComponent = ZombieHordeBootstrap.Settings.SpawnPoints[ 0 ].GetComponent<ZombieSpawnerComponent>();
            zombieSpawnerEntity = zombieSpawnerComponent.GetComponent<GameObjectEntity>().Entity;
            spawnTerm = zombieSpawnerComponent.Value.spawnTerm;
        }

        private float spawnTerm = 0f;
        private float spawnTimer = 0f;
        protected override void OnUpdate()
        {
            spawnTimer += Time.deltaTime;
            if(spawnTimer >= spawnTerm)
            {
                spawnTimer = 0f;
                Spawn();
            }
        }

        private void Spawn()
        {
            var zombieEntity = Object.Instantiate( ZombieHordeBootstrap.Settings.ZombiePrefab ).GetComponent<GameObjectEntity>().Entity;
            var spawnPoint = ZombieHordeBootstrap.Settings.GetSpawnPoint();
            EntityManager.SetComponentData( zombieEntity, new Position() { Value = spawnPoint.position } );
            EntityManager.SetComponentData( zombieEntity, new Rotation() { Value = spawnPoint.rotation } );
            LayerMask layer = 0;
            layer |= LayerMask.NameToLayer( "Obstacles" );
            layer |= LayerMask.NameToLayer( "Groud" );
            EntityManager.SetComponentData( zombieEntity, new Zombie()
            {
                checkLayers = layer,
                target = SceneSettings.Instance.target.position
            } );
            EntityManager.SetComponentData( zombieSpawnerEntity, new ZombieSpawner()
            {
                spawnedCount = zombieSpawnerComponent.Value.spawnedCount + 1
            } );
        }
    }
}
