using System;
using MyBox;
using UnityEngine;

namespace GlobalGameJam
{
	public class DamageOnCollisionBehaviour : MonoBehaviour
	{
		[SerializeField]
		private int _damageAmount = 1;

		[SerializeField]
		[Tag]
		private string[] _tagsToHit;
		
		private void Start()
		{
		}

		private void OnCollisionEnter2D(Collision2D col)
		{
			ManageCollisions(col);
		}

		private void OnCollisionStay2D(Collision2D col)
		{
			ManageCollisions(col);
		}

		private void ManageCollisions(Collision2D col)
		{
			if (!col.collider.TryGetComponent(out Health health)) return;

			// ReSharper disable once LoopCanBeConvertedToQuery
			foreach (string collisionTag in _tagsToHit)
			{
				if (!col.collider.CompareTag(collisionTag)) continue;
				health.Hurt(_damageAmount, transform);
				return;
			}
		}
	}
}