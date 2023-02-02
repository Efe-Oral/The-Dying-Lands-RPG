using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] Animator animator;
        NavMeshAgent agent;
        Fighter fighter;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            fighter = GetComponent<Fighter>();
        }

        void Update()
        {
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            fighter.Cancel();
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            agent.isStopped = false;
            agent.destination = destination;
        }

        public void Stop()
        {
            agent.isStopped = true;
        }

        private void UpdateAnimator()
        {
            // Get the speed form the navmesh agent
            Vector3 velocity = agent.velocity;
            // Convert the agent's velocity to local velocity
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            // We only interested in the z velocity because that is tha axis our player walks in
            float speed = localVelocity.z;
            animator.SetFloat("forwardSpeed", speed);
        }
    }
}

