using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public bool DEBUG_hasGenerate = false;
        public bool DEBUG_canMouseInput = false;
        
        void Start()
        {
            //grid = new Grid(20, 10, 10f, gameObject);
            grid = new Grid(gridDefinition, gameObject);
        }

        void Update()
        {
            CheckMouseInput();
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
                        UpdateGridColor(hit.point, Color.black);
                    }
                    //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
                }
            }
        }

        
        public void UpdateGridColor(Vector3 position, Color colorToChange)
        {
            grid.SetSpriteColor(position, colorToChange);
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
