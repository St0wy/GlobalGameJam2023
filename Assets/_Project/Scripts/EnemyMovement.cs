using UnityEngine;

namespace GlobalGameJam
{
	public class EnemyMovement : MonoBehaviour
	{
		[SerializeField] private float speed = 2.0f;

		[field: SerializeField] public Transform PlayerTransform { get; set; }
		[SerializeField] private Vector2 _velocity;
		private Rigidbody2D _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void Update()
		{
			Vector2 corbaxToTarget = PlayerTransform.position - transform.position;
			MoveToTarget(corbaxToTarget);

			_velocity = Vector2.zero;
		}

		private void MoveToTarget(Vector2 dir)
		{
			_velocity = dir.normalized * speed;
			_rigidbody.velocity = _velocity;
		}
	}
}