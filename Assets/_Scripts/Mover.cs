using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Animator animator;
    NavMeshAgent agent;

    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           MoveToCursor();
        }
        UpdateAnimator();
    }

        private void MoveToCursor()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 
            bool hasHit = Physics.Raycast(ray, out hit);
            if(hasHit)
            {
                agent.SetDestination(hit.point);
            }
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
