using MyBox;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam
{
	[RequireComponent(typeof(AudioPlayer))]
	public class PickupBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float _pickupDuration = 1f;

		[SerializeField]
		private int _pickupAmount = 4;
		[SerializeField]
		private int _healAmount = 1;

		[ReadOnly]
		[SerializeField]
		private float _pickupTimer;

		[SerializeField]
		private AudioPlayer _audioPlayer;

		[SerializeField]
		private Slider _slider;

		private PlayerControls _playerControls;
		private bool _isPickuping;
		private GameObject _pickupItem;
		private bool _isPickupingCadavre = false;
		private Health _playerHealth;

		private void Awake()
		{
			_playerControls = GetComponentInParent<PlayerControls>();
			_playerHealth = GetComponentInParent<Health>();
			_pickupTimer = _pickupDuration;
		}

		private void Update()
		{
			_slider.gameObject.SetActive(_isPickuping);
			if (!_isPickuping) return;
			if (!_playerControls.IsDigging)
			{
				_isPickuping = false;
				return;
			}

			_slider.value = _pickupTimer / _pickupDuration;

			_pickupTimer -= Time.deltaTime;

			if (!(_pickupTimer <= 0f)) return;

			if (_isPickupingCadavre)
			{
				_playerHealth.HealPlayer(_healAmount);
				_isPickuping = false;
				_isPickupingCadavre = false;
			}
			else
			{
				_playerControls.AddAmmo(_pickupAmount);
				_isPickuping = false;
			}

			Destroy(_pickupItem);
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (!_playerControls.IsDigging) return;
			bool isCadavre = col.CompareTag("Cadavre");
			if (!col.CompareTag("Ammo") && !isCadavre) return;

			if (col.TryGetComponent(out AmmoBehaviour ammoBehaviour))
			{
				ammoBehaviour.ShouldDestroy = false;
			}
			else if (col.TryGetComponent(out CadavreBehaviour cadavreBehaviour))
			{
				cadavreBehaviour.ShouldDestroy = false;
			}

			_pickupItem = col.gameObject;
			_isPickuping = true;
			_pickupTimer = _pickupDuration;

			if (isCadavre)
			{
				_isPickupingCadavre = true;
			}
		}

		private void OnTriggerExit2D(Collider2D col)
		{
			if (!col.CompareTag("Ammo") && !col.CompareTag("Cadavre")) return;

			if (col.TryGetComponent(out AmmoBehaviour ammoBehaviour))
			{
				ammoBehaviour.ShouldDestroy = true;
			}

			else if (col.TryGetComponent(out CadavreBehaviour cadavreBehaviour))
			{
				cadavreBehaviour.ShouldDestroy = true;
			}

			_audioPlayer.Play();
			_pickupItem = null;
			_isPickuping = false;
			_pickupTimer = _pickupDuration;
			_isPickupingCadavre = false;
		}
	}
}