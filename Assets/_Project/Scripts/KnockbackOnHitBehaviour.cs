using System;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace GlobalGameJam
{
	[RequireComponent(typeof(Rigidbody2D), typeof(Health))]
	public class KnockbackOnHitBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float _knockbackForce = 1f;

		private Rigidbody2D _rigidbody;
		private Health _health;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_health = GetComponent<Health>();
		}

		private void OnEnable()
		{
			_health.OnHurt += attackerTransform =>
			{
				float direction = transform.position.x - attackerTransform.position.x;
				direction = direction <= 0f ? -1f : 1f;

				TriggerKnockback(direction);
			};
		}

		public void TriggerKnockback(float direction)
		{
			
		}
	}
}