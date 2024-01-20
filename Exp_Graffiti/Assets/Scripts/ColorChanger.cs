using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private Color color;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.TryGetComponent<SkateboardController>(out SkateboardController skateboardController))
        {
            skateboardController.ChangeColor(color);
            Debug.Log("COLOR CHANGED");
        }    
    }
}
