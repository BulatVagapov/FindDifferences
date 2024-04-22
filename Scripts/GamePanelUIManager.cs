using TMPro;
using UnityEngine;

public class GamePanelUIManager : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text differencesLeftText;
    [SerializeField] private TMP_Text currentLevelText;

    public void ChangeTimeView(int minutes, int seconds)
    {
        timeText.text = minutes + " min " + string.Format("{0:d2}", seconds) + " sec";
    }

    private void DifferenceLeftView(int differencesAmount)
    {
        differencesLeftText.text = "Differences left: " + differencesAmount;
    }

    void Start()
    {
        levelManager.Timer.TimeHasChanged += ChangeTimeView;
        levelManager.DifferenceFound += DifferenceLeftView;
        currentLevelText.text = "Level: " + levelManager.CurrentLevel;
    }

}
