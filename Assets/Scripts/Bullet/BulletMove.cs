using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {
    [HideInInspector] public Transform target;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float colDown;
    

    void Update () 
    {
        if(target != null){
            transform.position = Vector3.MoveTowards (transform.position, target.position, Time.deltaTime * speed);
        }
        else
        {
            Destroy(gameObject);
        }
        Destroy (gameObject, 5);
    }
}