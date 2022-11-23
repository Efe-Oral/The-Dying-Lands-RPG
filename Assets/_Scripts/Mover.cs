using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Animator animator;
    NavMeshAgent agent;

    PlayerController playerController;

    private void Start() 
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
           //playerController.MoveToCursor();
           GetComponent<PlayerController>().MoveToCursor();
        }
        UpdateAnimator();
    }

    public void MoveTo(Vector3 destination)
    {
        GetComponent<NavMeshAgent>().destination = destination;
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
