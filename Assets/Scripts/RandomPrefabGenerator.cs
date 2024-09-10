using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomPrefabGenerator : MonoBehaviour
{
    public event Action LevelCompleted;

    public GameObject[] prefabs;
    public int scoreThreshold = 10;
    public int currentScore = 0;
    public int addScore = 1;
    private int totalObjectsWithID1 = 0;
    private int clickedObjectsWithID1 = 0;

    void Start()
    {
        GenerateRandomPrefabs();
    }

    void GenerateRandomPrefabs()
    {
        totalObjectsWithID1 = 0;
        clickedObjectsWithID1 = 0;

        GridLayout1 gridLayout1 = GetComponent<GridLayout1>();
        if (gridLayout1 == null)
        {
            Debug.LogError("Компонент GridLayout не найден на объекте!");
            return;
        }

        int totalObjects1 = gridLayout1.rows * gridLayout1.columns;
        RemoveExistingChildren();

        for (int i2 = 0; i2 < totalObjects1; i2++)
        {
            if (prefabs.Length == 0)
            {
                Debug.LogWarning("Нет префабов для генерации!");
                return;
            }

            GameObject prefab = prefabs[GenerateWithRatio()];
            GameObject instance = Instantiate(prefab, transform);
            instance.name = prefab.name + "_" + i2;

            AddClickHandler(instance);
        }

        if (totalObjectsWithID1 == 0)
        {
            Debug.LogWarning("Не создано ни одного объекта с ID = 1. Перегенерация...");
            GenerateRandomPrefabs(); 
        }
        else
        {
            gridLayout1.ArrangeChildrenInGrid1();
        }
    }

    int GenerateWithRatio()
    {
        int randomValue = Random.Range(0, 100);

        if (randomValue < 80)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    void AddClickHandler(GameObject instance)
    {
        ObjectIDComponent idComponent1 = instance.GetComponent<ObjectIDComponent>();
        if (idComponent1 == null)
        {
            Debug.LogWarning($"ObjectIDComponent не найден на объекте {instance.name}");
            return;
        }

        if (idComponent1.ID == 1)
        {
            totalObjectsWithID1++;
        }

        instance.AddComponent<BoxCollider2D>();
        instance.AddComponent<ClickHandler>().Init(this, idComponent1.ID);
    }

    void RemoveExistingChildren()
    {
        for (int i1 = transform.childCount - 1; i1 >= 0; i1--)
        {
            Transform child1 = transform.GetChild(i1);
            if (Application.isPlaying)
            {
                Destroy(child1.gameObject);
            }
            else
            {
                DestroyImmediate(child1.gameObject);
            }
        }
    }

    public void AddScore(int value, int objectID)
    {
        currentScore += value;
        Debug.Log($"Текущий счёт: {currentScore}");

        if (objectID == 1)
        {
            clickedObjectsWithID1++;
            Debug.Log($"Нажато объектов с ID = 1: {clickedObjectsWithID1}/{totalObjectsWithID1}");

            if (clickedObjectsWithID1 >= totalObjectsWithID1)
            {
                Debug.Log("Все объекты с ID = 1 нажаты, перегенерация!");
                GenerateRandomPrefabs();
            }
        }

        if (currentScore >= scoreThreshold)
        {
            LevelCompleted?.Invoke();
            Debug.Log("Уровень пройден!");
        }
    }
}
