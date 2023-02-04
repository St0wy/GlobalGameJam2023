using System;
using System.Collections;
using System.Collections.Generic;
using MyBox;
using UnityEngine;

namespace GlobalGameJam
{
	public class AmmoBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float _ammoSpeed = 5.0f;
		
		[SerializeField]
		private float _destroyTime = 3f;

		private Rigidbody2D _rigidbody;
		private float _destroyTimer;

		public Transform UpperLimit { get; set; }

		public bool ShouldDestroy { get; set; }

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_destroyTimer = _destroyTime;
		}

		private void Update()
		{
			if (ShouldDestroy)
			{
				_destroyTimer -= Time.deltaTime;
			}

			if (_destroyTimer <= 0f)
			{
				Destroy(gameObject);
			}
		}

		private void FixedUpdate()
		{
			if (UpperLimit && transform.position.y >= UpperLimit.position.y)
			{
				_rigidbody.velocity = Vector2.zero;
			}
			else
			{
				_rigidbody.velocity = transform.up * _ammoSpeed;
			}
		}
	}
}