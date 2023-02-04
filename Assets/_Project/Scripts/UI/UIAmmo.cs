using System;
using MyBox;
using TMPro;
using UnityEngine;

namespace GlobalGameJam.UI
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class UIAmmo : MonoBehaviour
	{
		[MustBeAssigned]
		[SerializeField]
		private PlayerControls _playerControls;

		private TextMeshProUGUI _text;

		private void Awake()
		{
			_text = GetComponent<TextMeshProUGUI>();
		}

		private void Update()
		{
			_text.text = _playerControls.Ammo.ToString();
		}
	}
}