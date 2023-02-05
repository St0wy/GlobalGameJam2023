using System.Collections;
using System.Collections.Generic;
using MyBox;
using UnityEngine;

namespace GlobalGameJam
{
	public class EnemySpawner : MonoBehaviour
	{
		// Start is called before the first frame update
		[SerializeField] private List<GameObject> _enemies;
		[SerializeField] private Vector2 _spawnPos;
		[SerializeField] private Transform _target;
		[SerializeField] private Score _score;
		[SerializeField] private float _minSpawnRate = 0.2f;
		[SerializeField] private float _maxSpawnRate = 2f;

		[MustBeAssigned] [SerializeField] private Transform _downLimit;

		private float _spawnRate;
		private float _minSpawnPos;
		private float _maxSpawnPos;

		private void Start()
		{
			StartCoroutine(SpawnEnemy());
			_minSpawnPos = _spawnPos.x - 11;
			_maxSpawnPos = _spawnPos.x + 11;
		}

		// ReSharper disable Unity.PerformanceAnalysis
		private IEnumerator SpawnEnemy()
		{
			_spawnPos = gameObject.transform.position;
			_spawnPos.x = Random.Range(_minSpawnPos, _maxSpawnPos);
			_spawnRate = Random.Range(_minSpawnRate, _maxSpawnRate);
			GameObject enemy = Instantiate(_enemies[0], _spawnPos, Quaternion.identity);
			enemy.GetComponent<EnemyMovement>().PlayerTransform = _target;
			enemy.GetComponent<CorbaxDrop>().DownLimit = _downLimit;
			enemy.GetComponent<ScoreOnDeathBehaviour>().Score = _score;

			yield return new WaitForSeconds(_spawnRate);
			StartCoroutine(SpawnEnemy());
		}
	}
}