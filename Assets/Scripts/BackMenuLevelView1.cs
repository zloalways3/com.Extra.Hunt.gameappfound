using UnityEngine;

public class BackMenuLevelView1 : MonoBehaviour
{
    [SerializeField] private BlockVisibilityToggle1 _blockVisibilityToggle;
    public GameObject _scene;

    private void Awake()
    {
        OnBlocksToggled();
    }

    private void OnBlocksToggled()
    {
        _blockVisibilityToggle.OnBlocksToggled1 += OnButtonClick1;
    }

    private void OnButtonClick1()
    {
        DeleteSceneLevels();
    }

    private void DeleteSceneLevels()
    {
        for (int i1 = 0; i1 < _scene.transform.childCount; i1++)
        {
            ClearScene(i1);
        }

        void ClearScene(int i1)
        {
            GameObject level1 = _scene.transform.GetChild(i1).gameObject;
            Destroy(level1);
        }
    }
}
