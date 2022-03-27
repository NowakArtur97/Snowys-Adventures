using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour
{
    [SerializeField] private AudioClip _moveSound;
    [SerializeField] private AudioClip _landSound;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _scaredSound;
    [SerializeField] private float _soundMinPitch = 0.8f;
    [SerializeField] private float _soundMaxPitch = 0.8f;

    private AudioSource _myAudioSource;

    private void Awake() => _myAudioSource = GetComponent<AudioSource>();

    public void PlayMoveSound() => PlaySoundWhenIsFinished(_moveSound, true);

    public void PlayLandSound() => PlaySound(_landSound);

    public void PlayJumpSound() => PlaySound(_jumpSound);

    public void PlayScaredSound() => PlaySound(_scaredSound);

    public void StopPlayingSounds() => _myAudioSource.Stop();

    private void PlaySoundWhenIsFinished(AudioClip sound, bool shouldLoop)
    {
        if (!_myAudioSource.isPlaying)
        {
            PlaySound(sound, shouldLoop);
        }
    }

    private void PlaySound(AudioClip sound, bool shouldLoop = false)
    {
        _myAudioSource.clip = sound;
        _myAudioSource.loop = shouldLoop;
        _myAudioSource.pitch = Random.Range(_soundMinPitch, _soundMaxPitch);
        _myAudioSource.Play();
    }
}
