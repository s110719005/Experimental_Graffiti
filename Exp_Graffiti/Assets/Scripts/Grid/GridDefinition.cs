using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
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

        // public void Duplicate(GridDefinition definitionToDuplicate)
        // {
        //     gridWidth = definitionToDuplicate.GridWidth;
        //     gridHeight = definitionToDuplicate.GridHeight;
        //     cellSize = definitionToDuplicate.CellSize;
        //     gridSprite = definitionToDuplicate.GridSprite;
        //     gridColorDatas = definitionToDuplicate.GridColorDatas;

        // }
        public void Duplicate(Grid gridToDuplicate)
        {
            if(gridToDuplicate == null) { return; }
            gridWidth = gridToDuplicate.Width;
            gridHeight = gridToDuplicate.Height;
            cellSize = gridToDuplicate.CellSize;
            gridSprite = gridToDuplicate.GridSprite;
            gridColorDatas = new List<GridColorData>();
            for(int x = 0; x < gridToDuplicate.GridArray.GetLength(0); x++)
            {
                for(int y = 0; y < gridToDuplicate.GridArray.GetLength(1); y++)
                {
                    SetGridSpritesColor(x, y, gridToDuplicate.GridSprites[x, y].color);
                }
            }

        }
    }
}
