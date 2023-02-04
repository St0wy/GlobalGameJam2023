using MyBox;
using UnityEngine;
using UnityEngine.UI;

namespace GlobalGameJam
{
	[RequireComponent(typeof(AudioPlayer))]
	public class AmmoPickupBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float _pickupDuration = 1f;

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

		private void Awake()
		{
			_playerControls = GetComponentInParent<PlayerControls>();
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
			Destroy(_pickupItem);
			_playerControls.AddAmmo(1);
			_isPickuping = false;
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (!col.CompareTag("Ammo")) return;
			if (!_playerControls.IsDigging) return;

			_pickupItem = col.gameObject;
			_isPickuping = true;
			_pickupTimer = _pickupDuration;
		}

		private void OnTriggerExit2D(Collider2D col)
		{
			
			if (!col.CompareTag("Ammo")) return;
			_audioPlayer.Play();
			_pickupItem = null;
			_isPickuping = false;
			_pickupTimer = _pickupDuration;
		}
	}
}