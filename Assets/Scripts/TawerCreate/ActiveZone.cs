using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveZone : MonoBehaviour
{
    [SerializeField]private TowerAttack towerAttack;

    private bool lockActiveTarget;
    private GameObject lastTarget;

    private void Update() {
        if(!lastTarget){
            lockActiveTarget = false;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Enemy" && !lockActiveTarget)
        {
            towerAttack.target = other.gameObject.transform;
            lastTarget = other.gameObject;
            lockActiveTarget = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Enemy" && other.gameObject == lastTarget){
            lockActiveTarget = false;
            towerAttack.target = null;
        }
    }
}
