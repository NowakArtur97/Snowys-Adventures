using TMPro;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _numberOfFishesText;

    private int _currentNumberOfFishes;
    private int _totalNumberOfFishes;

    private void Awake()
    {
        _totalNumberOfFishes = FindObjectsOfType<WinTrigger>().Length;
        _numberOfFishesText.text = _numberOfFishes;
    }

    public void FindFish()
    {
        _currentNumberOfFishes++;

        _numberOfFishesText.text = _numberOfFishes;

        if (_totalNumberOfFishes == _currentNumberOfFishes)
        {
            LevelManager.LoadNextScene();
        }
    }

    private string _numberOfFishes => $"{_currentNumberOfFishes}/{_totalNumberOfFishes}";
}
