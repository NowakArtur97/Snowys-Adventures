using UnityEngine;
using UnityEngine.Audio;

public class SceneTransitionTriggers : MonoBehaviour
{
    private readonly string SOUNDS_VOLUME_VARIABLE = "soundsVolume";
    private readonly float MUTED_VOLUME = -80.0f;

    [SerializeField] private AudioMixer _audioMixer;

    private Input _input;
    private float _defaultSoundVolume;

    private void Start()
    {
        _input = FindObjectOfType<Input>();
        _audioMixer.GetFloat(SOUNDS_VOLUME_VARIABLE, out _defaultSoundVolume);
        _audioMixer.SetFloat(SOUNDS_VOLUME_VARIABLE, MUTED_VOLUME);
    }

    public void StartLevelTrigger()
    {
        _input.EnableMovemnt();

        _audioMixer.SetFloat(SOUNDS_VOLUME_VARIABLE, _defaultSoundVolume);
    }

    public void EndLevelTrigger() => LevelManager.LoadNextScene();
}
