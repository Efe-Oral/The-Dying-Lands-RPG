using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Movement;

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

