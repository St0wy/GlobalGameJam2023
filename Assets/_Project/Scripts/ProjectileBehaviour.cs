using System;
using UnityEngine;

namespace GlobalGameJam
{
	public class ProjectileBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float _movementSpeed = 1.0f;
		[SerializeField]
		private AudioPlayer _audioPlayer;
		// private Vector2 _movementDirection;
		private float _destroyTime = 3f;
		private Rigidbody2D _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			Destroy(gameObject, _destroyTime);
			_audioPlayer.Play();
		}

		public void Shoot(Vector2 direction)
		{
			// _movementDirection = direction;
			_rigidbody.velocity = direction * _movementSpeed;
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.CompareTag("Player")) return;
			Destroy(gameObject);
		}
	}
}