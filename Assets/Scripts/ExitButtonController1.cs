using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ExitButtonController1 : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
        Exit();
    }

    private void Exit()
    {
        _exitButton.onClick.AddListener(Application.Quit);
    }
}
