using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam
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
            print("caca");
        }
    }
}
