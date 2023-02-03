using System;
using UnityEngine;

namespace GlobalGameJam
{
	public class ProjectileBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float _movementSpeed = 1.0f;
		// private Vector2 _movementDirection;

		private Rigidbody2D _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		public void Shoot(Vector2 direction)
		{
			// _movementDirection = direction;
			_rigidbody.velocity = direction * _movementSpeed;
		}
	}
}