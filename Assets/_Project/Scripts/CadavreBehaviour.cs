using UnityEngine;

namespace GlobalGameJam
{
	public class CadavreBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float _fallSpeed = 1f;

		[SerializeField]
		private float _destroyTime = 3f;

		private Rigidbody2D _rigidbody;
		private float _destroyTimer;

		public Transform DownLimit { get; set; }

		public bool ShouldDestroy { get; set; } = true;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
			_destroyTimer = _destroyTime;
		}

		private void Update()
		{
			if (ShouldDestroy)
			{
				_destroyTimer -= Time.deltaTime;
			}

			if (_destroyTimer <= 0f)
			{
				Destroy(gameObject);
			}
		}

		private void FixedUpdate()
		{
			if (DownLimit && transform.position.y <= DownLimit.position.y)
			{
				_rigidbody.velocity = Vector2.zero;
			}
			else
			{
				_rigidbody.velocity = -transform.up * _fallSpeed;
			}
		}
	}
}