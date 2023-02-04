using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
	public class HealFromCorbax : MonoBehaviour
	{
		[SerializeField] private int healAmount = 2;

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (!collision.gameObject.CompareTag("Player")) return;
			if (!collision.gameObject.TryGetComponent(out Health health)) return;

			health.HealPlayer(healAmount);
			Destroy(gameObject);
		}
	}
}