using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController1 : MonoBehaviour
{
    public Button[] levelButtons;  
    public Sprite lockedSprite;    
    public Sprite activeSprite;    
    public Sprite passedSprite;    
    public NextRetryButton NextLevelButton;
    public NextRetryButton ReplayLevelButton;
    public ScoreDisplay ScoreDisplay;
    public LevelTimer LevelTimer;

    private void Awake()
    {
        NextLevelButton.LevelButtonController1 = this;
        ReplayLevelButton.LevelButtonController1 = this;
        ScoreDisplay.IndexCount = levelButtons.Length;
    }

    private void OnEnable()
    {
        InitializeButtons1();
    }

    public void InitializeButtons1()
    {
        for (int i1 = 0; i1 < levelButtons.Length; i1++)
        {
            Button button1 = levelButtons[i1];
            int levelStatus1;

            if (i1 == 0)
            {
                levelStatus1 = PlayerPrefs.GetInt("Level1" + i1, 1); 
            }
            else
            {
                levelStatus1 = PlayerPrefs.GetInt("Level1" + i1, 0); 
            }

            switch (levelStatus1)
            {
                case 0:
                    SetButtonState1(button1, lockedSprite, false);
                    break;
                case 1:
                    SetButtonState1(button1, activeSprite, true);
                    break;
                case 2:
                    SetButtonState1(button1, passedSprite, true);
                    break;
            }
        }
    }

    void SetButtonState1(Button button, Sprite sprite, bool interactable)
    {
        button.image.sprite = sprite;  
        button.interactable = interactable;  
    }


    public void LevelButtonInvoke1(int levelButtonNumber)
    {
        levelButtons[levelButtonNumber].onClick.Invoke();
    }
}
