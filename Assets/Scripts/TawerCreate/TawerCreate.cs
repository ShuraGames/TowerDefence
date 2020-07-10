using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TawerCreate : MonoBehaviour {
    [SerializeField]private List<TowerDefault> towerPrefab = new List<TowerDefault>();
    [SerializeField]private Camera mainCamera;
    [SerializeField]private bool towerChoise = false;
    [SerializeField]private float towerAngle = -180f;
    [SerializeField]private LayerMask objectSelectionMask;

    private int indexChoiseTawer;
    private Collider nextChoise;
    private MoneyChange moneyChange;

    private void Start() {
        moneyChange = GameObject.FindWithTag("MoneyManager").GetComponent<MoneyChange>();
    }

    private void Update () 
    {
        if (towerChoise) 
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
            if(Physics.Raycast(ray, out  hit, 5000f, layerMask: objectSelectionMask));
            {
                
                if(hit.collider.GetComponent<ChioseSelection>() != null){
                    var lastHit = hit.collider;
                    if(nextChoise != null)
                    {   
                        if(lastHit != nextChoise)
                        {
                            lastHit.GetComponent<ChioseSelection>().isHover = true;
                            lastHit.GetComponent<ChioseSelection>().isChoise = true;
                            nextChoise.GetComponent<ChioseSelection>().isHover = false;
                            nextChoise = lastHit;
                        }
                    }
                    else
                    {
                        lastHit.GetComponent<ChioseSelection>().isHover = true;
                        nextChoise = lastHit;
                    }
                }

                if (Input.GetMouseButtonDown (0)) 
                {
                    Debug.Log ("Click");
                    if (hit.collider.tag == "Area" && hit.collider.GetComponent<ChioseSelection>() != null) 
                    {
                        Instantiate(towerPrefab[indexChoiseTawer].prefab, new Vector3(hit.transform.localPosition.x, 0.4f, hit.transform.localPosition.z), 
                        Quaternion.Euler(-90, towerAngle, 0));
                        hit.collider.GetComponent<ChioseSelection>().isChoise = true;
                        moneyChange.GiveMoney(30);
                        towerChoise = false;
                        towerAngle = -180;
                    }
                } 
            }
        }
    }

    public void ChoiseTawer(int index) 
    {
       if(moneyChange.moneyInProcessGame >= 30)
       {
            towerChoise = true;
            indexChoiseTawer = index;
       }
    }

    public void TurnLeft()
    {
        if(towerChoise)
        {
           towerAngle -= 90f;
        }
    }

    public void TurnRight()
    {
        if(towerChoise)
        {
            towerAngle += 90f;
        }
    }
}