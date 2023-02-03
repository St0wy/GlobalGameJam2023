using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] float _spawnRate;
    [SerializeField] Vector2 _spawnPos;
    private float _x, _y;
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(_enemies[0], _spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(_spawnRate);
        StartCoroutine(SpawnEnemy());
    }
}
