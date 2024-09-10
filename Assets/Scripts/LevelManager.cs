using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _winView;
    [SerializeField] private GameObject _loseView;

    private LevelTimer _levelTimer;

    private void OnEnable()
    {
        _levelTimer = GetComponent<LevelTimer>();
        _levelTimer.LevelLost += OnLose;
    }

    private void OnDestroy()
    {
        _levelTimer.LevelLost -= OnLose;
    }

    private void OnDisable()
    {
        _levelTimer.LevelLost -= OnLose;
    }

    private void OnWin() => _winView.SetActive(true);
    private void OnLose() => _loseView.SetActive(true);
}
