using System;
using UnityEngine;

namespace GlobalGameJam
{
	[RequireComponent(typeof(AudioSource), typeof(Health))]
	public class PlaySoundOnHurtBehaviour : MonoBehaviour
	{
		private AudioSource _audioSource;
		private Health _health;

		private void Awake()
		{
			_audioSource = GetComponent<AudioSource>();
			_health = GetComponent<Health>();
		}

		private void OnEnable()
		{
			_health.OnHurt += OnHurt;
		}

		private void OnDisable()
		{
			_health.OnHurt -= OnHurt;
		}

		private void OnHurt(Transform _)
		{
			_audioSource.Play();
		}
	}
}