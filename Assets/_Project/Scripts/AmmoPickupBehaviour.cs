using MyBox;
using UnityEngine;

namespace GlobalGameJam
{
	public class AmmoPickupBehaviour : MonoBehaviour
	{
		[SerializeField]
		private float _pickupDuration = 1f;

		[ReadOnly]
		[SerializeField]
		private float _pickupTimer;
		[SerializeField]
		private AudioPlayer _audioPlayer;
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
			if (!_isPickuping) return;
			if (!_playerControls.IsDigging)
			{
				_isPickuping = false;
			}

			_pickupTimer -= Time.deltaTime;

			if (!(_pickupTimer <= 0f)) return;
			Destroy(_pickupItem);
			_playerControls.AddAmmo(1);
			_audioPlayer.Play();
			_isPickuping = false;
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (!col.CompareTag("Ammo")) return;
			if (!_playerControls.IsDigging) return;
			print("Prout");
			_pickupItem = col.gameObject;
			_isPickuping = true;
			_pickupTimer = _pickupDuration;
		}

		private void OnTriggerExit2D(Collider2D col)
		{
			if (!col.CompareTag("Ammo")) return;
			print("Anti-prout");
			_pickupItem = null;
			_isPickuping = false;
			_pickupTimer = _pickupDuration;
		}
	}
}