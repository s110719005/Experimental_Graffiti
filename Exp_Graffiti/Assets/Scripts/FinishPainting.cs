using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPainting : MonoBehaviour
{
    [SerializeField]
    private GameObject endingCanvas;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.TryGetComponent<SkateboardController>(out SkateboardController skateboardController))
        {
            endingCanvas.SetActive(true);
            //GameCore.Instance.EndGame();
        } 
    }
}
