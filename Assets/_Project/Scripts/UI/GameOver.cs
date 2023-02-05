using MyBox;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam.UI
{
	public class GameOver : MonoBehaviour
	{
		[MustBeAssigned]
		[SerializeField]
		private Health _playerHealth;

		[MustBeAssigned]
		[SerializeField]
		private GameObject _gameOverUI;

		[MustBeAssigned]
		[SerializeField]
		private Button _mainMenuButton;

		[SerializeField]
		private SceneReference _mainMenuScene;

		[SerializeField] private AudioSource _sounds;

		private void OnEnable()
		{
			_playerHealth.OnDeath += OnDeath;
		}

		private void OnDisable()
		{
			_playerHealth.OnDeath -= OnDeath;
		}

		private void OnDeath()
		{
			_sounds.mute = true;
			_gameOverUI.SetActive(true);
			_mainMenuButton.Select();
			Time.timeScale = 0f;
		}

		public void GoToMainMenu()
		{
			Time.timeScale = 1f;
			_mainMenuScene.LoadScene();
		}
	}
}