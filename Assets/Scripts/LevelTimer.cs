using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
  public Action LevelLost;
  
  [SerializeField] private Slider _timerSlider;
  [SerializeField] private float _time;
  [SerializeField] private float _lerpSpeed = 1f;
  private const float max_time_value = 90f;

  void Start()
  {
    _timerSlider.maxValue = max_time_value; 
  }

  private void OnEnable()
  {
    ResetTimer();
    StartCoroutine(TimerCoroutine());
  }

  private IEnumerator TimerCoroutine()
  {
    while (_time < max_time_value)
    {
      _time += Time.deltaTime;
      SetValueSlider();
      yield return null;
    }
    OnLose();
  }

  private void OnLose()
  {
    LevelLost?.Invoke();
  }

  private void SetValueSlider()
  {
   _timerSlider.value = Mathf.Lerp(_timerSlider.value, _time, Time.deltaTime * _lerpSpeed);
  }

  public void ResetTimer()
  {
    StopAllCoroutines(); 
    _time = 0f;
    _timerSlider.value = 0f;
  }
}