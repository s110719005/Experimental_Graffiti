using System.Collections;
using System.Collections.Generic;
using GridSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCore : MonoBehaviour
{
    public static GameCore Instance;
    [SerializeField]
    private GridGenerator gridGenerator;
    [SerializeField]
    private GameObject colorChangerPrefab;
    [SerializeField]
    private Transform colorChangerStartPoint;
    // Start is called before the first frame update
    
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        gridGenerator.GenerateGrid();
        //Generate color changer
        for(int i = 0; i < gridGenerator.CurrentGridDefinition.UsedColors.Count; i++)
        {
            var prefab = Instantiate(colorChangerPrefab, colorChangerStartPoint.position + new Vector3(0, 0, 15 * i), Quaternion.identity);
            if(prefab.gameObject.TryGetComponent<ColorChanger>(out ColorChanger colorChanger))
            {
                colorChanger.SetUpColor(gridGenerator.CurrentGridDefinition.UsedColors[i]);
            }
        }
        //Start count down
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate accuracy
        //Go to end scene when time end
    }

    public void EndGame()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
