using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    [SerializeField] private int activeRotate;


    private int[] angle = new int[5] {0, 90, 180, 270, 360};

    void Start()
    {
        if(activeRotate == 0)
        {
            transform.rotation = Quaternion.Euler(-90, 0,angle[Random.Range(0, 5)]);
        }
        else if(activeRotate == 1)
        {
            transform.rotation = Quaternion.Euler(0, angle[Random.Range(0, 5)], 0);
        }
    }
}
