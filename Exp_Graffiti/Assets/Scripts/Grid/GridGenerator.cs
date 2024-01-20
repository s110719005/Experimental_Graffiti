using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public class GridGenerator : MonoBehaviour
    {
        [SerializeField]
        private SkateboardController skateBoard;
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
    }

}
