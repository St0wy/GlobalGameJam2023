using MyBox;
using UnityEngine;

namespace GlobalGameJam
{
	[RequireComponent(typeof(AudioPlayer), typeof(Health))]
	public class PlaySoundOnHurtBehaviour : MonoBehaviour
	{
		[SerializeField] private AudioPlayer _audioPlayer;
		[MustBeAssigned] [SerializeField] private ScreenShake _cam;
		private Health _health;

		public ScreenShake Cam
		{
			get => _cam;
			set => _cam = value;
		}

		private void Awake()
		{
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
			Cam.TriggerShortShake();
		}
		
	}
}