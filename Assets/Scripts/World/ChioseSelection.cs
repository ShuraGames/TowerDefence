using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChioseSelection : MonoBehaviour
{
    [HideInInspector] public bool isChoise;
    [HideInInspector] public bool isHover;

    [SerializeField] private GameObject hoverEffect;

    private void Update() {
        if(isHover)
        {
            hoverEffect.SetActive(true);
        } 
        else
        {
            hoverEffect.SetActive(false);
        }
    }
}
