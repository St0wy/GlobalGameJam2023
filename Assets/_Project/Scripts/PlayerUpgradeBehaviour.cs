using System;
using UnityEngine;

namespace GlobalGameJam
{
	[RequireComponent(typeof(Animator), typeof(Score))]
	public class PlayerUpgradeBehaviour : MonoBehaviour
	{
		public enum UpgradeState
		{
			Flower = 0,
			Teenager = 1,
			Adult = 2,
		}
		
		[SerializeField] private AudioPlayer _audioPlayer;
		
		[SerializeField]
		private int _scoreUpgradeOne = 3000;

		[SerializeField]
		private int _scoreUpgradeTwo = 6000;

		private Score _score;
		private Animator _animator;
		private static readonly int PlayerUpgradeState = Animator.StringToHash("PlayerUpgradeState");

		public UpgradeState State { get; private set; }

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			_score = GetComponent<Score>();
		}

		private void Update()
		{
			if (_score.PlayerScore >= _scoreUpgradeOne && _score.PlayerScore < _scoreUpgradeTwo)
			{
				State = UpgradeState.Teenager;
				_audioPlayer.Play();
			}
			else if (_score.PlayerScore >= _scoreUpgradeTwo)
			{
				State = UpgradeState.Adult;
				_audioPlayer.Play();
			}

			_animator.SetInteger(PlayerUpgradeState, (int) State);
		}
	}
}