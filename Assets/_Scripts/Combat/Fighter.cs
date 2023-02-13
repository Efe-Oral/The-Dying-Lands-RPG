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
        [SerializeField] float weaponRange = 5f;
        [SerializeField] float timeBetweenAttacks = 0.5f;
        [SerializeField] float weaponDamage = 10f;

        ActionScheduler actionScheduler;
        Transform target;
        Mover mover;
        Health health;

        float timeSinceLastAttack = 0f;
        

        private void Start() 
        {
            mover = GetComponent<Mover>();
            health = GetComponent<Health>();
        }

        private void Update() 
        {
            timeSinceLastAttack += Time.deltaTime;

            if(target == null) return;

            if(target != null)
            {
                float distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
                if(distance <= weaponRange)
                {
                    mover.Cancel();
                    AttackBehaviour();
                }
                else
                {
                    mover.MoveTo(target.position);
                }
            }
        }

        private void AttackBehaviour()
        {
            if(timeSinceLastAttack > timeBetweenAttacks)
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0f;
                //This will trigger the Hit() method below line 63
            }
        }

        //Animation Event
        void Hit()
        {
            if(target == null) return; //If there are no target, return
            target.GetComponent<Health>().TakeDamage(weaponDamage); //The component on the enemy
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
    }
}

