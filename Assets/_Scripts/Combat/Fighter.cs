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

        float timeSinceLastAttack = 0f;

        ActionScheduler actionScheduler;
        Health target;
        Health health;
        Mover mover;
 
        private void Start() 
        {
            mover = GetComponent<Mover>();
            health = GetComponent<Health>();
        }

        private void Update() 
        {
            timeSinceLastAttack += Time.deltaTime;

            if(target == null) return;

            if (target.IsDead()) return; //If target is dead stop playing the attack animation
            
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
                    mover.MoveTo(target.transform.position);
                }
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target.transform.position);
            if(timeSinceLastAttack > timeBetweenAttacks)
            {
                TriggerAttack();
                timeSinceLastAttack = 0f;
                //This will trigger the Hit() method below line 70
            }
        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }

        //Animation Event
        void Hit()
        {
            if(target == null) return; //If there are no target, return
            target.TakeDamage(weaponDamage); //The component on the thing we hit
        }

        public bool CanAttack(CombatTarget combatTarget)
        {
            if (combatTarget == null) { return false; }
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
/*             if(target != null && target.IsDead() == false)
            {
                return true;
            }
            return false; */
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.GetComponent<Health>();  
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
            StopAttack();//Cancel attack animation by moving somewhere else while fighting
            target = null;
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("attack");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }
    }
}

