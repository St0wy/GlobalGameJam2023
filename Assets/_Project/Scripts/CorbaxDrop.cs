using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    [RequireComponent(typeof(Health))]
    public class CorbaxDrop : MonoBehaviour
    {

        [SerializeField] private GameObject _itemToDrop;
        [SerializeField] private float _dropChance;

        private Health _health;
        private void Awake() 
        {
            _health = GetComponent<Health>(); 
        }

        private void OnEnable()
        {
            _health.OnDeath += DropPotion;
        }

        private void OnDisable()
        {
            _health.OnDeath -= DropPotion;
        }

        private void DropPotion()
        {
            if (Random.Range(0f, 100f) <= _dropChance)
            {
                // Spawn corbaxCadavre
                Instantiate(_itemToDrop, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }

        
    }
}
