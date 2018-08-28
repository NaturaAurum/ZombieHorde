
using System;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.ECS
{
    public sealed class ZombieHordeBootstrap
    {
        public static EntityArchetype BasicZombieArcheType;
        public static ZombieHordeSettings Settings;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            var entityManager = World.Active.GetOrCreateManager<EntityManager>();
            ZombieSpawnSystem.SetUp(entityManager);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void InitilizeAfterSceneLoad()
        {
            var settingsGO = GameObject.Find("Settings");
            if (settingsGO == null)
            {
                SceneManager.sceneLoaded += OnSceneLoaded;
                return;
            }
            SetSettings();
        }

        private static void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            SetSettings();
        }

        private static void SetSettings()
        {
            var settingsGO = GameObject.Find("Settings");
            Settings = settingsGO?.GetComponent<ZombieHordeSettings>();
        }
    }
}
