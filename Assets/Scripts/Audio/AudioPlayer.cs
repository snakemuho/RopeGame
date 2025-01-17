using UnityEngine;

namespace RopeGame.Audio
{
    public class AudioPlayer : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayContinuousSound(AudioClip audioClip)
        {
            if (_audioSource.clip == audioClip) return;
            _audioSource.loop = true;
            _audioSource.clip = audioClip;
            _audioSource.Play();
        }
    
        public void StopContinuousSound()
        {
            _audioSource.Stop();
            _audioSource.clip = null;
            _audioSource.loop = false;
        }
    
        public void PlaySingleSound(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    }
}