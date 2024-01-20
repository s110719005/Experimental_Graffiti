using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GridSystem
{
    public class Grid
    {
        private int width;
        private int height;
        private float cellSize;
        private Sprite gridSprite;
        private GameObject parent;
        private int[,] gridArray;
        private TextMesh[,] debugTextArray;
        private SpriteRenderer[,] gridSprites;

        public Grid(int width, int height, float cellSize, Sprite gridSprite, GameObject parent)
        {
            this.width = width;
            this.height = height;
            this.cellSize = cellSize;
            this.parent = parent;
            this.gridSprite = gridSprite;

            InitGrid();
        }

        public Grid(GridDefinition gridDefinition, GameObject parent)
        {
            this.width = gridDefinition.GridWidth;
            this.height = gridDefinition.GridHeight;
            this.cellSize = gridDefinition.CellSize;
            this.gridSprite = gridDefinition.GridSprite;
            this.parent = parent;
       
            InitGrid();
        }

        private void InitGrid()
        {
            gridArray = new int[width, height];
            gridSprites = new SpriteRenderer[width, height];
            for(int x = 0; x < gridArray.GetLength(0); x++)
            {
                for(int y = 0; y < gridArray.GetLength(1); y++)
                {
                    GameObject gameObject = new GameObject("gridObject", typeof(SpriteRenderer));
                    gridSprites[x, y] = gameObject.GetComponent<SpriteRenderer>();
                    gridSprites[x, y].sprite = gridSprite;
                    Transform transform = gameObject.transform;
                    transform.SetParent(parent.transform, false);
                    transform.localPosition = GetWorldPosition(x, y) + new Vector3(cellSize / 2, 0, cellSize / 2);
                    transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
                    transform.localScale = new Vector3(10, 10);
                }
            }
            // debugTextArray = new TextMesh[width, height];
            // for(int x = 0; x < gridArray.GetLength(0); x++)
            // {
            //     for(int y = 0; y < gridArray.GetLength(1); y++)
            //     {
            //         //Debug.Log(x + " " + y);
            //         debugTextArray[x, y] = Utility.WorldText.CreateWorldText
            //         (
            //             gridArray[x,y].ToString(), 
            //             parent.transform, 
            //             Quaternion.Euler(new Vector3(90, 0, 0)), 
            //             GetWorldPosition(x, y) + new Vector3(cellSize / 2, 0, cellSize / 2), 
            //             20, 
            //             Color.white, 
            //             TextAnchor.MiddleCenter
            //         );
            //         if(parent)
            //         {
            //             Debug.DrawLine(GetWorldPosition(x, y) + parent.transform.position, GetWorldPosition(x, y + 1) + parent.transform.position, Color.white, 100f);
            //             Debug.DrawLine(GetWorldPosition(x, y) + parent.transform.position, GetWorldPosition(x + 1, y) + parent.transform.position, Color.white, 100f);
            //         }
            //         else
            //         {
            //             Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
            //             Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            //         }
            //     }
            // }
            // if(parent)
            // {
            //     Debug.DrawLine(GetWorldPosition(0, height) + parent.transform.position, GetWorldPosition(width, height) + parent.transform.position, Color.white, 100f);
            //     Debug.DrawLine(GetWorldPosition(width, 0) + parent.transform.position, GetWorldPosition(width, height) + parent.transform.position, Color.white, 100f);
            // }
            // else
            // {
            //     Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
            //     Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
            // }
        }

        private Vector3 GetWorldPosition(int x, int y)
        {
            return new Vector3(x, 0, y) * cellSize;
        } 

        private void GetXY(Vector3 worldPosition, out int x, out int y)
        {
            if(parent)
            {
                x = Mathf.FloorToInt((worldPosition.x - parent.transform.position.x) / cellSize);
                y = Mathf.FloorToInt((worldPosition.z - parent.transform.position.z) / cellSize);
            }
            else
            {
                x = Mathf.FloorToInt(worldPosition.x / cellSize);
                y = Mathf.FloorToInt(worldPosition.z / cellSize);
            }
        }

        public void SetValue(int x, int y, int value)
        {
            if(x < 0 || x >= width) { return; }
            if(y < 0 || y >= height) { return; }
            gridArray[x, y] = value;
            debugTextArray[x, y].text = value.ToString();
        }

        public void SetValue(Vector3 worldPosition, int value)
        {
            int x, y;
            GetXY(worldPosition, out x, out y);
            Debug.Log(x + ", " + y);
            SetValue(x, y, value);
        }

        public void SetSpriteColor()
        {
            
        }
    }
}
