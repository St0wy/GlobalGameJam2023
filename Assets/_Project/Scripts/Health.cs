using MyBox;
using UnityEngine;

namespace GlobalGameJam
{
	public class Health : MonoBehaviour
	{
		public delegate void HurtEvent(Transform attackerTransform);

		public delegate void DeathEvent();

		[SerializeField]
		private int _maxHealthPoints = 10;

		[SerializeField]
		[ReadOnly]
		private int _healthPoints;
		[SerializeField] private bool _destroyWhenKilled = true;

		public HurtEvent OnHurt { get; set; }
		public DeathEvent OnDeath { get; set; }
		public bool CanReceiveDamage { get; set; } = true;
		public bool IsDead => _healthPoints <= 0;
		public int HealthPoints => _healthPoints;

		private void Awake()
		{
			_healthPoints = _maxHealthPoints;
		}

		public void Hurt(int hurtAmount, Transform attackerTransform = null)
		{
			if (!CanReceiveDamage) return;

			_healthPoints -= hurtAmount;
			OnHurt?.Invoke(attackerTransform);

			if (IsDead)
			{
				OnDeath?.Invoke();
				if (_destroyWhenKilled)
				{
					Destroy(gameObject);
				}
			}
		}
	}
}