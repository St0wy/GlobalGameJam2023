using System;
using UnityEngine;

namespace GlobalGameJam
{
	[RequireComponent(typeof(AudioPlayer), typeof(Health))]
	public class PlaySoundOnHurtBehaviour : MonoBehaviour
	{
		[SerializeField]
		private AudioPlayer _audioPlayer;
		private Health _health;

		private void Awake()
		{
			// _audioPlayer = GetComponent<AudioPlayer>();
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
			_audioPlayer.Play();
		}
	}
}