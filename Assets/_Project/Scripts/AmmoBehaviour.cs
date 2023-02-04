using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class AmmoBehaviour : MonoBehaviour
    {
        [SerializeField] private float _ammoSpeed = 5.0f;
        private Rigidbody2D _rb;
        private float _destroyTime = 3f;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            Destroy(gameObject, _destroyTime);
        }

        void FixedUpdate()
        {
            _rb.velocity = transform.up * (_ammoSpeed * Time.fixedDeltaTime);
        }
        
        
    }
}
