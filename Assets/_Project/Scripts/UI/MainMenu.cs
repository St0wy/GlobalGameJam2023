using MyBox;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GlobalGameJam.UI
{
	public class MainMenu : MonoBehaviour
	{
		[SerializeField] private GameObject _optionsMenu;
		[SerializeField] private SceneReference _gameScene;

		private void Start()
		{
			_optionsMenu.SetActive(false);
		}

		public void PlayGame()
		{
			_gameScene.LoadScene();
		}

		public void QuitGame()
		{
			Application.Quit();
		}

		public void ToggleOptions()
		{
			gameObject.SetActive(false);
			_optionsMenu.SetActive(true);
		}

		public void ToggleMainMenu()
		{
			_optionsMenu.SetActive(false);
			gameObject.SetActive(true);
		}
	}
}