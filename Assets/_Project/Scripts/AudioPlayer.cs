using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GlobalGameJam
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private List<AudioClip> _audioClips;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Play()
        {
            int r = Random.Range(0, _audioClips.Count);
            AudioClip clip = _audioClips[r];
            _audioSource.clip = clip;
            _audioSource.Play();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
