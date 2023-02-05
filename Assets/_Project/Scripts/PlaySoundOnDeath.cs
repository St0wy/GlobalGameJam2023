using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    [RequireComponent(typeof(AudioPlayer), typeof(Health))]
    public class PlaySoundOnDeath : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private AudioPlayer _audioPlayer;
        private Health _health;
        
        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.OnDeath += OnDeath;
        }

        private void OnDisable()
        {
            _health.OnDeath -= OnDeath;
        }
        

        private void OnDeath()
        {
            _audioPlayer.Play();
        }

    }
}
