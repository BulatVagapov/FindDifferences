using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private int currentTime;

    public bool IsPaused;

    public event Action<int, int> TimeHasChanged;

    public event Action TimeIsOver;

    public Timer(int timerTime)
    {
        currentTime = timerTime;
    }

    public void OnTimeHasChanged(int time)
    {
        int minutes = currentTime/60;
        int seconds = currentTime%60;

        TimeHasChanged?.Invoke(minutes, seconds);
    }

    private void OnTimeIsOver()
    {
        TimeIsOver?.Invoke();
    }

    public IEnumerator TimerCorutine()
    {
        while(currentTime > 0)
        {
            yield return new WaitForSeconds(1f);

            if (!IsPaused)
            {

                currentTime--;

                OnTimeHasChanged(currentTime);
            }
        }

        OnTimeIsOver();
    }

    public void IncreaseTime(int increase)
    {
        currentTime += increase;
    }
}
