using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BlockVisibilityToggle1 : MonoBehaviour
{
    public event Action OnBlocksToggled1;

    [FormerlySerializedAs("_currentBlocks")][SerializeField] private List<GameObject> blocksToHide;
    [FormerlySerializedAs("_targetBlocks")][SerializeField] private List<GameObject> blocksToShow;
    [SerializeField] private Button toggleButton;

    private void Awake()
    {
        AddListeners();
    }

    private void AddListeners()
    {
        toggleButton.onClick.AddListener(ToggleBlocksVisibility1);
    }

    private void ToggleBlocksVisibility1()
    {
        HideBlocks();
        ShowBlocks();

        OnBlocksToggled1?.Invoke();
        
        void ShowBlocks()
        {
            foreach (GameObject block2 in blocksToShow)
            {
                block2.SetActive(true);
            }
        }
    }

    private void HideBlocks()
    {
        foreach (GameObject block1 in blocksToHide)
        {
            block1.SetActive(false);
        }
    }
}
