using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace Assets.Scripts.NonECS
{
    public class Zombie : MonoBehaviour
    {
        private Animator animator;
        private Vector3 direction;
        private LayerMask checkLayers;

        public float MoveSpeed = 1f;

        public Transform Head;

        private List<Vector3> path = new List<Vector3>();

        private void Awake()
        {
            animator = GetComponent<Animator>();
            checkLayers |= 1 << LayerMask.NameToLayer("Obstacles");
            checkLayers |= 1 << LayerMask.NameToLayer("Ground");
        }

        private void OnEnable()
        {
            direction = (SceneSettings.Instance.target.position - transform.position).normalized;
        }

        private void Update()
        {
            var dis = (transform.position - SceneSettings.Instance.target.position).magnitude;
            animator.SetInteger("Mode", (dis <= 1) ? 1 : 0);

            transform.position += direction * MoveSpeed * Time.deltaTime;

            if (Physics.Raycast(Head.position, transform.forward, 0.5f, checkLayers.value))
            {
                direction = Quaternion.Euler(0, 90f, 0) * direction;
                transform.LookAt(transform.position + direction);
            }
        }

        private void GeneratePath()
        {
            path.Clear();
            var target = SceneSettings.Instance.target;
            bool hasObs = Physics.Raycast(Head.position, target.position - Head.position, checkLayers.value);
            while (hasObs)
            {
                
            }
            path.Add(target.position);
        }
    }
}
