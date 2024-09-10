using UnityEngine;

[ExecuteInEditMode]
public class GridLayout1 : MonoBehaviour
{
    public int rows = 2; 
    public int columns = 2;  
    public Vector2 cellSize = new Vector2(1, 1);  
    public Vector2 spacing = new Vector2(0.5f, 0.5f); 

    void Start()
    {
        int childCount1 = transform.childCount;
        float gridWidth1 = (columns - 1) * (cellSize.x + spacing.x);
        float gridHeight1 = (rows - 1) * (cellSize.y + spacing.y);
        Vector3 startPosition1 = new Vector3(-gridWidth1 / 2, gridHeight1 / 2, 0);

        CreateTable(childCount1, startPosition1);
    }

    void Update()
    {
        int childCount1 = transform.childCount;
        float gridWidth1 = (columns - 1) * (cellSize.x + spacing.x);
        float gridHeight1 = (rows - 1) * (cellSize.y + spacing.y);
        Vector3 startPosition1 = new Vector3(-gridWidth1 / 2, gridHeight1 / 2, 0);

        CreateTable(childCount1, startPosition1);
    }

    public void ArrangeChildrenInGrid1()
    {
        int childCount1 = transform.childCount;
        float gridWidth1 = (columns - 1) * (cellSize.x + spacing.x);
        float gridHeight1 = (rows - 1) * (cellSize.y + spacing.y);
        Vector3 startPosition1 = new Vector3(-gridWidth1 / 2, gridHeight1 / 2, 0);

        CreateTable(childCount1, startPosition1);
    }

    private void CreateTable(int childCount1, Vector3 startPosition)
    {
        for (int i4 = 0; i4 < childCount1; i4++)
        {
            int row1 = i4 / columns;
            int column1 = i4 % columns;

            Vector3 position1 = new Vector3(
                column1 * (cellSize.x + spacing.x),
                -row1 * (cellSize.y + spacing.y),
                0);

            Transform child1 = transform.GetChild(i4);
            child1.localPosition = startPosition + position1;
            child1.localScale = new Vector3(cellSize.x, cellSize.y, 1);
        }
    }
}
