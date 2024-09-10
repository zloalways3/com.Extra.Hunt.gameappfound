using System.Collections;
using UnityEngine;

public class LoadingScreenManager : MonoBehaviour
{
  [SerializeField] private GameObject _loadingScreenCanvas; 

  void Start()
  {
    StartCoroutine(HideLoadingScreenAfterDelay(1.5f));  
  }

  private IEnumerator HideLoadingScreenAfterDelay(float delay)
  {
    yield return new WaitForSeconds(delay);  

    CanvasGroup canvasGroup1 = _loadingScreenCanvas.GetComponent<CanvasGroup>();
    if (canvasGroup1 != null)
    {
      float startAlpha1 = canvasGroup1.alpha;
      float endAlpha = 0f;
      float fadeDuration1 = 1f;
      float elapsedFadeTime = 0f;

      while (elapsedFadeTime < fadeDuration1)
      {
        elapsedFadeTime += Time.deltaTime;
        canvasGroup1.alpha = Mathf.Lerp(startAlpha1, endAlpha, elapsedFadeTime / fadeDuration1);
        yield return null;
      }

      canvasGroup1.alpha = endAlpha;
      _loadingScreenCanvas.SetActive(false);  
    }
  }
}