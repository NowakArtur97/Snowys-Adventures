using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _moveSound;
    [SerializeField] private AudioClip _landSound;
    [SerializeField] private float _soundMinPitch = 0.8f;
    [SerializeField] private float _soundMaxPitch = 0.8f;

    private AudioSource _myAudioSource;

    private void Awake() => _myAudioSource = GetComponent<AudioSource>();

    public void PlayMoveSound() => PlaySound(_landSound, true);

    public void PlayLandSound() => PlaySound(_landSound, false);

    public void StopPlayingSounds() => _myAudioSource.Stop();

    private void PlaySound(AudioClip sound, bool shouldLoop)
    {
        if (!_myAudioSource.isPlaying)
        {
            _myAudioSource.clip = sound;
            _myAudioSource.loop = shouldLoop;
            _myAudioSource.pitch = Random.Range(_soundMinPitch, _soundMaxPitch);
            _myAudioSource.Play();
        }
    }
}
