using System.Collections;
using System.Collections.Generic;
using MyBox;
using UnityEngine;

namespace GlobalGameJam
{
	[RequireComponent(typeof(Health))]
	public class CorbaxDrop : MonoBehaviour
	{
		[SerializeField] private GameObject _itemToDrop;
		[SerializeField] private float _dropChance;

		private Health _health;

		public Transform DownLimit { get; set; }

		private void Awake()
		{
			_health = GetComponent<Health>();
		}

		private void OnEnable()
		{
			_health.OnDeath += DropCadavre;
		}

		private void OnDisable()
		{
			_health.OnDeath -= DropCadavre;
		}

		private void DropCadavre()
		{
			if (Random.Range(0f, 100f) <= _dropChance)
			{
				// Spawn corbaxCadavre
				GameObject go = Instantiate(_itemToDrop, transform.position, Quaternion.identity);
				if (go.TryGetComponent(out CadavreBehaviour cadavreBehaviour))
				{
					cadavreBehaviour.DownLimit = DownLimit;
				}
			}

			Destroy(gameObject);
		}
	}
}