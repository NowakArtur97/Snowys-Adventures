using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSong : MonoBehaviour
{
    [SerializeField] private int _sceneIndexToEndSong = 11;

    private AudioSource _audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _audioSource = GetComponent<AudioSource>();

        PlayMusic();
    }

    private void PlayMusic()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == _sceneIndexToEndSong)
        {
            Destroy(gameObject);
        }
    }
}
