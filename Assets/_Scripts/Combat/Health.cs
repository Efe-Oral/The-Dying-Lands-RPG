using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 40f;

        public void TakeDamage(float damage)
        {
            health = health - damage;
            if (health < 0) // health = Mathf.Max(health - damage, 0) Take the max between these valuse, so that it can not be minus.
            {
                health = 0;
            }
            Debug.Log(health);
        }
    }
}
