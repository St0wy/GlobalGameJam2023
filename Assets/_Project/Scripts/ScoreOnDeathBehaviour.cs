using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
	[RequireComponent(typeof(Health))]
	public class ScoreOnDeathBehaviour : MonoBehaviour
	{
		[SerializeField] private int _scoreAmount = 100;
		private Health _health;
		public Score Score { get; set; }

		private void Awake()
		{
			_health = GetComponent<Health>();
		}

		private void OnEnable()
		{
			_health.OnDeath += OnDeath;
		}

		private void OnDisable()
		{
			_health.OnDeath -= OnDeath;
		}

		private void OnDeath()
		{
			Score.IncrementScore(_scoreAmount);
		}
	}
}