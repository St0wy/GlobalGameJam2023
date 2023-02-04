using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class HealthFromCorbax : MonoBehaviour
    {
        [SerializeField] private int healAmount = 2;

        private void OnCollisionEnter2D(Collision2D collision)
        {
			
            if (collision.gameObject.CompareTag("Player"))
            {
                Health _health = collision.gameObject.GetComponent<Health>();
                if (_health)
                {
                    _health.HealPlayer(healAmount);
                    Destroy(gameObject);
                }
				
            }
			
        }
    }
}
