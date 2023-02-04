using System.Collections;
using System.Collections.Generic;
using GlobalGameJam;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] Vector2 _spawnPos;
    [SerializeField] private Transform _target;

    private float _spawnRate;
    private float _minspawnPos;
    private float _maxspawnPos;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        _minspawnPos = _spawnPos.x - 11;
        _maxspawnPos = _spawnPos.x + 11;
    }

    IEnumerator SpawnEnemy()
    {
        _spawnPos = gameObject.transform.position;
        _spawnPos.x = Random.Range(_minspawnPos, _maxspawnPos);
        _spawnRate = Random.Range(0.2f, 2.0f);
        GameObject enemy = Instantiate(_enemies[0], _spawnPos, Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().PlayerTransform = _target;
        yield return new WaitForSeconds(_spawnRate);
        StartCoroutine(SpawnEnemy());
    }
}