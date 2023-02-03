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

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        _spawnPos = gameObject.transform.position;
        _spawnPos.x = Random.Range(-4, 4);
        _spawnRate = Random.Range(0.2f, 2.0f);
        GameObject enemy = Instantiate(_enemies[0], _spawnPos, Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().PlayerTransform = _target;
        yield return new WaitForSeconds(_spawnRate);
        StartCoroutine(SpawnEnemy());
    }
}