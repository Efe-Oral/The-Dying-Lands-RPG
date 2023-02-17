using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        private bool isDead = false;
        [SerializeField] float healthPoints = 40f;

        public bool IsDead() //Getter - Setter
        {
            return isDead;
        }

        public void TakeDamage(float damage)
        {
            healthPoints = healthPoints - damage;

            if (healthPoints <= 0) // health = Mathf.Max(health - damage, 0) Take the max between these valuse, so that it can not be minus.
            {
                healthPoints = 0;
                Die();
            }
            Debug.Log(healthPoints);
        }

        public void Die()
        {
            if(isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
        }
    }
}
