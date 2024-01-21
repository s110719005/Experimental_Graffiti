using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPainting : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.TryGetComponent<SkateboardController>(out SkateboardController skateboardController))
        {
            GameCore.Instance.EndGame();
        } 
    }
}
