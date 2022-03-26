using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    private readonly string DISSAPEAR_TRIGGER = "dissapear";

    private bool _wasFound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_wasFound)
        {
            _wasFound = true;
            PlayDissapearAnimation();
            FindObjectOfType<WinManager>().FindFish();
            transform.parent.GetComponent<AudioSource>().Play();
        }
    }

    private void PlayDissapearAnimation() => transform.parent.GetComponent<Animator>().SetTrigger(DISSAPEAR_TRIGGER);
}
