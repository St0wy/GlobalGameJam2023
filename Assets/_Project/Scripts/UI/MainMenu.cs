using MyBox;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GlobalGameJam.UI
{
	public class MainMenu : MonoBehaviour
	{
		[SerializeField] private SceneReference _gameScene;

		public void PlayGame()
		{
			_gameScene.LoadScene();
		}

		public void QuitGame()
		{
			Application.Quit();
		}

		public void ToggleMainMenu()
		{
			gameObject.SetActive(true);
		}
	}
}