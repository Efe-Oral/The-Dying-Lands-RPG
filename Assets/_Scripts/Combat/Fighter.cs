using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
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
                    mover.Cancel();
                    target = null;
                    GetComponent<Animator>().SetTrigger("attack");
                }
                else
                {
                    mover.MoveTo(target.position);
                }
            }
        }
        public void Attack(CombatTarget CombatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
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

        //Animation Event
        void Hit()
        {

        }
    }
}

