using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class SpawnSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _spwn;
        [SerializeField] private Score _playerScore;
        [SerializeField] private PickupBehaviour _pick;
        [SerializeField] private int _scoreSpawnThreshold = 6000;

        void Update()
        {
            if (_playerScore.PlayerScore >= _scoreSpawnThreshold)
            {
                print("spawning spawn");
                Instantiate(_spwn);
                _pick._pickupDuration -= 0.15f;
                _scoreSpawnThreshold += 9000;
            }
        }
    }
}
