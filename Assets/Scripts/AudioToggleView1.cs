using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AudioToggleView1 : MonoBehaviour
{
  [SerializeField] private Image _toggleIndicatorImage1;
  [SerializeField] private Button _toggleButton1;
  [SerializeField] private Sprite _mutedSprite1;
  [SerializeField] private Sprite _unmutedSprite1;
  [SerializeField] private AudioMixer _audioMixer1;
  [SerializeField] private AudioSource _clickSoundSource1;
  [SerializeField] private bool _controlsSound1;

  private bool _isToggledOn1 = true;
  private Vector3 _initialImagePosition1;

  void Start()
  {
    _toggleButton1.onClick.AddListener(HandleToggleButtonClick1);
    _initialImagePosition1 = _toggleIndicatorImage1.rectTransform.position;

    _audioMixer1.GetFloat("SoundsVolumes", out float soundsValue);
    _audioMixer1.GetFloat("MusicsVolumes", out float musicValue);
    if (_controlsSound1)
    {
      if (soundsValue == -80f)
      {
        MoveIndicatorToStart1();
        SetImageToMuted1();
        _isToggledOn1 = false;
      }
      else
      {
        MoveIndicatorRight1();
        SetImageToUnmuted1();
        _isToggledOn1 = true;
      }
    }
    else
    {
      if (musicValue == -80f)
      {
        MoveIndicatorToStart1();
        SetImageToMuted1();
        _isToggledOn1 = false;
      }
      else
      {
        MoveIndicatorRight1();
        SetImageToUnmuted1();
        _isToggledOn1 = true;
      }
    }
  }

  private void HandleToggleButtonClick1()
  {
    _clickSoundSource1.Play();
    if (_isToggledOn1)
    {
      MoveIndicatorToStart1();
      SetImageToMuted1();
      SetMixerVolumeToMin10();
    }
    else
    {
      MoveIndicatorRight1();
      SetImageToUnmuted1();
      SetMixerVolumeToMax1();
    }

    _isToggledOn1 = !_isToggledOn1;
  }

  private void MoveIndicatorToStart1()
  {
    _toggleIndicatorImage1.rectTransform.position = _initialImagePosition1;
  }

  private void MoveIndicatorRight1()
  {
    _toggleIndicatorImage1.rectTransform.position += new Vector3(0.35f, 0f, 0f);
  }

  private void SetImageToMuted1()
  {
    _toggleIndicatorImage1.sprite = _mutedSprite1;
  }

  private void SetImageToUnmuted1()
  {
    _toggleIndicatorImage1.sprite = _unmutedSprite1;
  }

  private void SetMixerVolumeToMin10()
  {
    if (_controlsSound1)
    {
      _audioMixer1.SetFloat("SoundsVolumes", -80);
    }
    else
    {
      _audioMixer1.SetFloat("MusicsVolumes", -80);
    }
  }

  private void SetMixerVolumeToMax1()
  {
    if (_controlsSound1)
    {
      _audioMixer1.SetFloat("SoundsVolumes", 0);
    }
    else
    {
      _audioMixer1.SetFloat("MusicsVolumes", 0);
    }
  }
}