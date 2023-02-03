using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GlobalGameJam
{
    public class EnemyMovement : MonoBehaviour
    {
        // Start is called before the first frame update
        
        [SerializeField] private float speed = 2.0f;
        //[FormerlySerializedAs("playerTrans")]
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Vector2 _velocity;
        private Rigidbody2D _rb;
        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 corbaxToTarget = playerTransform.position - transform.position;
            MoveToTarget(corbaxToTarget);
			
            _velocity = Vector2.zero;
        }

        private void MoveToTarget(Vector2 dir)
        {
            _velocity = dir.normalized * speed;
            _rb.velocity = _velocity;
        }
    }
}
