using UnityEngine;

namespace GlobalGameJam
{
	public class Health : MonoBehaviour
	{
		public delegate void HurtEvent();

		public delegate void DeathEvent();

		[SerializeField]
		private int _maxHealthPoints = 10;

		private int _healthPoints;

		public HurtEvent OnHurt { get; set; }
		public DeathEvent OnDeath { get; set; }
		public bool IsDead => _healthPoints <= 0;

		private void Awake()
		{
			_healthPoints = _maxHealthPoints;
		}

		public void Hurt(int hurtAmount)
		{
			_healthPoints -= hurtAmount;
			OnHurt?.Invoke();
			if (IsDead) OnDeath?.Invoke();
		}
	}
}