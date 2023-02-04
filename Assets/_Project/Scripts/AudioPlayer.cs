using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class AudioPlayer : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private List<AudioClip> _audioClips;
        private AudioSource _audioSource;
        void Start()
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
