using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> _enemies = new List<GameObject>();
    [SerializeField] float _spawnRate;
    [SerializeField] Vector2 _spawnPos ;
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
       
    }

    IEnumerator SpawnEnemy()
    {
        _spawnPos = gameObject.transform.position;
        _spawnRate = Random.Range(0.2f, 2.4f);
        Instantiate(_enemies[0], _spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(_spawnRate);
        StartCoroutine(SpawnEnemy());
    }
}
