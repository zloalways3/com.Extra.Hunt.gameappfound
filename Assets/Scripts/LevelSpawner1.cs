using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSpawner1 : MonoBehaviour
{
    [SerializeField] private GameObject _levelPrefab;
    [SerializeField] private GameObject _sceneContainer;
    [SerializeField] private Transform _parentTransform; 
    [SerializeField] private BlockVisibilityToggle1 _blockVisibilityToggle;
    [SerializeField] private int lvlnum; 

    private Text _buttonText1; 
    private LevelButtonController1 _levelButtonController1; 
    private ClickHandler clickHandler;
    private RandomPrefabGenerator _randomPrefabGenerator;
    private GameObject _level3;

    private void Awake()
    {
        _levelButtonController1 = GetComponentInParent<LevelButtonController1>();
        _buttonText1 = GetComponent<Button>().GetComponentInChildren<Text>();
        _blockVisibilityToggle.OnBlocksToggled1 += SpawnLevel1;
        _levelButtonController1.LevelTimer.LevelLost += OnLevelLost;
        if (_buttonText1 != null)
        {
            _buttonText1.text = lvlnum.ToString();
        }
    }

    private void SpawnLevel1()
    {
        _level3 = Instantiate(_levelPrefab, _parentTransform);
        RandomPrefabGenerator randomPrefabGenerator = _level3.GetComponent<RandomPrefabGenerator>();
        randomPrefabGenerator.LevelCompleted += () => _levelButtonController1.LevelTimer.StopAllCoroutines();
        _levelButtonController1.ScoreDisplay.SetValues(randomPrefabGenerator, lvlnum);
        _levelButtonController1.NextLevelButton.UpdateCurrentLevelIndex1(lvlnum);
        _levelButtonController1.ReplayLevelButton.UpdateCurrentLevelIndex1(lvlnum);
    }

    private void OnLevelLost()
    {
        Destroy(_level3);
    }
}
