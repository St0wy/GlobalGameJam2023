using TMPro;
using UnityEngine;

namespace GlobalGameJam.UI
{
	public class UIScore : MonoBehaviour
	{
		[SerializeField] private Score _playerScore;
		private TextMeshProUGUI _text;

		private void Start()
		{
			_text = GetComponent<TextMeshProUGUI>();
		}

		void Update()
		{
			_text.text = $"Score: {_playerScore.PlayerScore}";
		}
	}
}