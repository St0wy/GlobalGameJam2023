using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AmmoSpawning : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 3.0f;
    [SerializeField] private GameObject _ammo;
    [SerializeField] private float _maxLength = 11.0f;
    [SerializeField] private float _minLength = -11.0f;
    private Vector2 _spawnPos;
    private float _timer = 0.0f;
    void Update()
    {
        _spawnPos = gameObject.transform.position;
        var rot = gameObject.transform.rotation;
        _spawnPos.x = Random.Range(_minLength, _maxLength);
        _timer += Time.deltaTime;
        if (_timer >= _spawnRate)
        {
            Instantiate(_ammo, _spawnPos, rot);
            _timer = 0;
        }
    }
}
