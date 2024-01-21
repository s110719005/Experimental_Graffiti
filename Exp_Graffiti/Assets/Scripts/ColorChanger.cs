using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private Color color;
    [SerializeField]
    private Renderer colorMaterial;

    internal void SetUpColor(Color color)
    {
        Debug.Log(color);
        this.color = color;
        colorMaterial.material.SetColor("_Color", color);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.TryGetComponent<SkateboardController>(out SkateboardController skateboardController))
        {
            skateboardController.ChangeColor(color);
        }    
    }
}
