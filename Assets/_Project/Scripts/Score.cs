using UnityEngine;

namespace GlobalGameJam
{
	public class Score : MonoBehaviour
	{
		public int PlayerScore { get; private set; }
		[SerializeField] private int _startingScore = 0;
		private void Start()
		{
			PlayerScore = _startingScore;
		}

		public void IncrementScore(int value)
		{
			PlayerScore += value;
		}
	}
}