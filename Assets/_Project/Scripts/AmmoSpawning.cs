using UnityEngine;

namespace GlobalGameJam
{
	public class AmmoSpawning : MonoBehaviour
	{
		[SerializeField] private float _spawnRate = 3.0f;
		[SerializeField] private GameObject _ammo;
		[SerializeField] private float _maxLength = 11.0f;
		[SerializeField] private float _minLength = -11.0f;
		[SerializeField] private Transform _upperLimit;
		private Vector2 _spawnPos;
		private float _timer;

		private void Update()
		{
			_timer += Time.deltaTime;

			if (_timer >= _spawnRate)
			{
				SpawnAmmo();
			}
		}

		private void SpawnAmmo()
		{
			GameObject o = gameObject;
			Quaternion rot = o.transform.rotation;
			_spawnPos = o.transform.position;
			_spawnPos.x = Random.Range(_minLength, _maxLength);
			GameObject ammo = Instantiate(_ammo, _spawnPos, rot);
			if (ammo.TryGetComponent(out AmmoBehaviour ammoBehaviour))
			{
				ammoBehaviour.UpperLimit = _upperLimit;
			}

			_timer = 0;
		}
	}
}