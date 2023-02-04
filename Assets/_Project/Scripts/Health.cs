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


		private bool IsAlive;
		public HurtEvent OnHurt { get; set; }
		public DeathEvent OnDeath { get; set; }
		public bool CanReceiveDamage { get; set; } = true;
		//public bool IsDead => _healthPoints <= 0;

		private void Awake()
		{
			_healthPoints = _maxHealthPoints;
			IsAlive = true;
		}

		public void Hurt(int hurtAmount, Transform attackerTransform = null)
		{
			if (!CanReceiveDamage) return;

			_healthPoints -= hurtAmount;
			OnHurt?.Invoke(attackerTransform);
			
			if (_healthPoints <= 0)
			{
				IsAlive = false;
				OnDeath?.Invoke();
			}

			if (!IsAlive && _destroyWhenKilled)
			{
				Destroy(gameObject);
			}

			//if (IsDead) OnDeath?.Invoke();
		}
	}
}