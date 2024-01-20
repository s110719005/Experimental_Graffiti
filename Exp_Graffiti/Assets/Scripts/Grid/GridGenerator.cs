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
        
        void Start()
        {
            //grid = new Grid(20, 10, 10f, gameObject);
            grid = new Grid(gridDefinition, gameObject);
        }

        
        public void UpdateGridColor(Vector3 position, Color colorToChange)
        {
            grid.SetSpriteColor(position, colorToChange);
        }

        public void DEBUG_GenerateGrid()
        {
            grid = new Grid(gridDefinition, gameObject);
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
        }
    }

}
