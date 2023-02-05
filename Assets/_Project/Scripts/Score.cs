using UnityEngine;

namespace GlobalGameJam
{
	public class Score : MonoBehaviour
	{
		public int PlayerScore { get; private set; }

		private void Start()
		{
			PlayerScore = 0;
		}

		public void IncrementScore(int value)
		{
			PlayerScore += value;
		}
	}
}