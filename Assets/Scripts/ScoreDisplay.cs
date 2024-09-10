using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
  public int IndexCount { get; set; }
  
  [SerializeField] private GameObject _winPopup;
  [SerializeField] private Text _winScore;
  [SerializeField] private Text _loseScore;
  
  private RandomPrefabGenerator _randomPrefabGenerator;
  private Text scoreText;
  private int _levelNumber;

  void Start()
  {
    scoreText = GetComponent<Text>();
  }

  void Update()
  {

    UpdateScoreText();
  }
  
  public void SetValues(RandomPrefabGenerator randomPrefabGenerator, int lvlnum)
  {
    _randomPrefabGenerator = randomPrefabGenerator;
    _levelNumber = lvlnum;
    randomPrefabGenerator.LevelCompleted += OnLevelCompleted;
  }

  private void UpdateScoreText()
  {

    if (_randomPrefabGenerator == null) return;
    scoreText.text = $"{_randomPrefabGenerator.currentScore}/{_randomPrefabGenerator.scoreThreshold}";
    _loseScore.text = scoreText.text;
    _winScore.text = scoreText.text;
  }

  private void OnLevelCompleted()
  {
    SaveCompletedLevel1(_levelNumber - 1);
    Destroy(_randomPrefabGenerator.gameObject);
    _winPopup.SetActive(true);
  }
  
  private void SaveCompletedLevel1(int levelIndex)
  {
    PlayerPrefs.SetInt("Level1" + levelIndex, 2); 

    if (levelIndex + 1 < IndexCount && PlayerPrefs.GetInt("Level1" + (levelIndex + 1)) != 2)
    {
      PlayerPrefs.SetInt("Level1" + (levelIndex + 1), 1); 
    }
  }
}