using System;
using UnityEngine;

namespace GlobalGameJam
{
	[RequireComponent(typeof(Animator), typeof(Health), typeof(Rigidbody2D))]
	public class CorbaxAnimations : MonoBehaviour
	{
		private Animator _animator;
		private Health _health;
		private Rigidbody2D _rigidbody;

		private static readonly int Hurt = Animator.StringToHash("Hurt");
		private static readonly int Dead = Animator.StringToHash("Dead");

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			_health = GetComponent<Health>();
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			Vector3 scale = transform.localScale;
			scale.x = -Mathf.Sign(_rigidbody.velocity.x) * Mathf.Abs(scale.x);
			transform.localScale = scale;
		}

		private void OnEnable()
		{
			_health.OnHurt += OnHurt;
			_health.OnDeath += OnDeath;
		}
		
		private void OnDisable()
		{
			_health.OnHurt -= OnHurt;
			_health.OnDeath -= OnDeath;
		}

		private void OnHurt(Transform _)
		{
			_animator.SetTrigger(Hurt);
		}
		
		private void OnDeath()
		{
			_animator.SetTrigger(Dead);
		}
	}
}