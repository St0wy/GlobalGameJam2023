using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GlobalGameJam
{
	public class PlayerControls : MonoBehaviour
	{
		[SerializeField]
		private float _moveSpeed = 1f;

		private Vector2 _input;
		private Vector2 _shootDirection;
		private bool _canShoot = true;
		private bool _shouldShoot = false;
		private Camera _mainCam;


		public Vector2 Input
		{
			get => _input;
			set
			{
				_input = value;
				if (_input.sqrMagnitude > _input.normalized.sqrMagnitude)
					_input.Normalize();
			}
		}

		private void Awake()
		{
			_mainCam = Camera.main;
		}

		private void OnMove(InputValue value)
		{
			Input = value.Get<Vector2>();
		}

		private void OnLook(InputValue value)
		{
			Vector2 shootDirection = value.Get<Vector2>().normalized;
			if (_canShoot)
			{
				_shouldShoot = true;
				_canShoot = false;
				_shootDirection = shootDirection;
			}
			else
			{
				if (shootDirection == Vector2.zero)
				{
					_canShoot = true;
				}
			}
		}

		private void OnShoot()
		{
			Vector2 pos = _mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
			Vector2 playerToMouse = pos - (Vector2) transform.position;
			_shouldShoot = true;
			_shootDirection = playerToMouse.normalized;
		}

		private void FixedUpdate()
		{
			ApplyMovements();
		}

		private void Shoot(Vector2 direction)
		{
			if (direction.y <= 0f) return;
			
			_shouldShoot = false;
			print("Test");
			// TODO : Shot in the direction
		}

		private void ApplyMovements()
		{
			if (_shouldShoot)
				Shoot(_shootDirection);

			// TODO : Move the player
		}
	}
}