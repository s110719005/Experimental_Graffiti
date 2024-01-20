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


}
