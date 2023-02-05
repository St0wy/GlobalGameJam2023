using System;
using MyBox;
using UnityEngine;

namespace GlobalGameJam
{
	public class Health : MonoBehaviour
	{
		public delegate void HurtEvent(Transform attackerTransform);

		public delegate void HealEvent();

		public delegate void DeathEvent();

		[SerializeField]
		private int _maxHealthPoints = 10;

		[SerializeField]
		[ReadOnly]
		private int _healthPoints;
		[SerializeField] private bool _destroyWhenKilled = true;

		private Rigidbody2D _rb;

		public HurtEvent OnHurt { get; set; }
		public HealEvent OnHeal { get; set; }
		public DeathEvent OnDeath { get; set; }
		public bool CanReceiveDamage { get; set; } = true;
		public bool IsDead => _healthPoints <= 0;
		public int HealthPoints => _healthPoints;

		private void Awake()
		{
			_rb = GetComponent<Rigidbody2D>();
			_healthPoints = _maxHealthPoints;
		}

		public void HealPlayer(int heal)
		{
			_healthPoints += heal;
			if (_healthPoints > _maxHealthPoints)
			{
				_healthPoints = _maxHealthPoints;
			}

			OnHeal?.Invoke();
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
					_rb.ToggleConstraints(RigidbodyConstraints2D.FreezePositionX, true);
					_rb.ToggleConstraints(RigidbodyConstraints2D.FreezePositionY, true);
					Destroy(gameObject, 0.2f);
				}
			}
		}
	}
}