
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GlobalGameJam
{
	public class PlayerControls : MonoBehaviour
	{
		[SerializeField]
		private float _moveSpeed = 1f;

		[SerializeField]
		private GameObject _projectilePrefab;

		[SerializeField]
		private float _timeToShotAgainInSeconds = 0.3f;

		private Rigidbody2D _rb;
		private Vector2 _moveDirection;
		private Vector2 _shootDirection;
		private Camera _mainCam;
		private float _shootTimer;
		private bool _mousePressed = false;

		public Vector2 Input
		{
			get => _moveDirection;
			set
			{
				_moveDirection = value;
				if (_moveDirection.sqrMagnitude > _moveDirection.normalized.sqrMagnitude)
					_moveDirection.Normalize();
			}
		}

		private bool CanShoot => _shootTimer <= 0f;

		private void Awake()
		{
			_mainCam = Camera.main;
			_rb = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			_shootTimer -= Time.deltaTime;
		}

		private void OnMove(InputValue value)
		{
			Input = value.Get<Vector2>();
		}

		private void OnShoot(InputValue value)
		{
			_mousePressed = value.Get<float>() > 0f;
			if (_mousePressed)
			{
				Vector2 playerToMouse = GetPlayerToMouseVec();
				_shootDirection = playerToMouse.normalized;
			}
			else
			{
				_shootDirection = Vector2.zero;
			}
		}

		private void OnLook(InputValue value)
		{
			_shootDirection = value.Get<Vector2>();
		}

		private void FixedUpdate()
		{
			ApplyMovements();
			HandleShoot();
		}

		private void HandleShoot()
		{
			if (!CanShoot || _shootDirection == Vector2.zero) return;

			Shoot(_mousePressed ? GetPlayerToMouseVec().normalized : _shootDirection);
		}

		private void Shoot(Vector2 direction)
		{
			if (!_mousePressed)
				_shootDirection = Vector2.zero;

			_shootTimer = _timeToShotAgainInSeconds;
			GameObject projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
			var behaviour = projectile.GetComponent<ProjectileBehaviour>();
			behaviour.Shoot(direction);
		}

		private void ApplyMovements()
		{
			// TODO : Move the player
			_rb.velocity = new Vector2(_moveDirection.x * (_moveSpeed * Time.fixedDeltaTime), 0);
		}

		private Vector2 GetPlayerToMouseVec()
		{
			Vector2 pos = _mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
			return pos - (Vector2) transform.position;
		}
	}
}