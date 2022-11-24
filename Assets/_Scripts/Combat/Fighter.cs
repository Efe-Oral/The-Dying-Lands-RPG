using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        Transform target;
        Mover mover;
        [SerializeField] float weaponRange = 5f;

        private void Start() 
        {
            mover = GetComponent<Mover>();
        }

        private void Update() 
        {
            if(target != null)
            {
                float distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
                if(distance <= weaponRange)
                {
                    mover.Stop();
                }
                else
                {
                    mover.MoveTo(target.position);
                }
            }
        }
        public void Attack(CombatTarget CombatTarget)
        {
            target = CombatTarget.transform;  
        }

        //void OnDrawGizmos()
        //{
            //Gizmos.color = Color.yellow;
            //Gizmos.DrawSphere(target.transform.position, stoppingDistance);
        //}
    }
}

