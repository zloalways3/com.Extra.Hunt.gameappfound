using System;
using UnityEngine;

public class NextRetryButton : MonoBehaviour
{
  public LevelButtonController1 LevelButtonController1 { get; set; }

  [SerializeField] private GameObject levelsPanel;
  [SerializeField] private GameObject currentScene;
  [SerializeField] private BlockVisibilityToggle1 blockVisibilityToggle;
  [SerializeField] private ButtonType buttonType; 
    
  private int currentLevelIndex = -1; 

  private void Awake()
  {
    blockVisibilityToggle.OnBlocksToggled1 += HandleNextOrRetry;
  }

  public void UpdateCurrentLevelIndex1(int levelIndex)
  {
    currentLevelIndex = levelIndex;
  }

  private void HandleNextOrRetry()
  {
    for (int i3 = 0; i3 < currentScene.transform.childCount; i3++)
    {
      GameObject level2 = currentScene.transform.GetChild(i3).gameObject;
      Destroy(level2);
    }

    if (buttonType == ButtonType.Next1)
    {
      if (currentLevelIndex == LevelButtonController1.levelButtons.Length)
      {
        levelsPanel.SetActive(true); 
        return;
      }
      LevelButtonController1.LevelButtonInvoke1(currentLevelIndex);
    }
    else if (buttonType == ButtonType.Retry)
    {
      if (currentLevelIndex > 0)
      {
        LevelButtonController1.LevelButtonInvoke1(currentLevelIndex - 1);
      }
    }
  }
}