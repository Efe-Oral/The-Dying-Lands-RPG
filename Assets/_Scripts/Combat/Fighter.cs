using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Movement;
using Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        Transform target;
        Mover mover;
        [SerializeField] float weaponRange = 5f;
        ActionScheduler actionScheduler;
        

        private void Start() 
        {
            mover = GetComponent<Mover>();
        }

        private void Update() 
        {
            if(target == null) return;

            if(target != null)
            {
                float distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
                if(distance <= weaponRange)
                {
                    mover.Stop();
                    target = null;
                }
                else
                {
                    mover.MoveTo(target.position);
                }
            }
        }
        public void Attack(CombatTarget CombatTarget)
        {
            actionScheduler.StartAction(this);
            target = CombatTarget.transform;  
        }

        private void OnDrawGizmos()
        {
            if(target != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(target.transform.position, weaponRange);
            }
        }

        public void Cancel()
        {
            target = null;
        }
    }
}

