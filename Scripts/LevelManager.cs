using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private SceneInitializer sceneInitializer;
    [SerializeField] private TestAppodeal advTesting;
    
    [SerializeField] private int currentLevel = 1;
    const string fileName = "currentLevel.json";
    public int CurrentLevel => currentLevel;
    
    public List<DifferecePointer> differecePointers;
    private int differencesAmount;

    #region timer
    [SerializeField] private int timerTime;
    private Timer timer;
    public Timer Timer => timer;
    #endregion

    #region events
    public event Action<int> DifferenceFound;
    public event Action Loose;
    public event Action Win;
    #endregion

    private void OnWin()
    {
        Win?.Invoke();
    }

    private void OnLoose()
    {
        Loose?.Invoke();
    }

    private void OnDifferenceFound()
    {
        DifferenceFound?.Invoke(differencesAmount);
    }

    public void InitializeLevel()
    {
        sceneInitializer = FindObjectOfType<SceneInitializer>();
        advTesting.AdvEnd += ReloadScene;
        timer = new Timer(timerTime);
        timer.OnTimeHasChanged(timerTime);
        StartCoroutine(timer.TimerCorutine());
        timer.TimeIsOver += OnLoose;
        Saver<int>.TryLoad(fileName, ref currentLevel);
        differencesAmount = differecePointers.Count;
        foreach (DifferecePointer d in differecePointers)
        {
            d.DifferenceHasFound += DifferenceAmountChanged;
        }

        OnDifferenceFound();
    }

    private void DifferenceAmountChanged()
    {
        differencesAmount--;
        OnDifferenceFound();

        if (differencesAmount == 0) WinLevel();
    }

    private void WinLevel()
    {
        StopAllCoroutines();
        currentLevel++;
        Saver<int>.Save(fileName, currentLevel);
        OnWin();
    }

    public void ReloadScene()
    {
        sceneInitializer.ReloadScene();
    }

    private void OnDestroy()
    {
        advTesting.AdvEnd -= ReloadScene;
    }
}
