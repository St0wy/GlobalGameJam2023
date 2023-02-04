using UnityEngine;

namespace GlobalGameJam
{
	public class Score : MonoBehaviour
	{
		private int _playerScore;
		public int PlayerScore => _playerScore;

		private void Start()
		{
			_playerScore = 0;
		}

		public void IncrementScore(int value)
		{
			_playerScore += value;
			print(_playerScore);
		}
	}
}