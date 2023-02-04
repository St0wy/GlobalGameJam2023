using System;
using UnityEngine;

namespace GlobalGameJam
{
	[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(PlayerControls))]
	public class PlayerAnimations : MonoBehaviour
	{
		private Animator _animator;
		private PlayerControls _playerControls;
		private Health _health;
		private static readonly int Speed = Animator.StringToHash("Speed");
		private static readonly int Hurt = Animator.StringToHash("Hurt");

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			_playerControls = GetComponent<PlayerControls>();
			_health = GetComponent<Health>();
		}

		private void OnEnable()
		{
			_health.OnHurt += OnHurt;
		}

		private void OnDisable()
		{
			_health.OnHurt -= OnHurt;
		}

		private void OnHurt(Transform _)
		{
			_animator.SetTrigger(Hurt);
		}

		private void Update()
		{
			_animator.SetFloat(Speed, _playerControls.Movement.sqrMagnitude);
		}
	}
}