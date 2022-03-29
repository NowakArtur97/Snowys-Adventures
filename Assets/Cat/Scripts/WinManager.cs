using TMPro;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    private string COUNTER_TEXT_GAME_OBJECT_NAME = "Fishes Counter Text (TMP)";

    private TextMeshProUGUI _numberOfFishesText;
    private int _currentNumberOfFishes;
    private int _totalNumberOfFishes;

    private void Awake()
    {
        _totalNumberOfFishes = FindObjectsOfType<WinTrigger>().Length;
        _numberOfFishesText = GameObject.Find(COUNTER_TEXT_GAME_OBJECT_NAME).GetComponent<TextMeshProUGUI>();
        _numberOfFishesText.text = _numberOfFishes;
    }

    public void FindFish()
    {
        _currentNumberOfFishes++;

        if (_numberOfFishesText == null)
        {
            _numberOfFishesText = GameObject.Find(COUNTER_TEXT_GAME_OBJECT_NAME).GetComponent<TextMeshProUGUI>();
        }

        _numberOfFishesText.text = _numberOfFishes;

        if (_totalNumberOfFishes == _currentNumberOfFishes)
        {
            FindObjectOfType<SceneLoader>().StartEndLevelTransition();
        }
    }

    private string _numberOfFishes => $"{_currentNumberOfFishes}/{_totalNumberOfFishes}";
}
