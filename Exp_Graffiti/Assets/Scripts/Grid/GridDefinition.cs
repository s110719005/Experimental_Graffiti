using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GridSystem/GridDefinition")]
public class GridDefinition : ScriptableObject
{
    [SerializeField]
    private int gridWidth;
    public int GridWidth => gridWidth;
    [SerializeField]
    private int gridHeight;
    public int GridHeight => gridHeight;
    [SerializeField]
    private float cellSize;
    public float CellSize => cellSize;

    [SerializeField]
    private Sprite gridSprite;
    public Sprite GridSprite => gridSprite;

    [SerializeField]
    private Color[,] gridColor;
    public Color[,] GridColor => gridColor;

    [SerializeField]
    private List<GridColorData> gridColorDatas;
    public List<GridColorData> GridColorDatas => gridColorDatas;

    [System.Serializable]
    public class GridColorData
    {
        public int x;
        public int y;
        public Color color;
    }
    

    public void SetGridSpritesColor(int x, int y, Color newColor)
    {
        GridColorData newData = new GridColorData();
        newData.x = x;
        newData.y = y;
        newData.color = newColor;
        gridColorDatas.Add(newData);
    }

    public void ResetColorData()
    {
        gridColorDatas.Clear();
    }
}
