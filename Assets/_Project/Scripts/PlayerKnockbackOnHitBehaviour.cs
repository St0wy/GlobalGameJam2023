using System;
using UnityEngine;

namespace GlobalGameJam
{
	[RequireComponent(typeof(Rigidbody2D), typeof(Health))]
	public class PlayerKnockbackOnHitBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float _knockbackForce = 10f;

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
				if (!attackerTransform) return;
				float direction = transform.position.x - attackerTransform.position.x;
				direction = direction <= 0f ? -1f : 1f;

				TriggerKnockback(direction);
			};
		}

		public void TriggerKnockback(float direction)
		{
			_rigidbody.AddForce(new Vector2(direction * _knockbackForce, 0), ForceMode2D.Impulse);
		}
	}
}