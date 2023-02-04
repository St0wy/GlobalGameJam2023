﻿using System;
using TMPro;
using UnityEngine;

namespace GlobalGameJam.UI
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class UIHealth : MonoBehaviour
	{
		[SerializeField]
		private Health _healthToShow;

		private TextMeshProUGUI _healthText;

		private void Awake()
		{
			_healthText = GetComponent<TextMeshProUGUI>();
		}

		private void OnEnable()
		{
			_healthToShow.OnHurt += OnHurt;
		}

		private void OnDisable()
		{
			_healthToShow.OnHurt -= OnHurt;
		}

		private void OnHurt(Transform _)
		{
			UpdateText();
		}

		private void Start()
		{
			UpdateText();
		}

		private void UpdateText()
		{
			if (!_healthToShow) return;
			_healthText.text = _healthToShow.HealthPoints.ToString();
		}
	}
}