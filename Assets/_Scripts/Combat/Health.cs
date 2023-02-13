using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        private bool isDead = false;
        [SerializeField] float health = 40f;

        public void TakeDamage(float damage)
        {
            health = health - damage;
            if (health <= 0) // health = Mathf.Max(health - damage, 0) Take the max between these valuse, so that it can not be minus.
            {
                if(isDead) return;
                isDead = true;
                health = 0;
                Die();
            }
            Debug.Log(health);
        }

        public void Die()
        {
            if(isDead)
            {
                GetComponent<Animator>().SetTrigger("die");
            }
        }
    }
}
