using UnityEngine;

namespace GlobalGameJam
{
	public class ProjectileBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float _movementSpeed = 1.0f;
		[SerializeField]
		private float _destroyTime = 3f;

		private Rigidbody2D _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			Destroy(gameObject, _destroyTime);
		}

		private void Update()
		{
			Vector2 vel = _rigidbody.velocity;
			float radValue = Mathf.Atan2(vel.y, vel.x);
			float angle = radValue * (180 / Mathf.PI);
			transform.rotation = Quaternion.Euler(0, 0, angle + -90);
		}

		public void Shoot(Vector2 direction)
		{
			_rigidbody.velocity = direction * _movementSpeed;
		}

		private void OnCollisionEnter2D()
		{
			Destroy(gameObject);
		}
	}
}