using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.NonECS
{
    public class SceneSettings : MonoBehaviour
    {
        private static SceneSettings instance = null;
        public static SceneSettings Instance
        {
            get
            {
                return instance;
            }
        }

        public Transform target;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            if (target)
            {
                Gizmos.DrawCube(target.position, Vector3.one * 0.5f);
            }
        }
    }
}