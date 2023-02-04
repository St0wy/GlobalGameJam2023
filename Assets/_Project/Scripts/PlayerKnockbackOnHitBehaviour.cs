using System;
using UnityEngine;

namespace GlobalGameJam
{
	[RequireComponent(typeof(Rigidbody2D), typeof(Health), typeof(PlayerControls))]
	public class PlayerKnockbackOnHitBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float _knockbackForce = 10f;

		private Rigidbody2D _rigidbody;
		private Health _health;
		private PlayerControls _playerControls;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_health = GetComponent<Health>();
			_playerControls = GetComponent<PlayerControls>();
		}

		private void OnEnable()
		{
			_health.OnHurt += OnHurt;
		}

		private void OnDisable()
		{
			_health.OnHurt -= OnHurt;
		}

		private void OnHurt(Transform attackerTransform)
		{
			if (!attackerTransform) return;
			float direction = transform.position.x - attackerTransform.position.x;
			direction = direction <= 0f ? -1f : 1f;

			TriggerKnockback(direction);
		}

		public void TriggerKnockback(float direction)
		{
			_playerControls.KnockbackVelocityX = direction * _knockbackForce;
		}
	}
}