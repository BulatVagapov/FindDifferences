using System;
using TMPro;
using UnityEngine;

public class TestAppodeal : MonoBehaviour
{
    [SerializeField] int timeForAds;

    [SerializeField] private GameObject adsPanel;
    [SerializeField] private TMP_Text timeText;
    private Timer timer;

    public event Action AdvEnd;

    private void OnAdvEnd()
    {
        AdvEnd?.Invoke();
    }

    public void ChangeTimeView(int minutes, int seconds)
    {
        timeText.text = minutes + " min " + string.Format("{0:d2}", seconds) + " sec";
    }

    private void Start()
    {
        adsPanel.SetActive(false);
        timer = new Timer(timeForAds);
        timer.TimeIsOver += OnAdvEnd;
        timer.TimeHasChanged += ChangeTimeView;
    }

    public void OnStartAdv()
    {
        adsPanel.SetActive(true);
        timer.OnTimeHasChanged(timeForAds);
        StartCoroutine(timer.TimerCorutine());
    }
}
