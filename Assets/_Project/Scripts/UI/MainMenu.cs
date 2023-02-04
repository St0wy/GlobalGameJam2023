using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GlobalGameJam
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _optionsMenu;

        private void Start()
        {
            _optionsMenu.SetActive(false);
        }

        public void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
