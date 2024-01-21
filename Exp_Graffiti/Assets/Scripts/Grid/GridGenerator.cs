using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;



#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GridSystem
{
    public class GridGenerator : MonoBehaviour
    {
        private Grid grid;
        [SerializeField]
        private GridDefinition gridDefinition;
        public GridDefinition CurrentGridDefinition => gridDefinition;
        [SerializeField]
        private Color currentColor = Color.white;
        [SerializeField]
        private TextMeshProUGUI accuracyText;

        private int correctCell = 0;

        public bool DEBUG_hasGenerate = false;
        public bool DEBUG_canMouseInput = false;
        
        void Start()
        {
            
        }

        void Update()
        {
            CheckMouseInput();
        }

        public void GenerateGrid()
        {
            //grid = new Grid(gridDefinition, gameObject);
            grid = new Grid(gridDefinition.GridWidth, gridDefinition.GridHeight, gridDefinition.CellSize, gridDefinition.GridSprite, gameObject);
            int count = 0;
            for(int x = 0; x < grid.GridArray.GetLength(0); x++)
            {
                for(int y = 0; y < grid.GridArray.GetLength(1); y++)
                {
                    count = x * (gridDefinition.GridHeight - 1) + y;
                    if(grid.GridSprites[x, y].color == gridDefinition.GridColorDatas[count].color)
                    {
                        correctCell ++;
                    }
                }
            }
            UpdateAccuracyText();
        }

        private void CheckMouseInput()
        {
            if(DEBUG_canMouseInput)
            {
                if (Input.GetMouseButton(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        UpdateGridColor(hit.point, currentColor);
                    }
                    //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
                }
            }
        }

        public void ChangeColor(Color newColor)
        {
            currentColor = newColor;
        }

        
        public bool UpdateGridColor(Vector3 position, Color colorToChange)
        {
            int x, y;
            if(grid.SetSpriteColor(position, colorToChange, out x, out y))
            {
                UpdateAccuracy(x, y);
                return true;
            }
            return false;
        }
        public void UpdateAccuracyText()
        {
            float percentage = (float)correctCell / (float)(gridDefinition.GridWidth * gridDefinition.GridHeight);
            percentage = percentage * 100;
            accuracyText.text = percentage.ToString("0.#\\%");// + "%";
        }

        private void UpdateAccuracy(int x, int y)
        {
            int count = x * (gridDefinition.GridHeight - 1) + y;
            Debug.Log(grid.GridSprites[x, y].color + " ? " + gridDefinition.GridColorDatas[count].color);
            if(grid.GridSprites[x, y].color == gridDefinition.GridColorDatas[count].color)
            {
                correctCell++;
            }
            else
            {
                correctCell--;
            }
            UpdateAccuracyText();
        }

        public void DEBUG_GenerateGrid()
        {
            if(DEBUG_hasGenerate) { DEBUG_ResetGrid(); }
            grid = new Grid(gridDefinition, gameObject);
            DEBUG_hasGenerate = true;
        }

        public void DEBUG_GenerateGridTemplate()
        {
            if(DEBUG_hasGenerate) { DEBUG_ResetGrid(); }
            grid = new Grid(gridDefinition, gameObject);
            grid.SetColor(gridDefinition);
            DEBUG_hasGenerate = true;
        }

        public void DEBUG_RecordColor()
        {
            gridDefinition.ResetColorData();
            if(grid != null)
            {
                for(int x = 0; x < grid.GridArray.GetLength(0); x++)
                {
                    for(int y = 0; y < grid.GridArray.GetLength(1); y++)
                    {
                        var recordColor = grid.GridSprites[x, y].color;
                        if(!gridDefinition.UsedColors.Contains(recordColor))
                        {
                            gridDefinition.AddUsedColor(recordColor);
                        }
                        gridDefinition.SetGridSpritesColor(x, y, grid.GridSprites[x, y].color);
                    }
                }
            }
            else
            {
                Debug.Log("THERE IS NO GRID!!!");
            }
        }

        public void DEBUG_ResetGrid()
        {
            for(int x = 0; x < grid.GridArray.GetLength(0); x++)
            {
                for(int y = 0; y < grid.GridArray.GetLength(1); y++)
                {
                    DestroyImmediate(grid.GridSprites[x, y].gameObject);
                }
            }
            grid.Reset();
            grid = null;
            DEBUG_hasGenerate = false;
        }

        public void DEBUG_CreateGridAsset()
        {
            GridDefinition newGrid = ScriptableObject.CreateInstance<GridDefinition>();
            newGrid.name = "gridTemplate";
            newGrid.Duplicate(grid);
            var uniqueFileName = AssetDatabase.GenerateUniqueAssetPath("Assets/ScriptableObject/GridTemplate.asset");
            AssetDatabase.CreateAsset(newGrid, uniqueFileName);
        }
    }

}
