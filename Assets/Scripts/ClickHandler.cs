using UnityEngine;

public class ClickHandler : MonoBehaviour
{
  private RandomPrefabGenerator prefabGenerator1;
  private int objectID1;

  public void Init(RandomPrefabGenerator generator, int id)
  {
    prefabGenerator1 = generator;
    objectID1 = id;
  }

  void OnMouseDown()
  {
    if (objectID1 == 1)
    {
      gameObject.SetActive(false);
      prefabGenerator1.AddScore(prefabGenerator1.addScore, objectID1);
    }
  }
}